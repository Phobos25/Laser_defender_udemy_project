using UnityEngine;
using System.Collections;

public class Laser : PlayerWeapon {

    #region Variables
    #endregion

    #region Unity Methods

    // Use this for initialization
    void Start () {
        shootSound = GetComponent<ShootSoundController>();
	}

    // Update is called once per frame

    protected override void Update()
    {
        base.Update();
    }

    #endregion

    protected override void Shoot()
    {
        base.Shoot();
    }
}
