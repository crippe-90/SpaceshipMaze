using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    
    #region Index for levels
    private int mainMenu = 1;
    private int allLevelsHighscore = 8;
    private int level1 = 2;
    private int level2 = 4;
    private int level3 = 6;
    #endregion

    #region Level loading methods
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    public void GoToLevel1()
    {
        SceneManager.LoadScene(level1);
    }
    public void GoToLevel2()
    {
        SceneManager.LoadScene(level2);
    }
    public void GoToLevel3()
    {
        SceneManager.LoadScene(level3);
    }
    public void GoToHighscore()
    {
        SceneManager.LoadScene(allLevelsHighscore);
    }
    #endregion 

}
