using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour {

    #region Target singleton for enemies
    public static PlayerTarget target;
    private void Awake()
    {
        target = this;
    }

    #endregion

    public GameObject player;
    public PlayerHitpoints hp;

    public void TakeDamage(int min, int max)
    {
        hp.TakeDamage(min, max);
    }
}
