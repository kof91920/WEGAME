using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spawners : MonoBehaviour {
    public GameObject objectSpawn;
    public int numberOfEnemies;
    private float radius = 8;
    private Vector3 spawnPos;

    void Start()
    {
        SpawnObject();
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
