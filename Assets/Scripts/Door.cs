using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorTansform;
    public GameObject colObject;

    public float openSpeed;

    private bool shouldOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldOpen && doorTansform.position.z !=1)
        {
            doorTansform.position = Vector3.MoveTowards(doorTansform.position, new Vector3(doorTansform.position.x, doorTansform.position.y, 1f), openSpeed * Time.deltaTime);

            if (doorTansform.position.z == 1f)
            {
                colObject.SetActive(false);
            }
        }else if(!shouldOpen && doorTansform.position.z != 0)
        {
            doorTansform.position = Vector3.MoveTowards(doorTansform.position, new Vector3(doorTansform.position.x, doorTansform.position.y, 0f), openSpeed * Time.deltaTime);

            if (doorTansform.position.z == 1f)
            {
                colObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            shouldOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = false;
        }
    }
}
