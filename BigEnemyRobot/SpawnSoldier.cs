using UnityEngine;

public class SpawnSoldier : MonoBehaviour {
    #region variables
    /*Time between the method is called and a minion is spawned*/
    public float delay;
    /*the prefab of the minion*/
    public Rigidbody soldier;
    /*point in the gameworld where the minion is spawned*/
    public Transform spawnPoint;
    /*Class that trigger a minion to be spawned*/
    public BigEnemyRobotHitpoints spawnTrigger;
    /*Smoke that comes during a minion is spawned*/
    public ParticleSystem smoke;
    /*To prevent multiple spawns at the same time*/
    private bool spawning;
    #endregion
    #region methods
    private void Start()
    {
        spawning = false;
    }

    public void ActivateSoldier()
    {
        if (!spawning)
        {
            spawning = true;
            smoke.Play();
            Invoke("SpawnMinion", delay);
        }
        
       
        
    }
    private void SpawnMinion()
    {
        spawning = false;
        Rigidbody soldierClone = Instantiate(soldier, spawnPoint.transform.position, spawnPoint.transform.rotation);
        soldierClone.velocity = Vector3.zero;
    }
    #endregion
}
