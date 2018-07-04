using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public float explosionDamage = 5f;

    public void ExplosionDamage(Vector3 center, float radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);

        int i = 0;
        if (hitColliders.Length != 0)
        {
            while (i < hitColliders.Length)
            {
                hitColliders[i].SendMessage("AddDamage", explosionDamage);
                Debug.Log(hitColliders[i].name);
                i++;
            }
        }
      
    }

    public void AddDamage()
    {
        Debug.Log("Stop hitting yourself");
    }


}
