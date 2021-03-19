using UnityEngine;
using UnityEngine.UI;

public class SoundValueChange : MonoBehaviour {
    private float val;
    private string sound = "sound";
    public Slider slider;


    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(sound);
    }
    private void Update()
    {
        val = slider.value;
    }
   
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat(sound, val);
        PlayerPrefs.Save();
    }
}
