using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DriftmanagerTutorial : MonoBehaviour
{
    [SerializeField] private CarController carController;

    public Rigidbody playerRB;
    public Text totalScoreText;
    public Text currentScoreText;
    public Text factorText;
    public Text driftAngleText;

    private float speed = 0;
    private float driftAngle = 0;
    private float driftFactor = 1;
    private float currentScore;
    private float totalScore;

    private bool isDrifting = false;

    public float minimumSpeed = 5;
    public float minimumAngle = 10;
    public float driftingDelay = 0.2f;
    public GameObject driftingObject;
    public Color normalDriftColor;
    public Color nearStopColor;
    public Color driftEndedColor;

    private IEnumerator stopDriftingCoroutine = null;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GameObject.Find("Sphere").GetComponent<Rigidbody>(); //New Code
        carController = GameObject.FindWithTag("Player").GetComponent<CarController>();
        driftingObject.SetActive(false);              
    }

    // Update is called once per frame
    void Update()
    {
        ManageDriftTutorial();
        ManageUITutorial();     
    }
    void ManageDriftTutorial()
    {
        speed = playerRB.velocity.magnitude;

        float turnInput = carController.turnInput;
        float turnStrength = carController.turnStrength;

        driftAngle = Mathf.Abs(turnInput * turnStrength);

        if (driftAngle > 120)
        {
            driftAngle = 0;
        }
        if (driftAngle >= minimumAngle && speed > minimumSpeed)
        {
            if (!isDrifting || stopDriftingCoroutine!= null)
            {
                StartDriftTutorial();
            }
        }
        else
        {
            if (isDrifting && stopDriftingCoroutine == null)
            {
                StopDriftTutorial();
            }
        }
        if (isDrifting)
        {
            currentScore += Time.deltaTime * driftAngle * driftFactor;
            driftFactor += Time.deltaTime;
            driftingObject.SetActive(true);
        }
    }

    async void StartDriftTutorial()
    {
        if (!isDrifting)
        {
            await Task.Delay(Mathf.RoundToInt(1000 * driftingDelay));
            driftFactor = 1;
        }
        if (stopDriftingCoroutine != null)
        {
            StopCoroutine(stopDriftingCoroutine);
            stopDriftingCoroutine = null;
        }
        currentScoreText.color = normalDriftColor;
        isDrifting = true;
    }
    void StopDriftTutorial()
    {
        stopDriftingCoroutine = StoppingDriftTutorial();
        StartCoroutine(stopDriftingCoroutine);
    }
    private IEnumerator StoppingDriftTutorial()
    {
        yield return new WaitForSeconds(0.1f);
        currentScoreText.color = nearStopColor;
        yield return new WaitForSeconds(driftingDelay * 4f);
        totalScore += currentScore;
        isDrifting = false;
        currentScoreText.color = driftEndedColor;
        yield return new WaitForSeconds(0.5f);
        currentScore = 0;
        driftingObject.SetActive(false);
    }
    void ManageUITutorial()
    {
        totalScoreText.text = totalScore.ToString("###,###,000");
        factorText.text = driftFactor.ToString("###,###,##0.0") + "X";
        currentScoreText.text = currentScore.ToString("###,###,000");
        driftAngleText.text = driftAngle.ToString("###, ##0") + " ";
    }
}
