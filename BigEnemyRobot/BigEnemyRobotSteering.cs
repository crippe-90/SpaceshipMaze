using UnityEngine;
using System.Collections;

public class BigEnemyRobotSteering : EnemySteering {
    /*This class handles the movement of the boss in the Intermediate level*/
    private BigEnemyRobotAttack weapon;

    protected override void Start()
    {
        base.Start();
        weapon = GetComponent<BigEnemyRobotAttack>();

    }

    private void FixedUpdate()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if ((distance <= viewRadius) && (distance > stoppingDistance))
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(target.position);

            if (!playerSpoted)
            {
                playerSpoted = true;
                StartCoroutine("Shoot");
            }

        }
        else if (distance <= stoppingDistance)
        {
            navMeshAgent.isStopped = true;
            FaceTarget();

        }
        else
        {
            playerSpoted = false;
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            weapon.Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void FaceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * rotationSpeed);
    }

}
