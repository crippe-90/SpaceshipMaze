using UnityEngine;

public class SingleGunShot : MonoBehaviour {

    public Rigidbody prefabBullet;
    private Rigidbody bullet;
    public float gunPower;
    public GameObject spawnPoint;
    public float reloadTime;
    public WeaponSoundEffectTrigger sound;
    public ParticleSystem sparks;

    private bool gunLoaded;
    private bool playerNotHoldingGunButton;
    private float timeFromLastShot;

    private void Start()
    {
        playerNotHoldingGunButton = true;
        ShotPossible();
    }

    void Update () {
        if ((gunLoaded == false)&&playerNotHoldingGunButton)
        {
            timeFromLastShot += Time.deltaTime;
            if (timeFromLastShot >= reloadTime)
            {
                ShotPossible();
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerNotHoldingGunButton = false;
            FireShot();
        }
        else
        {
            playerNotHoldingGunButton = true;
        }
	}
   
    void FireShot()
    {
        if (gunLoaded)
        {
            gunLoaded = false;
            bullet = Instantiate(prefabBullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
            bullet.velocity = bullet.transform.TransformDirection(Vector3.forward * gunPower * Time.deltaTime);
            sparks.Play();
            sound.PlaySoundEffect();
        }
    }

    void ShotPossible()
    {
        gunLoaded = true;
        timeFromLastShot = 0f;
    }
}
