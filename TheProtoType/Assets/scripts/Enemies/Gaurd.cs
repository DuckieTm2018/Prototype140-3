
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 50f; // how much numeric health an enemie has

    public void TakeDamage (float damage)
    {
        health -= damage;
        if (health <= 0f) // if helath is 0 then the enimie game object is destroyed and removed from the map
        {
            Die();
        }

    }

    void Die ()
    {
        Destroy(gameObject);
    }
     
}
