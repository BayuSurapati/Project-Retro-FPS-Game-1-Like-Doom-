using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount;

    public float bulletSpeed = 2;
    public Rigidbody2D theRB;

    private Vector3 direction;
    Vector3 startingPoint;

    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bulletSpeed;

        startingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = direction * bulletSpeed;

        if(Vector3.Distance(startingPoint, transform.position) > 35)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.takeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
