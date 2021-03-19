
using UnityEngine;

public class GiantAlienHitpoints : EnemyHitpoints {

    
    public PortalActivation portalActivation;
    private bool playerSpotted;
 

    private void Start()
    {
        hp = startHP;
        playerSpotted = false;
    }

    void Update()
    {
        if (hp <= 0)
        {
            hp = 0;
            FindObjectOfType<GiantAlienMovement>().enabled = false;
            Die();
        }
        hitpoints.text = HitpointsPercentageString();
        hitpoints.color = GetColorByHP();
    }
    
    protected override void Die()
    {
        portalActivation.ActivatePortal();
        base.Die();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.collider.tag.Equals("PlayerAmmo"))
        {
            if (!playerSpotted)
            {
                FindObjectOfType<GiantAlienMovement>().HitByBullet();
                playerSpotted = true;
            }
        }
    }



}
