using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    #region Variables

    public float projectileSpeed = 10f;
    public GameObject projectile;    
    public float shotsPerSeconds=0.5f;
    public Transform firePoint;
    public ShootSoundController shootSound;

	#endregion

	#region Unity Methods  
    
    	
	// Update is called once per frame
	void Update ()
    {
        float probability = Time.deltaTime * shotsPerSeconds;
        if (Random.value < probability)
            Shoot();
	}

    #endregion

    void Shoot()
    {
        //instantiate beam at the position of fire point
        GameObject beam = (GameObject)Instantiate(projectile, firePoint.position, Quaternion.identity);
        //projectile speed is - in order to projectile flight towards the player (down)
        beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
        //play sound effect
        shootSound.PlaySoundEffect();
    }
}
