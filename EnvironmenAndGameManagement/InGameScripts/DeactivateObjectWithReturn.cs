using UnityEngine;

public class DeactivateObjectWithReturn : MonoBehaviour {

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            gameObject.SetActive(false);
        }
    }


}
