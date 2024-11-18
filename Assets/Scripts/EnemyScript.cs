using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{
    //public GameObject player;
    public Transform Player;
    int MoveSpeed = 4;
    //int MaxDist = 10;
    //int MinDist = 5;
    private bool Canshoot = true;
    public float fireRate;
    public GameObject projectile;
    public float Direct;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        //int fixedZ = 0;
        transform.LookAt(new Vector3(Player.position.x, Player.position.y, 1), new Vector3(0,0,1));
        //transform.LookAt(Player, new Vector3(0,-90,0));
        float dist = Vector3.Distance(Player.position, transform.position);
        if (dist > 5)
        {
            var step = MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Player.position, step);
        }
        if (Canshoot == true)
        {
            Vector3 fireDirection = transform.position - Player.position;
            GameObject currentProjectile = Instantiate(projectile, transform.position, transform.rotation);
            currentProjectile.transform.Translate(fireDirection * Direct * Time.deltaTime);
            Rigidbody2D projRB = currentProjectile.GetComponent<Rigidbody2D>();
            projRB.AddForce(-fireDirection * Direct, ForceMode2D.Impulse);

            StartCoroutine(pang());
        }
    }
    IEnumerator pang() 
    {
        Canshoot = false;
        yield return new WaitForSeconds(fireRate);
        Canshoot = true;

        yield return null;
    }
}