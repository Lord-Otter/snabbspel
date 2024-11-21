using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileFriendlyScript : MonoBehaviour
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
        if (other.CompareTag("Enemy"))
        {
            healthManager healthManager = other.GetComponent<healthManager>();
            if (healthManager != null)
            {
                healthManager.takeDamage(damage);
            }

            Destroy(gameObject);
        }
        
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
