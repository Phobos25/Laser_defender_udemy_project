using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterceptorShooting : MonoBehaviour {

    #region Variables

    public float projectileSpeed = 15f;
    public GameObject projectile;
    public float shotsDelay = 4f;
    public float firingRate = 0.1f;
    public Transform firePoint;
    public ShootSoundController shootSound;
    //max ammo
    public int ammunition = 4;
    //current ammo
    private int ammo;    
    //current coroutine
    private IEnumerator currentCoroutine;
    
    //timer
    private float timestamp;
    #endregion

    #region Unity Methods  

    private void Start()
    {
        ammo = ammunition;
    }

    // Update is called once per frame
    void Update()
    {
        //shoots with random firerate
        float probability = Time.deltaTime * 1 / shotsDelay;

        if (Random.value < probability)
        {
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            //get current coroutine
            currentCoroutine = BurstFire(firingRate);
            StartCoroutine(currentCoroutine);
            //play sound effect
            shootSound.PlaySoundEffect();
            timestamp = 0f;
        }
       
        if (ammo <= 0)
        {
            StopCoroutine(currentCoroutine);
            ammo = ammunition;
        }        
    }

    #endregion

    IEnumerator BurstFire(float _delay)
    {
        //if there are still ammo left
        while (ammo > 0)
        {
            GameObject beam = (GameObject)Instantiate(projectile, firePoint.position, Quaternion.identity);
            beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
            //reduce ammo amount
            ammo--;
            yield return new WaitForSeconds(_delay);
        }
    }    

    void Shoot()
    {
        //instantiate beam at the position of fire point
        GameObject beam = (GameObject)Instantiate(projectile, firePoint.position, Quaternion.identity);        

        //projectile speed is - in order to projectile flight towards the player (down)
        beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
        
    }
}
