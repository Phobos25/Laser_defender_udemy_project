using UnityEngine;
using System.Collections;

public class Projectile_Missile : Projectile {

    #region Variables

    //speed of the rocket
    public float projectileSpeed = 10f;
    //radius of the explosion. Change in the editor
    public float explosionRadius = 1.5f;

    private Explosion explosion;
    private Animator animator;
    //contains length of the explosion animation
    private float explosionLength;
    #endregion


    #region UnityMethods
    private void Start()
    {
        explosion = GetComponent<Explosion>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RocketExplosion();
            Destroy(gameObject);
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("You have pressed F key");
            AnimatorLengthCalculator();
        }
    }
    #endregion 

    public override void Hit()
    {
        RocketExplosion();
        base.Hit();
    }

    //get animation time length
    public void AnimatorLengthCalculator()
    {
        Debug.Log("pew pew ");

        RuntimeAnimatorController ac = animator.runtimeAnimatorController;

        for (int i = 0; i < ac.animationClips.Length; i++)
        {
            if (ac.animationClips[i].name == "Explosion")
            {
                explosionLength = ac.animationClips[i].length;
            }
        }

        Debug.Log("animation length time = " + explosionLength);
    }


    #region Explosion
    public void RocketExplosion()
    {
        animator.SetTrigger("Explode");
        explosion.ExplosionDamage(transform.position, explosionRadius);
    }

    public void AddDamage(float _damage)
    {
        Debug.Log("Stop hitting yourself!");
    }
    #endregion

    //Draws a sphere around the projectile when selected.
    //radius of the sphere is = to explosion radius.
    //currently set into On Draw Gizmos, for debug sake
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    
}
