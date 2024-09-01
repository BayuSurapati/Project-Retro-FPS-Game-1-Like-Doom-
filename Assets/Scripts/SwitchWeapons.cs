using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchWeapons : MonoBehaviour
{
    public static SwitchWeapons instance;

    [Header("References")]
    [SerializeField] private Transform[] weapons;

    [Header("Keys")]
    [SerializeField] private KeyCode[] keys;

    [Header("Settings")]
    [SerializeField] private float switchWeaponsTime;

    public Text ammoInfoText;

    private int selectedWeapons;
    private float timeSinceLastSwitch;

    //public GameObject[] weapons;
    //int weaponsCounter = 0;
    //public int currentWeaponCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetWeapons();
        Select(selectedWeapons);

        timeSinceLastSwitch = 0f;
        //weapons[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        WeaponController weaponController = FindObjectOfType<WeaponController>();
        ammoInfoText.text = PlayerController.instance.currentAmmo + "";
        

        int previousSelectedWeapons = selectedWeapons;

        for (int i = 0; i < keys.Length; i++)
        {
            if(Input.GetKeyDown(keys[i]) && timeSinceLastSwitch >= switchWeaponsTime)
            {
                selectedWeapons = i;
            }
            if(previousSelectedWeapons != selectedWeapons)
            {
                Select(selectedWeapons);
            }
            timeSinceLastSwitch += Time.deltaTime;
        }
    }

    public void SetWeapons()
    {
        weapons = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            weapons[i] = transform.GetChild(i);
        }

        if(keys == null)
        {
            keys = new KeyCode[weapons.Length];
        }
    }

    public void Select(int weaponsIndex)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == weaponsIndex);
        }
        timeSinceLastSwitch = 0f;
    }

    private void OnWeaponSelected()
    {
        print("Senjata Baru");
    }

    /*public void SwitchWeaponsBug()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponsCounter = 0;

            for (int i = 0; i < weapons.Length; i++)
            {
                if (i != weaponsCounter)
                {
                    weapons[i].SetActive(false);
                }
                else
                {
                    weapons[i].SetActive(true);
                    currentWeaponCounter = 0;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponsCounter = 1;

            for (int i = 0; i < weapons.Length; i++)
            {
                if (i != weaponsCounter)
                {
                    weapons[i].SetActive(false);
                }
                else
                {
                    weapons[i].SetActive(true);
                    currentWeaponCounter = 1;
                }
            }
        }
    }*/
}
