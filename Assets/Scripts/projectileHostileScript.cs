using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{

    public float speed;
    public int damage;
    public float knockback;
    private Vector3 startPosition;
    public float range;
    public int bounces;
    public float rangeAfterBounce;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * speed * Time.deltaTime);

        float distanceTraveled = Vector3.Distance(startPosition, transform.position);

        // If the distance exceeds the target, destroy the object
        if (distanceTraveled >= range)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object hit is the player
        if (other.CompareTag("Player"))
        {
            healthManager healthManager = other.GetComponent<healthManager>();
            if (healthManager != null)
            {
                healthManager.takeDamage(damage);
            }

            // Destroy the projectile
            Destroy(gameObject);
        }

        if (other.CompareTag("Slash"))
        {
            Destroy(gameObject);
        }
    }
}
