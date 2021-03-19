using UnityEngine;
using UnityEngine.UI;

public class DeathHandler : MonoBehaviour {
    private Steering[] playerControls;
    public GameObject DeathScreen;
    private EnemySteering[] enemies;

    //restartDelay is tested out with the animations and 8s seemed like a good time.
    private float restartDelay = 8f;

    private void Start()
    {
        playerControls = GetComponents<Steering>();
    }
    public void Die()
    {
        DeathScreen.SetActive(true);
        foreach (Steering s in playerControls)//stops accepting player-input
        {
            s.enabled = false;
        }

        enemies = FindObjectsOfType<EnemySteering>();

        foreach (EnemySteering e in enemies)//stops the enemies from attacking when player is dead.
        {
            if (e != null)
            {
                e.ShutDownEnemy();
            }
            
        }

        Invoke("Restart", restartDelay);
    }

    private void Restart()
    {
        FindObjectOfType<GameManager>().ReloadLevel();
    }
}
