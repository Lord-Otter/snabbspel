using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashScript : MonoBehaviour
{
    public float slashDuration;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, slashDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
}
