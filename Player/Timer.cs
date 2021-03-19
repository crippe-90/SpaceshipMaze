using UnityEngine.UI;
using UnityEngine;
using System;

public class Timer : MonoBehaviour {

    public Text timeText;
    public DeathHandler death;
    public float maxTimeInSeconds = 180f;

    private float timeInSeconds;
    private bool gameRunning;
    

    private void Start()
    {
        gameRunning = true;
        timeInSeconds = maxTimeInSeconds;
    }

    void Update () {

        timeInSeconds -= Time.deltaTime;
        SetTextColor();
        CheckIfTimeLeft();
        timeText.text = "Time left:" + Environment.NewLine + ConvertFloatToMinAndSeconds();
        

	}
    public float GetTimeItTookToCompleteLevel()
    {
        return 180f - timeInSeconds;
    }

    private void SetTextColor()
    {
        if (timeInSeconds <= (maxTimeInSeconds / 3))
        {
            timeText.color = Color.red;
        }
        
        else if (timeInSeconds <= (maxTimeInSeconds / 2))
        {
            timeText.color = Color.yellow;
        }

        else
        {
            timeText.color = Color.green;
        }
    }

    private string ConvertFloatToMinAndSeconds()
    {
        int i = Mathf.FloorToInt(timeInSeconds);
        string time = (i/60).ToString() + "m "  + (i % 60).ToString() + " s";

        return time;
    }

    private void CheckIfTimeLeft()
    {
        if (timeInSeconds<=0f)
        {
            if (gameRunning)
            {
                gameRunning = false;
                timeText.enabled = false;
                death.Die();
            }

        }
    }
}
