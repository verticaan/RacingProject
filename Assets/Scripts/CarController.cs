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

    // Start is called before the first frame update
    void Start()
    {
        theRB.transform.parent = null;
        turningVFX.SetActive(false);
        landingVFX.SetActive(false);
    }

    // Method to enable input handling
    public void EnableInput()
    {
        canInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canInput) // Check if input is allowed
            return;

        speedInput = 0f;
        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel * 1000f;
        }

        turnInput = Input.GetAxis("Horizontal");

        isMoving = Mathf.Abs(speedInput) > 0;
        isTurning = Mathf.Abs(turnInput) > 0;

        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
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
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnStrength * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

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
        VehicleCameraShake.Instance.ShakeCamera(5f, 1f);
    }
}
