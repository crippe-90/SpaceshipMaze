using System;
using UnityEngine;
using UnityEngine.UI;

public class AboutButton : MonoBehaviour {
    public Text textBody;
    public Text end;

    private string aboutText = "This game was made by me, Christoffer Norell for the course "
        + Environment.NewLine + "19Summer - 1DV437 - Introduction to Game Programming - 7,5 hp - Kalmar."
        + Environment.NewLine + "It's a simple game where most of the assets are mady by me in blender,"
        + Environment.NewLine + "but some content has been imported from Unity Asset Store and other sources.";
        
	
	public void AboutButtonPressed()
    {
        end.enabled = false;
        SetTextBody();
    }

    private void SetTextBody()
    {
        textBody.text = aboutText; 
    }
}
