using UnityEngine;

public class SmallEnemyRobotGuns : MonoBehaviour {
    public Rigidbody prefabBullet;
    public float gunPower;
    public GameObject spawnPointLeft;
    public GameObject spawnPointRight;
    public float reloadTime;
    public AudioSource soundEffectSource;

    protected float timeFromLastShot;
    protected Rigidbody bulletLeft;
    protected Rigidbody bulletRight;

    public void Shoot()
    {
        bulletLeft = Instantiate(prefabBullet, spawnPointLeft.transform.position, spawnPointLeft.transform.rotation);
        bulletLeft.velocity = bulletLeft.transform.TransformDirection(Vector3.forward * gunPower * Time.deltaTime);
        bulletRight = Instantiate(prefabBullet, spawnPointRight.transform.position, spawnPointRight.transform.rotation);
        bulletRight.velocity = bulletRight.transform.TransformDirection(Vector3.forward * gunPower * Time.deltaTime);
        soundEffectSource.Play();
    }
}
