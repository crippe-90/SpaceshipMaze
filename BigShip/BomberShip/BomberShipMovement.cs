using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberShipMovement : BigShipMovement {

    private BomberShipAttack attack;


    protected override void Start()
    {
        
        StartCoroutine("DropBomb");
        attack = GetComponent<BomberShipAttack>();
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        attackPossible = playerSpoted;
    }

    private IEnumerator DropBomb()
    {
        while (true)
        {
            if (attackPossible)
            {
                attack.DropBomb();
            }

            yield return new WaitForSecondsRealtime(fireRate);
        }
    }
}
