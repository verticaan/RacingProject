using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody theRB;

    public float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180, gravityForce = 10f, dragOnGround = 3f;

    public float speedInput, turnInput;

    private bool grounded;

    private bool wasGrounded; // Track previous grounded state

    public LayerMask whatIsGround;
    public float groundRaylength = .5f;
    public Transform groundRayPoint;

    public Transform leftFrontWheel, rightFrontWheel;
    public float maxWheelTurn = 25f;

    public ParticleSystem[] dustTrail;
    public float maxEmission = 25f;
    private float emissionRate;

    public TrailRenderer[] skidTrail;
    private bool isMoving, isTurning;

    public GameObject turningVFX;
    public GameObject landingVFX;

    private bool canInput = false; // Variable to track if input is allowed

    private Quaternion targetRotation;

    private Keybind keybindScript;

    public float lerpSpeed = 5f;

    private bool useLeftShiftToTurn = false;
    private const string ToggleKey = "UseLeftShiftToTurn";

    public AudioSource drivingSound;

    // Start is called before the first frame update
    void Start()
    {
        keybindScript = FindObjectOfType<Keybind>();
        theRB.transform.parent = null;
        turningVFX.SetActive(false);
        landingVFX.SetActive(false);

        if (PlayerPrefs.HasKey(ToggleKey))
        {
            useLeftShiftToTurn = PlayerPrefs.GetInt(ToggleKey) == 1;

        }
    }

    // Method to enable input handling
    public void EnableInput()
    {
        canInput = true;
    }

    public void DisableInput()
    {
        canInput = false;
    }

    public void ToggleLeftShiftTurn()
    {
        useLeftShiftToTurn = !useLeftShiftToTurn;
        PlayerPrefs.SetInt(ToggleKey, useLeftShiftToTurn ? 1 : 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canInput)
            return;

        float targetSpeedInput = 0f;
        float targetTurnInput = 0f;

        // Instead of direct Input.GetKey calls, use keybindScript to get the assigned keys
        if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), keybindScript.ButtonLabel1.text)))
        {
            targetSpeedInput = 1f; // Forward
        }
        else if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), keybindScript.ButtonLabel2.text)))
        {
            targetSpeedInput = -1f; // Reverse
        }

        if (useLeftShiftToTurn)
        {
            if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), keybindScript.ButtonLabel5.text))) // Check if Left Shift is held down
            {
                if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), keybindScript.ButtonLabel3.text)))
                {
                    targetTurnInput = -1f;
                }
                else if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), keybindScript.ButtonLabel4.text)))
                {
                    targetTurnInput = 1f;
                }
            }
        }
        else
        {
            if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), keybindScript.ButtonLabel3.text)))
            {
                targetTurnInput = -1f;
            }
            else if (Input.GetKey((KeyCode)Enum.Parse(typeof(KeyCode), keybindScript.ButtonLabel4.text)))
            {
                targetTurnInput = 1f;
            }
        }

        if (targetSpeedInput >= 0)
        {
            speedInput = Mathf.Lerp(speedInput, targetSpeedInput * forwardAccel * 1000f, lerpSpeed);
        }
        else
        {
            speedInput = Mathf.Lerp(speedInput, targetSpeedInput * reverseAccel * 1000f, lerpSpeed);
        }

        turnInput = Mathf.Lerp(turnInput, targetTurnInput, Time.deltaTime * lerpSpeed);

        isMoving = Mathf.Abs(speedInput) > 0f;
        isTurning = Mathf.Abs(turnInput) > 0f;

        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));
        }

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn, rightFrontWheel.localRotation.eulerAngles.z);

        transform.position = theRB.transform.position;

        if (isTurning && isMoving && grounded)
        {
            turningVFX.SetActive(true);
        }
        else
        {
            turningVFX.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        wasGrounded = grounded; // Store previous grounded state
        grounded = false;
        RaycastHit hit;

        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRaylength, whatIsGround))
        {
            grounded = true;
            targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        emissionRate = 0;

        if (grounded)
        {
            theRB.drag = dragOnGround;

            if (Mathf.Abs(speedInput) > 0)
            {
                theRB.AddForce(transform.forward * speedInput);
                emissionRate = maxEmission;

                if (!drivingSound.isPlaying)
                {
                    drivingSound.Play();
                }
            }
            else // If speed is zero or less, stop the driving sound
            {
                if (drivingSound.isPlaying)
                {
                    drivingSound.Stop();
                }
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnStrength * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

            if (drivingSound.isPlaying)
            {
                drivingSound.Stop();
            }

            theRB.drag = 0.1f;
            theRB.AddForce(Vector3.up * -gravityForce * 100f);
        }

        foreach (TrailRenderer trail in skidTrail)
        {
            trail.enabled = isTurning && isMoving && grounded;
        }

        foreach (ParticleSystem part in dustTrail)
        {
            var emissionModule = part.emission;
            emissionModule.rateOverTime = (isMoving && isTurning && grounded) ? maxEmission : 0f;
        }

        if (!wasGrounded && grounded)
        {
            if (landingVFX != null)
            {
                AudioManager.instance.PlaySFX("LandingSound");
                landingVFX.SetActive(true);
            }

            CameraShake();
        }
        else if (wasGrounded && !grounded)
        {
            if (landingVFX != null)
            {
                landingVFX.SetActive(false);
            }
        }
    }

    // Method to implement camera shake
    void CameraShake()
    {
        VehicleCameraShake.Instance.ShakeCamera(3f, 1f);
    }
}
