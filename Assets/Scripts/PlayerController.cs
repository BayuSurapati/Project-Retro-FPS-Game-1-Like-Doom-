using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    WeaponController weaponController;
    public static PlayerController instance;

    public Rigidbody2D theRB;
    public float moveSpeed;
    public float sprintSpeed;
    public float walkSpeed;

    private bool IsSprinting => canSprint && Input.GetKey(KeyCode.LeftShift);
    private bool canSprint = true;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public int currentHealth;
    public int maxHealth = 100;

    public float mouseSensitivity = 1f;

    public Camera viewCam;

    public GameObject bulletImpact;
    public int currentAmmo;
    public int maxAmmo;

    //public Animator gunAnim;
    public Animator animPlayer;

    public GameObject deathScreen;
    private bool hasDied;

    public Text healthText, ammoText;

    
    //public AudioSource gunFire;
    //public GameObject cheat;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        weaponController = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponController>();

        currentHealth = maxHealth;
        currentAmmo = maxAmmo;

        healthText.text = currentHealth.ToString() + "%";

        ammoText.text = currentAmmo.ToString();
        //gunFire = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasDied)
        {
            //Player Movement Logic
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;

            theRB.velocity = ((IsSprinting ? sprintSpeed : moveSpeed) * (moveHorizontal + moveVertical));
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("Sprint");
            }

            /*if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                theRB.velocity = (moveHorizontal + moveVertical) * sprintSpeed;
                //moveSpeed *= sprintSpeed;
            }
            else
            {
                theRB.velocity = (moveHorizontal + moveVertical) * walkSpeed;
                //moveSpeed *= walkSpeed;
            }*/

            //Player Camera View Logic
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

            //Player Shooting
            weaponController.WeaponWorks();
            UpdateAmmoUI();

            /*if (Input.GetMouseButtonDown(0))
            {
                if (currentAmmo > 0)
                {

                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        //Debug.Log("Aku Melihat pada " + hit.transform.name);

                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if (hit.transform.tag == "Enemy")
                        {
                            hit.transform.parent.GetComponent<EnemyController>().takeDamage();
                        }
                    }
                    else
                    {
                        //Debug.Log("Lol gk lihat");
                        gunFire.Stop();
                    }
                    currentAmmo--;

                    gunAnim.SetTrigger("Shoot");
                    UpdateAmmoUI();
                    gunFire.Play();
                }
            }*/

            if(moveInput != Vector2.zero)
            {
                animPlayer.SetBool("isMoving", true);
            }
            else
            {
                animPlayer.SetBool("isMoving", false    );
            }
        }

    }
    public void takeDamage(int damageAmount)
    {
        currentHealth-= damageAmount;

        if (currentHealth <= 0)
        {
            deathScreen.SetActive(true);
            hasDied = true;
            currentHealth = 0;
            if(deathScreen == true)
            {
                Time.timeScale = 0f;
            }
        }
        healthText.text = currentHealth.ToString() + "%";
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        healthText.text = currentHealth.ToString() + "%";

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            healthText.text = currentHealth.ToString() + "%";
        }
    }

    public void SetAmmo()
    {
        if (weaponController)
        {
            currentAmmo--;
            UpdateAmmoUI();
        }
    }

    public void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            takeDamage(1);
        }
    }
}
