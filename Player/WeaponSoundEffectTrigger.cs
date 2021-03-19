using UnityEngine;

public class WeaponSoundEffectTrigger : MonoBehaviour {

    public AudioSource soundSource;
    public AudioClip soundEffect;

    public void PlaySoundEffect()
    {
        soundSource.Play();
    }
}
