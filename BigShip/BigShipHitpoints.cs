using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShipHitpoints : EnemyHitpoints {
    private BigShipMovement movement;
    private bool battleStarted;
    public MultipleBosses bossCounter;

    private void Start()
    {
        movement = GetComponent<BigShipMovement>();
        battleStarted = false;
        hp = startHP;
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
        hitpoints.text = HitpointsPercentageString();
        hitpoints.color = GetColorByHP();
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if ((!battleStarted)||collision.collider.tag.Equals("PlayerAmmo"))
        {
            battleStarted = true;
            movement.ShotByPlayer();
        }
    }
    protected override void Die()
    {
        bossCounter.NotifyThatBossIsDead();   
        base.Die();
    }
}
