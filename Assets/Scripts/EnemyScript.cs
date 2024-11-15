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
    bool Canshoot = true;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        float dist = Vector3.Distance(Player.position, transform.position);
        if (dist > 5)
        {
            var step = MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Player.position, step);
        }
    }
    IEnumerator pang() 
    {
        while (true) 
        { 
            if (Canshoot == true)
            {
                //Shoot mechanics here
                //Canshoot = false
            }
            yield return new WaitForSeconds(1);
            //Canshoot = true
            yield return null;
        }
    }
}