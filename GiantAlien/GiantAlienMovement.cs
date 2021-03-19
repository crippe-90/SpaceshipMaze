using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GiantAlienMovement : EnemySteering {
   
 
    public BeamSpawner beam;
    public GameObject weapon;

    private bool hitByBullet;

    protected override void Start()
    {
        base.Start();
        hitByBullet = false;
    }

    void Update () { 
        distance = Vector3.Distance(target.position, transform.position);
       

        if ((distance <= viewRadius)||hitByBullet)
        {
            if(distance > stoppingDistance)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(target.position);
            }
            else
            {
                navMeshAgent.isStopped = true;
            }


            if (!playerSpoted)
            {
                playerSpoted = true;
                StartCoroutine("Shoot");
            }
       
        }
        else
        {
            playerSpoted = false;
        }

	}
    public void HitByBullet()
    {
        hitByBullet = true;
    }
    private void Aim()
    {
        direction = (target.position - weapon.transform.position).normalized;
        weapon.transform.Rotate(direction);
    }
    private IEnumerator Shoot()
    {
        while (playerSpoted)
        {
            Aim();
            beam.Shoot();
            yield return new WaitForSeconds(fireRate);

        }
    }
   

}
