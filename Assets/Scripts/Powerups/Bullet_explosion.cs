using UnityEngine;
using System.Collections;

public class Bullet_explosion : Powerup {

    #region Variables

    public int numberOfShots = 12;
    public float localShotPos;
    public float offset = 0.5f;
    public Projectile projectile;
    public float projectileSpeed = 5f;
    public ShootSoundController boomSound;

    private float velocityOnX;
    private float velocityOnY;
    

    #endregion

    protected override void Pickup(Collider2D col)
    {

        Nova();

        //Destroy game object
        Destroy(gameObject);
    }

    //creates a nova of bullets
    void Nova()
    {
        Vector3 localShotPos = new Vector3(0, -((new Vector2(transform.localScale.x * offset,
                                    transform.localScale.y * offset)).magnitude));

        //calculates degree intervals based on number of shots
        float degree = 360f / numberOfShots;
        for (float i = -180f; i < 180f; i += degree)
        {
            Quaternion rotation = Quaternion.AngleAxis(i, transform.forward);
            //calculate position to instantiate the projectile
            Vector3 shotPosition = transform.position + rotation * localShotPos;
            Projectile beam = (Projectile) Instantiate(projectile, shotPosition, rotation * transform.rotation);

            //calculate vector x and y by using angle
            velocityOnX = Mathf.Sin((i * Mathf.PI) / 180);
            //convert actual degrees to radians
            velocityOnY = Mathf.Cos((i * Mathf.PI) / 180);

            beam.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityOnX * projectileSpeed, -velocityOnY * projectileSpeed);            
        }

        //play sound effect. Sound effect should be played only once
        boomSound = GetComponent<ShootSoundController>();
        boomSound.PlaySoundEffect();
    }

}
