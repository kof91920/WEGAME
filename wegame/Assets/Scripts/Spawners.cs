using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawners : MonoBehaviour {
    public GameObject objectSpawn;
    public int numberOfEnemies;
    private float radius = 5;
    private Vector3 spawnPos;

    public float seconds;
        
    void Start()
    {
        InvokeRepeating("SpawnObject", 0.0f, 30.0f);
    }

    private void Update()
    {

    }

    void SpawnObject()
    {
        for(int i = 0; i < numberOfEnemies; ++i)
        {
            spawnPos = transform.position + Random.insideUnitSphere * radius;
            Instantiate(objectSpawn, spawnPos, Quaternion.identity);
        }
    }
}
