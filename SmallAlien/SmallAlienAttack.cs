using UnityEngine;

public class SmallAlienAttack : MonoBehaviour {
    public bool attackPossible;
    private SmallAlienAnimation anim;
    private PlayerTarget player;

    public float timeUntilPunchHits;

    public int maxDamage;
    public int minDamage;

    private void Start()
    {
        player = PlayerTarget.target;
        anim = GetComponent<SmallAlienAnimation>();
        attackPossible = false;
    }

    public void Punch()
    {
        anim.OnAttack();
        Invoke("DoDamage", timeUntilPunchHits);
    }

    private void DoDamage()
    {
        player.hp.TakeDamage(minDamage, maxDamage);
    }
}
