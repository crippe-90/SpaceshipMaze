using System.Collections;
using UnityEngine;

public class SmallAlienMovement : EnemySteering{
    private SmallAlienAttack alienAttack;

    public float delay;

    private bool attacked;

    protected override void Start()
    {
        base.Start();
        target = PlayerTarget.target.player.transform;
        alienAttack = GetComponent<SmallAlienAttack>();
        alienAttack.attackPossible = false;
        attacked = false;
        StartCoroutine("Battle");
    }

    void FixedUpdate () {
        distance = Vector3.Distance(target.position, transform.position);

        if (attacked||((distance <= viewRadius) && (distance > stoppingDistance)))
        {
            ChasePlayer();
            if (distance <= battleDistance)
            {
                Fight();
            }
        }
        else
        {
            JustWait();
        }
      
    }
    public void AlienUnderAttack()
    {
        attacked = true;
    }
    private void ChasePlayer()
    {
        alienAttack.attackPossible = false;
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(target.position);
        
    }
    private void Fight()
    {
        alienAttack.attackPossible = true;
        FaceTarget();
    }
    private void JustWait()
    {
        navMeshAgent.isStopped = true;
        alienAttack.attackPossible = false;

    }
    private void FaceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
    }
    private IEnumerator Battle()
    {
        while (true)
        {
            if (alienAttack.attackPossible)
            {
                alienAttack.Punch();
            }
            yield return new WaitForSeconds(delay);
        }
    }

}
