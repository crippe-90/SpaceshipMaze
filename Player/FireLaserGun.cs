using UnityEngine;

public class FireLaserGun : MonoBehaviour {

    public BeamSpawner beam;
    private float timeSinceLastBeam;
    public float timeBetweenBeams;
    public WeaponSoundEffectTrigger sound;

    private void Start()
    {
        timeSinceLastBeam = 0f;
    }

    void Update () {


        if (timeSinceLastBeam > timeBetweenBeams)
        {
            if (Input.GetKey(KeyCode.Space))
            {

                beam.Shoot();
                sound.PlaySoundEffect();
                timeSinceLastBeam = 0f;
            }
        }
        else
        {
            timeSinceLastBeam += Time.deltaTime;
        }
          
	}
}
