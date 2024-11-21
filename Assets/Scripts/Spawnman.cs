using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnman : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy1;
    public GameObject enemy2;
    public float spawnTime = 7f;
    public float spawnDelay = 3f;
    public float spawnLimit = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddEnemy());
    }
    IEnumerator AddEnemy()
    {
        while (true)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            int randomizeEnemy = Random.Range(1, 100);
            if(randomizeEnemy <= 70)
            {
                Instantiate(enemy1, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }else if(randomizeEnemy > 70)
            {
                Instantiate(enemy2, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}