using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleShipMovement : BigShipMovement {
    public BattleShipWeapon[] weapons;

    protected override void Start () {
        weapons = GetComponentsInChildren<BattleShipWeapon>();
        base.Start();
        StartCoroutine("Shoot");
	}

	protected override void Update () {
        base.Update();
        if (PlayerIsClose()||playerSpoted)
        {
            Aim();
            CheckIfPlayerisWithinShootingDistance();
        }
      
    }


    private void CheckIfPlayerisWithinShootingDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= battleDistance)
        {
            attackPossible = true;
        }
        else
        {
            attackPossible = false;
        }
    }

    private bool PlayerIsClose()
    {
        if (Vector3.Distance(target.position, transform.position) <= viewRadius)
        {
            return true;
        }
        else return false;
    }

    private void Aim()
    {
            Vector3 dir = (target.position - transform.position).normalized;
            Quaternion lookRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * rotationSpeed);
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (attackPossible)
            {
                foreach (BattleShipWeapon w in weapons)
                {
                    w.FireBeam();
                }
            }
           
            yield return new WaitForSeconds(fireRate);
        }
    }
}
