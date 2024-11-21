using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : MonoBehaviour
{

    private weaponScript weapon;
    public float minFireDelay;
    public float maxFireDelay;

    public Transform player;
    public float moveSpeed;
    public float minDistance;
    public float maxDistance;
    public float rotationOffset;

    void Start()
    {

        weapon = GetComponentInChildren<weaponScript>();
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(EnemyShooting());
    }


    void Update()
    {
        //Movement
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        if (distanceToPlayer < minDistance)
        {
            transform.position -= directionToPlayer * moveSpeed * Time.deltaTime;
        }
        else if (distanceToPlayer > maxDistance)
        {
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }

        //Rotation
        Vector3 direction = player.position - transform.position;
        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += rotationOffset;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    IEnumerator EnemyShooting()
    {
        while (true) 
        {
            float delay = Random.Range(minFireDelay, maxFireDelay);
            yield return new WaitForSeconds(delay);
            weapon.Shoot();
        }
    }
}