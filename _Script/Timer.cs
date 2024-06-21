using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : DuongMonoBehaviour
{
    public float timeRemaining = 45f; 
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    protected override void Start()
    {
        base.Start();
        timerIsRunning = true;
    }

    protected virtual void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                UIGameCtrl.Instance.GameOver.gameObject.SetActive(true);
            }
        }
    }

    protected void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
