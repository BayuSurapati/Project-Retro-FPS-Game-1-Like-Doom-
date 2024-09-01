using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    public static WeaponController instance;

    public Animator gunAnim;
    //public int currentWeaponAmmo;
    //public int maxAmmo = 100;
    public AudioSource gunFire;

    public GameObject bulletImpact;
    public Camera viewCam;

    //public Text ammoText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //currentWeaponAmmo = maxAmmo;
        //ammoText.text = currentWeaponAmmo.ToString();
        gunFire = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponWorks();
        //UpdateAmmoUI();
    }

    public void WeaponWorks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (PlayerController.instance.currentAmmo > 0)
            {
                gunFire.Play();
                Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;
                PlayerController.instance.currentAmmo--;
                gunAnim.SetTrigger("Shoot");
                

                if (Physics.Raycast(ray, out hit) && PlayerController.instance.currentAmmo > 0)
                {
                    //Debug.Log("Aku Melihat pada " + hit.transform.name);
                    Instantiate(bulletImpact, hit.point, transform.rotation);
                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<EnemyController>().takeDamage();
                    }
                }
            }
            else
            {
                //Debug.Log("Lol gk lihat");
                gunFire.Stop();
            }
        }
    }

    /*public void UpdateAmmoUI()
    {
        ammoText.text = currentWeaponAmmo.ToString();
    }*/
}
