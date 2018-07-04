using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
       
    public float damage = 5f;    
  
    public virtual void Hit()
    {
        Destroy(gameObject);
    }

    public float GetDamage()
    {
        return damage;
    }

    public void AddDamage()
    {
        Debug.Log("projectiles hit");
    }

}
