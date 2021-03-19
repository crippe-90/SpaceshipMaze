using UnityEngine;

public class SoundManager : MonoBehaviour {

    private float soundLevel = 0f;
    private string sound = "sound";

    private AudioSource[] gameSound;

    private void Awake()
    {
        gameSound = FindObjectsOfType<AudioSource>();
        if (PlayerPrefs.HasKey(sound))
        {
            soundLevel = PlayerPrefs.GetFloat(sound);
        }
        else
        {
            soundLevel = 1f;
        }

        foreach (AudioSource aS in gameSound)
        {
            aS.volume = soundLevel;
        }

    }
}
