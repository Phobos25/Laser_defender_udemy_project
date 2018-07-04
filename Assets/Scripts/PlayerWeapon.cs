using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

    #region Variables

    //prefab of the projectile. Add from the editor
    public GameObject projectile;

    //firing speed
    public float firingRate = 0.2f;
    public float projectileSpeed = 10f;
    public ShootSoundController shootSound;

    //time counter
    private float timestamp = 0f;
    #endregion

    #region Unity Methods

    // Use this for initialization
    void Start () {
        shootSound = GetComponent<ShootSoundController>();
    }
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !PauseMenu.GameIsPaused)
        {
            //check if the weapon is ready
            if (timestamp> firingRate)
            {
                InvokeRepeating("Shoot", 0.000001f, firingRate);
                timestamp = 0f;
            }            
        }
        if (Input.GetKeyUp(KeyCode.Space) && !PauseMenu.GameIsPaused)
        {
            CancelInvoke("Shoot");
        }
        timestamp += Time.deltaTime;
    }

    #endregion

    //Method that handles shooting of the space weapon
    protected virtual void Shoot()
    {
        //instantiate beam at the position of fire point
        GameObject beam = (GameObject)Instantiate(projectile, transform.position, Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
        //play sound effect of shooting
        shootSound.PlaySoundEffect();
    }
}
