using UnityEngine;

public class PickupNewWeapon : MonoBehaviour {
    public GameObject weaponToUnlock;
    public GameObject oldWeapon;
    public GameObject pickupPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            weaponToUnlock.SetActive(true);
            oldWeapon.SetActive(false);
            pickupPoint.SetActive(false);
        }
    }
}
