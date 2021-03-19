using UnityEngine;
public class ExplosiveBomb : ExplosiveBullet {

    protected override void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
}
