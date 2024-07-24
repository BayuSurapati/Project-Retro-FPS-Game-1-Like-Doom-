using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour
{
    public int healthAmmount = 20;


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
        if (other.tag == "Player")
        {
            if (PlayerController.instance.currentHealth < PlayerController.instance.maxHealth)
            {
                PlayerController.instance.AddHealth(healthAmmount);
                Destroy(gameObject);
            }
            else
            {

            }
        }

        
    }
}
