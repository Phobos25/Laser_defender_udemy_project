using UnityEngine;
using System.Collections;

public class WeaponSwitching : MonoBehaviour {

    //weapon selected based on weapon index
    public int selectedWeapon = 0;

    private PlayerWeapon pw;
    #region UnityMethods
    // Use this for initialization
    void Start()
    {
        pw = GetComponentInChildren<PlayerWeapon>();
        //enable weapon
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = selectedWeapon;

        ScrollWeapon();

        KeyChangeWeapon();       

        if (previousWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }
    #endregion

    #region WeaponChange
    public void ChangeSelectedWeapon( int _weaponIndex)
    {
        selectedWeapon = _weaponIndex;
    }

    private void ScrollWeapon()
    {
        //scroll weapon up
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        // scroll weapon down
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
    }

    private void KeyChangeWeapon()
    {
        //if "1" is pressed
        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >=1 )
        {
            //change child to 0
            selectedWeapon = 0;
        }
        
        //if "2" is pressed
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            //change child to 1
            selectedWeapon = 1;
        }
    }

    public void SelectWeapon()
    {
        pw.CancelInvoke("Shoot");
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                pw = weapon.GetComponent<PlayerWeapon>();
            }

            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
    #endregion
}

