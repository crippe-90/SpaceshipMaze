using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreLvl1 : MonoBehaviour {
    /*Class that handles highscore input*/
    public InputField inputField;
    public GameObject inputFieldActivation;
    public GameObject returnToMainMenuButton;
    public Text hsText;

    private Highscore[] highscore;

    private Highscore[] table;

    protected string hsName = "lvl1Name";
    protected string hsTime = "lvl1Time";
    protected string currentTimeString = "lvl1CurrentTime";

    private float currentTime;
    private float place1;
    private float place2;
    private float place3;


    protected virtual void Start()
    {
        currentTime =  PlayerPrefs.GetFloat(currentTimeString);

        table = new Highscore[3];
        GetScore();
       
        CheckPlacement();

    }
    private void Update()
    {
        //Use method below to delete all highscores from the lvl

        /*
        if (Input.GetKey(KeyCode.C))
        {
            for (int i = 0; i < table.Length; i++)
            {
                PlayerPrefs.SetFloat(hsTime + (i + 1).ToString(), float.MaxValue);
                PlayerPrefs.SetString(hsName + (i + 1).ToString(), null);
                PlayerPrefs.Save();
            }
        }
        */
    }

    private void GetScore()
    {
        for (int i = 0; i < table.Length; i++)
        {
            if(PlayerPrefs.HasKey(hsTime + (i+1).ToString())&&PlayerPrefs.HasKey(hsName + (i + 1).ToString()))
            {
                table[i] = new Highscore(PlayerPrefs.GetFloat(hsTime + (i + 1).ToString()), PlayerPrefs.GetString(hsName + (i + 1).ToString()));
            }
            else
            {
                table[i] = new Highscore();
            }

            
        }
    }

    private void CheckPlacement()
    {
        if (currentTime < table[0].GetTime())
        {
            table[2] = table[1];
            table[1] = table[0];
            StartCoroutine("WiteName", 0);
        }
        else if (currentTime < table[1].GetTime())
        {
            table[1] = table[0];
            StartCoroutine("WiteName", 1);
        }
        else if (currentTime < table[2].GetTime())
        {
            StartCoroutine("WiteName", 2);
        }
        else
        {
            PrintScore();
        }
    }

    private IEnumerator WiteName(int index)
    {
        inputFieldActivation.SetActive(true);
        bool buttonPressed = false;
        string name = null;

        while (!buttonPressed)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                name = inputField.text;
                if (name.Length > 0 && name.Length < 15)
                {
                    buttonPressed = true;
                    inputFieldActivation.SetActive(false);
                    table[index] = new Highscore(currentTime, name);
                }
            }

            yield return new WaitForEndOfFrame();
        }
        SaveScore();
        PrintScore();
    }

    private void SaveScore()
    {
        for (int i = 0; i < table.Length; i++)
        {
            PlayerPrefs.SetFloat(hsTime + (i + 1).ToString(), table[i].GetTime());
            PlayerPrefs.SetString(hsName + (i + 1).ToString(), table[i].GetName());
            PlayerPrefs.Save();
        }
    }

    private void PrintScore()
    {
        if (table[1].GetTime()==float.MaxValue&&table[2].GetTime()==float.MaxValue)
        {
            hsText.text = "1. name: " + table[0].GetName() + ", time:" + FloatToTimeString(table[0].GetTime());
        }
        else if (table[2].GetTime()==float.MaxValue)
        {
            hsText.text = "1. name: " + table[0].GetName() + ", time:" + FloatToTimeString(table[0].GetTime()) + Environment.NewLine +
                     "2. name: " + table[1].GetName() + ", time:" + FloatToTimeString(table[1].GetTime());
        }
        else
        {
            hsText.text = "1. name: " + table[0].GetName() + ", time:" + FloatToTimeString(table[0].GetTime()) + Environment.NewLine +
                         "2. name: " + table[1].GetName() + ", time:" + FloatToTimeString(table[1].GetTime()) + Environment.NewLine +
                         "3. name: " + table[2].GetName() + ", time:" + FloatToTimeString(table[2].GetTime());
        }

        returnToMainMenuButton.SetActive(true);

    }

    private string FloatToTimeString(float v)
    {
        int i = Mathf.FloorToInt(v);
        string time = (i / 60).ToString() + "m " + (i % 60).ToString() + " s";
        return time;

    }
    public string GetNameStr()
    {
        return hsName;
    }
    public string getTimeStr()
    {
        return hsTime;
    }
    #region Highscore-class
    private class Highscore
    {
        private float time = float.MaxValue;
        private string name = null;

        public Highscore(float t, string n)
        {
            time = t;
            name = n;
        }
        public Highscore()
        {

        }
        public float GetTime()
        {
            return time;
        }
        public string GetName()
        {
            return name;
        }
    }
    #endregion
}

