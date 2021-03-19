using UnityEngine;

public class LevelChooser : MonoBehaviour {


    public GameObject[] levelButtons;
    public GameObject[] choiceButtons;


    public void ChooseLevelPressed()
    {
        foreach(GameObject b in levelButtons)
        {
            b.SetActive(true);
        }
        foreach(GameObject b in choiceButtons)
        {
            b.SetActive(false);
        }
    }
}
