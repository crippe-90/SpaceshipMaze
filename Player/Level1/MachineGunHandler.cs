using System.Collections;
using UnityEngine;

public class MachineGunHandler : MonoBehaviour {
    public Transform machinegun;
    public float rotateSpeed;
    public ParticleSystem sparks;
    public Rigidbody prefabBullet;
    public float bulletPower;
    public GameObject spawnPoint;
    public float bulletDelay;
    public WeaponSoundEffectTrigger sound;

    private Rigidbody bullet;

    private void Start()
    {
        StartCoroutine("Shoot");
    }
    private void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            RotateGun();
        }
    }

    private void RotateGun()
    {
        machinegun.Rotate(Vector3.down * rotateSpeed * Time.deltaTime , Space.Self);        
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                bullet = Instantiate(prefabBullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
                bullet.velocity = bullet.transform.TransformDirection(Vector3.forward * bulletPower * Time.deltaTime);
                sparks.Play();
                sound.PlaySoundEffect();
               

            }
            yield return new WaitForSeconds(bulletDelay);
        }
    }
}
