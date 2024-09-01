using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchWeapons2 : MonoBehaviour
{
    InputAction switching;
    public int selectedWeapons = 0;
    // Start is called before the first frame update
    void Start()
    {
        switching = new InputAction("Scrollswitch",binding:"<Mouse>/scroll");
        switching.Enable();
        SelectWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        float scrollValue = switching.ReadValue<Vector2>().y;
        int previousSelected = selectedWeapons;
        if(scrollValue > 0)
        {
            selectedWeapons++;
            if(selectedWeapons == 1)
            {
                selectedWeapons = 0;
            }
        }else if (scrollValue < 0)
        {
            selectedWeapons--;
            if (selectedWeapons == -1)
            {
                selectedWeapons = 0;
            }
        }
        if(previousSelected != selectedWeapons)
        {
            SelectWeapons();
        }
    }

    void SelectWeapons()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        transform.GetChild(selectedWeapons).gameObject.SetActive(true);
    }
}
