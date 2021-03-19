using UnityEngine;

public class EnemyHitpoints : MonoBehaviour {
    #region variables
    public TextMesh hitpoints;
    public int minDamage;
    public int maxDamage;

    protected int startHP = 100;
    protected int hp;
    #endregion
    #region non-override methods
    protected string HitpointsPercentageString()
    {
        string s = "HP: " + hp.ToString() + "%";
        return s;
    }

    protected Color GetColorByHP()
    {
        if (hp < (startHP / 4))
        {
            return Color.red;
        }
        else if (hp < (startHP / 2))
        {
            return Color.yellow;
        }
        else return Color.green;
    }
    #endregion
    #region override methods

    /*Enemy takes damage and maybe something else specified in the class that inherit from this one*/
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("PlayerAmmo"))
        {
            hp -= Random.Range(minDamage, maxDamage);
        }
    }
    /*Enemy dies, and maybe something else specified in the class that inherit from this one*/
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    #endregion
}
