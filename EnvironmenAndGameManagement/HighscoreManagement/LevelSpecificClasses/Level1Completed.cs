using System;
using UnityEngine;

public class Level1Completed : MonoBehaviour {


    public Timer timer;

    protected string scoreSaveString = "lvl1CurrentTime";
    /*LevelWonScreen is an Image that will play an animation when it is activated*/
    public GameObject LevelWonScreen;


    /*Delay is set to about 0.5 seconds shorter than the animation so that the 
      Image LevelWonScreen will not dissapear*/
    private float delay = 7.5f;

    /*This method is called when the player enters the portal.
     It manage everything associated with winning a level*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {

            FindObjectOfType<Steering>().enabled = false;
            other.transform.position = transform.position;
            LevelWonScreen.SetActive(true);
            SaveScore();
            Invoke("LoadHighScore", delay);
           
        }
    }

    private void SaveScore()
    {
        float timeToFinishLvl = timer.GetTimeItTookToCompleteLevel();
        PlayerPrefs.SetFloat(scoreSaveString, timeToFinishLvl);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {

        FindObjectOfType<GameManager>().LoadNextLevel();
    }

}
