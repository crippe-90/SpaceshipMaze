using UnityEngine;

public class BomberShipAttack : MonoBehaviour {

    public Rigidbody bombPrefab;
    public float bombDelay;
    public ParticleSystem smoke;
    public Transform bombEmitter;


    public void DropBomb()
    {
        smoke.Play();
        Invoke("SpawnBomb", bombDelay);
        
    }
    private void SpawnBomb()
    {
        Rigidbody bomb = Instantiate(bombPrefab, bombEmitter.position, bombEmitter.rotation);
        bomb.velocity = Vector3.down;
        smoke.Stop();
    }
}
