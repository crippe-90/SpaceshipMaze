
public class SmallEnemyRobotHitpoints : EnemyHitpoints {

    private void Start()
    {
        hp = startHP;
    }

    void Update () {
        if (hp <= 0)
        {
            hp = 0;
            FindObjectOfType<SmallEnemyRobotGuns>().enabled = false;
            Die();
        }
        hitpoints.text = HitpointsPercentageString();
        hitpoints.color = GetColorByHP();
	}
   
}
