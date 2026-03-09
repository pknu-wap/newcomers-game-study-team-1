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

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator<WaitForSeconds> SpawnEnemy() {
        while(true) {
            double theta = _random.NextDouble() * Math.PI *2;
            double x = Math.Cos(theta) * SpawnDistance;
            double y = Math.Sin(theta) * SpawnDistance;

            Vector3 spawnPoint = new((float)x, (float)y);

            Instantiate(EnemyPrefab, Player.transform.position+spawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(5 / (float)(_farmerLevel.Level+1));
        }
    }
}
