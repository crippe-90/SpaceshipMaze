using UnityEngine;

public class PortalActivation : MonoBehaviour {
    public GameObject lightSource;
    public Collider levelWonTrigger;
    public GameObject smokeSource;


    public void ActivatePortal()
    {
        lightSource.SetActive(true);
        levelWonTrigger.enabled = true;
        smokeSource.SetActive(true);
    }
}
