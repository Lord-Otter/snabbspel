using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponScript : MonoBehaviour
{

    public GameObject projectile;
    public int numberOfProjectiles;
    public float fireSpread;
    private float nextShot = 0;
    public float fireDelay = 0.5f;
    public bool holdToShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextShot)
        {
            Shoot();          
        }
        if (Input.GetButton("Fire1") && Time.time > nextShot && holdToShoot == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }

        nextShot = Time.time + fireDelay;
    }
}

