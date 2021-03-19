using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingLightHandler : MonoBehaviour {
    public Light redLight;

    private bool loading;
    private void Awake()
    {
        TurnLightDown();
    }

    private void Update()
    {
        if(loading)
        redLight.intensity += 10 * Time.deltaTime;
        redLight.range += 3 * Time.deltaTime;
    }
    public void TurnLightDown()
    {
        loading = false;
        redLight.intensity = 0f;
        redLight.range = 0f;
    }
    public void StartLoadingLaserBeam()
    {
        loading = true;
    }
    
}
