using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Driftmanager : MonoBehaviour
{
    [SerializeField] private CarController carController;

    private Rigidbody playerRB;
    public Text totalScoreText;
    public Text currentScoreText;
    public Text factorText;
    public Text driftAngleText;
    public Text highScoretext;
    public Text highscoreRecordtext;
    public Text endTotalScoreText;
    public Text highScoreEndCardText;

    private float speed = 0;
    private float driftAngle = 0;
    private float driftFactor = 1;
    private float currentScore;
    public float totalScore;

    private bool isDrifting = false;

    private bool scoringEnabled = true;

    public float minimumSpeed = 5;
    public float minimumAngle = 10;
    public float driftingDelay = 0.2f;
    public GameObject driftingObject;
    public Color normalDriftColor;
    public Color nearStopColor;
    public Color driftEndedColor;

    private IEnumerator stopDriftingCoroutine = null;

    [SerializeField] private Image driftGuageImage1;
    [SerializeField] private Image driftGuageImage2;

    public float fillSpeedCoefficient = 0.006f;

    public bool ScoringEnabled
    {
        get { return ScoringEnabled; }
        set { scoringEnabled = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GameObject.Find("Sphere").GetComponent<Rigidbody>();
        carController = GameObject.FindWithTag("Player").GetComponent<CarController>();
        UpdateHighScoreText();

    }

    // Update is called once per frame
    void Update()
    {
        ManageDrift();
        ManageUI();
    }
    void ManageDrift()
    {
        speed = playerRB.velocity.magnitude;
        float turnInput = carController.turnInput;
        float turnStrength = carController.turnStrength;

        driftAngle = Mathf.Abs(turnInput * turnStrength);

        driftGuageImage1.fillAmount = driftAngle * fillSpeedCoefficient;
        driftGuageImage2.fillAmount = driftAngle * fillSpeedCoefficient;

        // Check if the car is grounded before allowing drifting
        bool isGrounded = Physics.Raycast(playerRB.transform.position, -playerRB.transform.up, 1.0f);

        if (isGrounded)
        {
            if (driftAngle >= minimumAngle && speed > minimumSpeed)
            {
                if (!isDrifting || stopDriftingCoroutine != null)
                {
                    StartDrift();
                }
            }
            else
            {
                if (isDrifting && stopDriftingCoroutine == null)
                {
                    StopDrift();
                }
            }
        }
        else
        {
            // If the car is not grounded it won't drift
            if (isDrifting)
            {
                StopDrift();
            }
        }

        if (isDrifting && scoringEnabled && isGrounded)
        {
            currentScore += Time.deltaTime * driftAngle * driftFactor;
            driftFactor += Time.deltaTime;
            driftingObject.SetActive(true);
        }
    }

    async void StartDrift()
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
    void StopDrift()
    {
        stopDriftingCoroutine = StoppingDrift();
        StartCoroutine(stopDriftingCoroutine);
    }
    private IEnumerator StoppingDrift()
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

        CheckHighscore();
    }
    void ManageUI()
    {
        totalScoreText.text = totalScore.ToString("###,###,000");
        factorText.text = driftFactor.ToString("###,###,0.0") + "X";
        currentScoreText.text = currentScore.ToString("###,###,000");
        driftAngleText.text = driftAngle.ToString("###,##0") + "°";

        endTotalScoreText.text = "DRIFT SCORE: " + totalScore.ToString("###,###,000");

        highScoreEndCardText.text = totalScore.ToString("###,###,000");
    }

    void CheckHighscore()
    {
        if (totalScore > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", totalScore);
            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText()
    {
        highScoretext.text = $"HIGH SCORE: {PlayerPrefs.GetFloat("HighScore", 0).ToString("###,###,000")}";

        highscoreRecordtext.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("###,###,000");
    }


    public void Reset()
    {
        PlayerPrefs.DeleteAll(); //specify the exact key in future
        highScoretext.text = "0";
    }
}
