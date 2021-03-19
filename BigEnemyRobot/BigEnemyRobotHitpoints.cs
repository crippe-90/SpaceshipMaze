using UnityEngine;

public class BigEnemyRobotHitpoints : EnemyHitpoints {
    /*This class handles the movement of the boss in the Intermediate level*/
    private SpawnSoldier spawn; 
    public PortalActivation portalActivation;

    private void Start()
    {
        spawn = GetComponent<SpawnSoldier>();
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

    
    /*Each time the big robot gets attacked by the player, he spawns a minion*/
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.collider.tag.Equals("PlayerAmmo"))
        {
                spawn.ActivateSoldier();   
        }
    }
    protected override void Die()
    {
        base.Die();
        portalActivation.ActivatePortal();

    }
}
