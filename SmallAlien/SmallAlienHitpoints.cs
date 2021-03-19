using UnityEngine;

public class SmallAlienHitpoints : EnemyHitpoints {
    private SmallAlienMovement movement;
	void Start () {
        movement = GetComponent<SmallAlienMovement>();
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

    /*If hit by player weapon, chase player*/
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.collider.tag.Equals("PlayerAmmo"))
        {
            movement.AlienUnderAttack();
        }
    }


}
