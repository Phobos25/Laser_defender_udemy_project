using UnityEngine;
using System.Collections;

public class Weapon_HeavyPlasma : Powerup
{
    //index of the heavy plasma weapon
    private int weaponIndex = 1;

    protected override void Pickup(Collider2D col)
    {
        //get component of the Weapon Switching script
        WeaponSwitching weaponSwitching =  col.gameObject.GetComponentInChildren<WeaponSwitching>();
        //Change weapon index
        weaponSwitching.selectedWeapon = weaponIndex;
        //call the method to change weapon
        weaponSwitching.SelectWeapon();
        //Destroy powerup
        Destroy(gameObject);
    }
}

