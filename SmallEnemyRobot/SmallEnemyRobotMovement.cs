using UnityEngine;
using System.Collections;

public class SmallEnemyRobotMovement : EnemySteering {
    /*Class that handles the movement of Small Enemy Robot*/
    public SmallEnemyRobotGuns robotGun;

    protected bool gunIsActive;

    
	protected void Update () { 
        distance = Vector3.Distance(target.position, transform.position);

        if ((distance <= viewRadius)&&(distance > stoppingDistance))
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(target.position);
          
            if (!playerSpoted)
            {
                playerSpoted = true;
                StartCoroutine("Shoot");
            }
       
        }
        else if(distance <= stoppingDistance)
        {
            navMeshAgent.isStopped = true;

        }
        else
        {
            playerSpoted = false;
        }

	}


    protected void Aim()
    {
            direction = (target.position - transform.position).normalized;
            viewDirection = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, viewDirection, Time.deltaTime * rotationSpeed);
    }
    protected IEnumerator Shoot()
    {
        while (playerSpoted)
        {
            yield return new WaitForSecondsRealtime(fireRate);
            robotGun.Shoot();
            
        }
    }


}
