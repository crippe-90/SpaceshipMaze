using UnityEngine;

public class BattleShipWeapon : MonoBehaviour {
    public Rigidbody laserBeamPrefab;
    public float speed;

    private ParticleSystem sparks;
    private Rigidbody laserBeam;

    private void Start()
    {
        sparks = GetComponent<ParticleSystem>();
    }

    public void FireBeam()
    {
        sparks.Play();
        laserBeam = Instantiate(laserBeamPrefab, transform.position, transform.rotation);
        laserBeam.velocity = laserBeam.transform.TransformDirection(Vector3.forward * speed * Time.deltaTime);
    }

}
