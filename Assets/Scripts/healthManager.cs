using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    public int health, maxHealth;
    public float damageDelay;
    private float lastTimeDamaged;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(int damage)
    {
        if (Time.time - lastTimeDamaged >= damageDelay)
        {
            health -= damage;
            lastTimeDamaged = Time.time;

            if (health <= 0)
            {
                if (this.CompareTag("Enemy"))
                {
                    Destroy(this.gameObject);
                }

                if (this.CompareTag("Player"))
                {
                    Destroy(this.gameObject); //The player is not supposed to be desroyed
                }
            }
        }
    }
}
