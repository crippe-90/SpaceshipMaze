using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShipMovement : EnemySteering {
    public float speed;
    public Vector3 offset;

    protected bool attackPossible;

    private Vector3 prefferedPosition;
    private Vector3 dir;

    protected override void Start()
    {
        attackPossible = false;
        base.Start();
    }

    protected virtual void Update()
    {        
        if(playerSpoted||(Vector3.Distance(target.position, transform.position) <= viewRadius))
        {
            MoveSpaceship();
        }
        
        
    }


    private void MoveSpaceship()
    {
        prefferedPosition = target.position+offset;
        dir = (prefferedPosition - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    public void ShotByPlayer()
    {
        playerSpoted = true;
    }
}
