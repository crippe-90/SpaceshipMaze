using UnityEngine;

public class FirstGunBullet : MonoBehaviour {
    public float timeUntilBulletDissapear;
    public Rigidbody bullet;

    private void Update()
    {
        timeUntilBulletDissapear -= Time.deltaTime;
        if (timeUntilBulletDissapear <= 0f)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Environment"))
        {
            bullet.velocity = Vector3.zero;
        }
    }
}
