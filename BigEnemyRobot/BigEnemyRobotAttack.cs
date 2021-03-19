using UnityEngine;

public class BigEnemyRobotAttack : MonoBehaviour {
    /*This class handles the attacks from the boss in the Intermediate level*/

    public Rigidbody explosiveBullet;
    public float gunPower;
    public Transform spawnPoint;
    public ParticleSystem sparks;

    private WeaponSoundEffectTrigger sound;
    private Rigidbody bulletClone;

    private void Start()
    {
        sound = GetComponent<WeaponSoundEffectTrigger>();
    }

    public void Shoot()
    {
        bulletClone = Instantiate(explosiveBullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
        bulletClone.velocity = bulletClone.transform.TransformDirection(Vector3.forward * gunPower * Time.deltaTime);
        sparks.Play();
        sound.PlaySoundEffect();
    }
}
