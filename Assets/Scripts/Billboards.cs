using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboards : MonoBehaviour
{
    private SpriteRenderer theSR;
    private Animator theAnim;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        theAnim = GetComponent<Animator>();
        theSR.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerController.instance.transform.position, -Vector3.forward);
    }
}
