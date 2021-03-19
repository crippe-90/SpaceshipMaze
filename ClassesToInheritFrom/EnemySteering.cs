using UnityEngine;
using UnityEngine.AI;

public class EnemySteering : MonoBehaviour {
    public float viewRadius;
    public float stoppingDistance;
    public float battleDistance;
    public float fireRate;
    public float rotationSpeed;
   

    protected Transform target;

    protected bool playerSpoted;
    protected float distance;
    protected NavMeshAgent navMeshAgent;
    protected Vector3 direction;
    protected Quaternion viewDirection;

    protected virtual void Start()
    {
        target = PlayerTarget.target.player.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerSpoted = false;
    }

    public void ShutDownEnemy()
    {
        StopAllCoroutines();
        enabled = false;
    }
}
