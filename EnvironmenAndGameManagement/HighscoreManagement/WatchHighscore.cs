using System;
using UnityEngine.UI;
using UnityEngine;

public class WatchHighscore : MonoBehaviour {

    private string lvl1name = "lvl1Name";
    private string lvl2name = "lvl2Name";
    private string lvl3name = "lvl3Name";

    private string lvl1time = "lvl1Time";
    private string lvl2time = "lvl2Time";
    private string lvl3time = "lvl3Time";



    public Text hs1;
    public Text hs2;
    public Text hs3;

    void Start()
    {
        hs1.text = GetLvlHighscore(lvl1name, lvl1time);
        hs2.text = GetLvlHighscore(lvl2name, lvl2time);
        hs3.text = GetLvlHighscore(lvl3name, lvl3time);

    }
    /*Loads and prints the highscore, if it exist*/
    private string GetLvlHighscore(string n, string t)
    {
        string str = null;
        for (int i = 0; i < 3; i++)
        {
            float f;
            string s;
            if (PlayerPrefs.HasKey(n + (i+1).ToString()) && PlayerPrefs.HasKey(t + (i+1).ToString()))
            {
                f = PlayerPrefs.GetFloat(t + (i + 1).ToString());
                s = PlayerPrefs.GetString(n + (i + 1).ToString());
                if (s != null && f != float.MaxValue)//default highscore value is name=null and time=float.MaxValue
                {
                    str += (i + 1).ToString() + ". name: " + s + ", time: " + FloatToTimeString(f) + Environment.NewLine;
                }
               
            }
        }
        return str;
    }

    private string FloatToTimeString(float v)
    {
        int i = Mathf.FloorToInt(v);
        string time = (i / 60).ToString() + "m " + (i % 60).ToString() + " s";
        return time;

    }
}
