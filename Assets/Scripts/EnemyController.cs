﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public int Health =3;
    public GameObject explosions;

    public float playerRange;
    public Rigidbody2D theRB;

    public float moveSpeed;

    public bool shouldShoot;
    public float fireRate = 0.5f;
    private float shootCounter;

    public GameObject bullet;
    public Transform firePoint;

    public GameObject healthToDrops;
    public GameObject ammoToDrops;
    public float healthToDropChance, ammoToDropChance;

    public AudioSource laserEnemy;

    //public Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        laserEnemy = GetComponent<AudioSource>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * moveSpeed;
            //enemyAnim.SetBool("Moving", true);
            //enemyAnim.SetBool("Idle", false);

            if (shouldShoot)
            {
                shootCounter -= Time.deltaTime;

                if(shootCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shootCounter = fireRate;
                    laserEnemy.Play();
                }
            }
        }
        else
        {
            theRB.velocity = Vector2.zero;
            laserEnemy.Stop();
            //enemyAnim.SetBool("Moving", false);
            //enemyAnim.SetBool("Idle", true);
        }
    }

    public void takeDamage()
    {
        Health--;

        if(Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosions, transform.position, transform.rotation);

            if (Random.Range(0f, 100f) < healthToDropChance && healthToDrops != null)
            {
                Instantiate(healthToDrops, transform.position, transform.rotation);
            }
            if (Random.Range(0f, 100f) < ammoToDropChance && ammoToDrops != null)
            {
                Instantiate(ammoToDrops, transform.position, transform.rotation);
            }
        }
    }
}
