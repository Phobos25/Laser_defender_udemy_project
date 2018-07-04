using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

    #region Variables
    public float health = 10f;
    //score value for each destroyed enemy ship
    public int scoreValue = 150;
    public AudioClip deathSound;
    //instance of the score keeper script
    private ScoreKeeper scoreKeeper;
    //volume of the sound
    private float vol;
    #endregion

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
        
    }

    //if something hits the object as trigger
    void OnTriggerEnter2D(Collider2D col)
    {

        Projectile projectile = col.gameObject.GetComponent<Projectile>();
        
        //check if the projectile hits it
        if (projectile)
        {
            //take damage from the projectile
            health -= projectile.GetDamage();
            //call hit method from the projectile's script
            projectile.Hit();

            //if the object's health below 0
            if (health <= 0)
            {
                //if true then call Die method
                Die();
            }            
        }

    }    

    void Die()
    {
        //pick a volume from the settings
        vol = (SettingsMenu.MasterVolume+80)/80;
        //play destruction sound
        AudioSource.PlayClipAtPoint(deathSound, transform.position, vol);
        //give a score to the player
        scoreKeeper.Score(scoreValue);
        //destroy game object
        Destroy(gameObject);
    }

    // this method called by explosion method. 
    //if the object was withing explosion radius
    public void AddDamage(float _damage)
    {
        //take a damage from the explosion
        health -= _damage;
        //check if health below 0
        if (health <= 0)
        {
            //if true call Die method
            Die();
        }
    }
}
