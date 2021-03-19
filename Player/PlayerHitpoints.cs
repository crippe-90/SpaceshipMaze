using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PlayerHitpoints : MonoBehaviour {
    /*Class that handles player hitpoints*/
    public Text hitpoints;
    public GameObject injury;
    private int hp;
    private int maxHP = 100;

	void Start () {
        hp = maxHP;
        StartCoroutine("Heal");
	}

    void Update()
    {
        if (hp <= 0)
        {
            hp = 0;
            Die();
        }
        hitpoints.text = HitpointsPercentageString();
        hitpoints.color = GetColorByHP();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("SmallEnemyRobotBullet"))
        {
            TakeDamage(1, 10);
            
        }
        else if (collision.collider.tag.Equals("GiantAlienLaserBeam"))
        {
            TakeDamage(5, 20);
        }
        else if (collision.collider.tag.Equals("EnemyExplosiveBullet"))
        {
            TakeDamage(10, 25);
        }
        else if (collision.collider.tag.Equals("DangerousEnvironment"))
        {
            TakeDamage(20, 80);
        }
        else if (collision.collider.tag.Equals("BigShipLaserBeam"))
        {
            TakeDamage(1, 6);
        }
    }

    public void TakeDamage(int min, int max)
    {
        hp -= Random.Range(min, max);
        injury.SetActive(true);
        Invoke("StopInjury", 0.1f);
    }
    private void Die()
    {
        StopCoroutine("Heal");
        FindObjectOfType<DeathHandler>().Die();
    }
    private string HitpointsPercentageString()
    {
        string s = "HP: " + hp.ToString() + "%";
        return s;
    }

    private Color GetColorByHP()
    {
        if (hp < (maxHP / 4))
        {
            return Color.red;
        }
        else if (hp < (maxHP / 2))
        {
            return Color.yellow;
        }
        else return Color.green;
    }
    private void StopInjury()
    {
        injury.SetActive(false);
    }
    private IEnumerator Heal()
    {
        while (true)
        {
            if (hp < maxHP)
            {
                hp++;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
