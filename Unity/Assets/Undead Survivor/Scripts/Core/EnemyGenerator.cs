using UnityEngine;
using System;
using System.Collections.Generic;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Player;
    public GameObject EnemyPrefab;
    public float SpawnDistance;
    private FarmerLevel _farmerLevel;

    private System.Random _random = new();
    void Start()
    {
        _farmerLevel = Player.GetComponent<FarmerLevel>();

        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.Spawned.Count==0) {
            uint count = _farmerLevel.Level * 2;
            
            for(uint i=0; i<count; i++) {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy() {
        double theta = _random.NextDouble() * Math.PI *2;
        double x = Math.Cos(theta) * SpawnDistance;
        double y = Math.Sin(theta) * SpawnDistance;

        Vector3 spawnPoint = new((float)x, (float)y);

        Instantiate(EnemyPrefab, Player.transform.position+spawnPoint, Quaternion.identity); 
    }
}
