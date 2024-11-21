using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponScript : MonoBehaviour
{

    public GameObject projectile;
    public int numberOfProjectiles;
    public float fireSpread;
    public bool evenSpread = false;
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
        if (this.CompareTag("Weapon_Friendly"))
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

        if (this.CompareTag("Weapon_Hostile"))
        {
            if (CompareTag("player"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            Quaternion rotation;

            if (evenSpread == false)
            {
                rotation = transform.rotation * Quaternion.Euler(0, 0, Random.Range(fireSpread / 2, -fireSpread / 2));
            }
            else
            {
                float angleStep = fireSpread / (numberOfProjectiles - 1);
                float angle = -fireSpread / 2 + i * angleStep;
                rotation = transform.rotation * Quaternion.Euler(0, 0, angle);
            }

            Instantiate(projectile, transform.position, rotation);
        }

        nextShot = Time.time + fireDelay;
    }

}

