using UnityEngine;

public class BeamLifetime : FirstGunBullet {

    private void Start()
    {
        bullet = GetComponent<Rigidbody>();
    }
   
    protected override void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
