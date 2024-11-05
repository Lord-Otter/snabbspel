using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnman : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float spawnTime = 7f;
    public float spawnDelay = 3f;
    public float spawnLimit = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addEnemy", spawnDelay, spawnTime);
    }
    void addEnemy()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}