
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour {
    /*This class handles explosive*/

    private ParticleSystem explosion;
    private AudioSource soundEffect;

    private bool bulletTriggered;

    private void Start()
    {
        explosion = GetComponent<ParticleSystem>();
        soundEffect = GetComponent<AudioSource>();
        bulletTriggered = false;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Explode();
        }
    }

    protected void Explode()
    {
        if (!bulletTriggered)
        {
            bulletTriggered = true;
            soundEffect.Play();
            explosion.Play();
            Destroy(gameObject, .2f);
        }
        
    }

   
}
