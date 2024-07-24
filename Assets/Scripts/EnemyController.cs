using System.Collections;
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

    public AudioSource laserEnemy;

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
        }
    }

    public void takeDamage()
    {
        Health--;

        if(Health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosions, transform.position, transform.rotation);
        }
    }
}
