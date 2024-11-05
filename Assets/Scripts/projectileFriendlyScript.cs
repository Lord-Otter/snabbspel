using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileFriendlyScript : MonoBehaviour
{

    public float speed;
    public int damage;
    public int bounces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object hit is an enemy
        if (other.CompareTag("Enemy"))
        {
            healthManager healthManager = other.GetComponent<healthManager>();
            if (healthManager != null)
            {
                healthManager.takeDamage(damage);
            }

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
