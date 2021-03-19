using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftTrigger : MonoBehaviour {
    public AirCraftMovement movement;
    public AirCraftRotation rotation;
    public Level1Steering currentControl;

    public GameObject currentWeapon;
    public GameObject AircraftGraphics;

    public BoxCollider aircraftBody;
    public GameObject[] aircraftDetails;
    private GameObject player;
    public Rigidbody playerBody;
    private AudioSource soundEffect;
    public AudioClip clip;

    private void Start()
    {
        soundEffect = GetComponent<AudioSource>();
        currentControl.enabled = true;
        movement.enabled = false;
        rotation.enabled = false;
        player = PlayerTarget.target.player;
        playerBody.drag = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            soundEffect.PlayOneShot(clip);
            AircraftGraphics.SetActive(false);
            currentControl.enabled = false;
            currentWeapon.SetActive(false);
            playerBody.drag = 1f;
            aircraftBody.size = new Vector3(4f, 8f, 4f);

            
            foreach(GameObject d in aircraftDetails)
            {
                d.SetActive(true);
            }

            player.transform.position = transform.position;
            Invoke("ActivateFlightControls", 1f);
            
        }
    }
    private void ActivateFlightControls()
    {
        movement.enabled = true;
        rotation.enabled = true;
        gameObject.SetActive(false);
    }

}
