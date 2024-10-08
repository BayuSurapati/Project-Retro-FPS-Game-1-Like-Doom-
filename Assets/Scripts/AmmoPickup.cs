﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(PlayerController.instance.currentAmmo < PlayerController.instance.maxAmmo)
            {
                PlayerController.instance.currentAmmo += ammoAmount;
                //WeaponController.instance.UpdateAmmoUI();
                Destroy(gameObject);
            }
        }
    }
}
