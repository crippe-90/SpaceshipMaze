using System;
using UnityEngine;

public class BeamSpawner : MonoBehaviour {

    public Rigidbody laserBeamPrefab;
    public float laserSpeed;
    public Transform spawnPlace;
    public LoadingLightHandler redLight;
    public float delay;

    private float timeSinceLastBeam;
    private Rigidbody laserBeam;
    private ParticleSystem sparks;

    private void Start()
    {
        sparks = GetComponent<ParticleSystem>();
    }

    public void Shoot()
    {

        redLight.StartLoadingLaserBeam();
        Invoke("FireBeam", delay);
    }

    private void FireBeam()
    {
        sparks.Play();
        laserBeam = Instantiate(laserBeamPrefab, spawnPlace.transform.position, spawnPlace.transform.rotation);
        laserBeam.velocity = laserBeam.transform.TransformDirection(Vector3.forward * laserSpeed * Time.deltaTime);
        redLight.TurnLightDown();
    }
}
