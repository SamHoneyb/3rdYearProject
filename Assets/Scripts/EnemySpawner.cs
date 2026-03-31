using UnityEngine;
using System;
using UnityEngine.Rendering;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    [Serializable]
    public class Enemy
    {
        public GameObject enemyPrefab;
        public int cost;
    }

    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> spawnableEnemies = new List<GameObject>();
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    public int currentWave;
    public int waveValue;
    public float spawnDelay = 2f;
    public float waveDelay = 10f;

    public Transform spawnLocation1;
    public Transform spawnLocation2;
    public Transform spawnLocation3;
    public Transform spawnLocation4;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateWave();
    }

    System.Random rnd = new System.Random();

    public IEnumerator SpawnWave()
    {
        Transform[] spawnPoint = { spawnLocation1, spawnLocation2, spawnLocation3, spawnLocation4 };
        for(int i = 0; i < spawnableEnemies.Count; i++)
        {
            Transform randomSpawn = spawnPoint[rnd.Next(0, spawnPoint.Length)];
            GameObject newEnemy = Instantiate(spawnableEnemies[i], randomSpawn.position, randomSpawn.rotation);
            spawnedEnemies.Add(newEnemy); 

            yield return new WaitForSeconds(spawnDelay);
        }

        spawnableEnemies.Clear();

        if (spawnableEnemies.Count <= 0)
        {
            yield return new WaitForSeconds(waveDelay);
            currentWave++;
            GenerateWave();
        }   


    }

    public void GenerateWave()
    {
        waveValue = currentWave * 8;
        GenerateEnemies();
        StartCoroutine(SpawnWave());

    }

    public void GenerateEnemies()
    {
        spawnableEnemies.Clear();

        List<GameObject> generatedEnemies = new List<GameObject>();
        System.Random rnd = new System.Random();
        while (waveValue > 0)
        {
            int randomEnemy = rnd.Next(0, enemies.Count);
            int randomEnemycost = enemies[randomEnemy].cost;

            if (waveValue - randomEnemycost >= 0)
            {
                generatedEnemies.Add(enemies[randomEnemy].enemyPrefab);
                waveValue -= randomEnemycost;
            }
        }
        spawnableEnemies = generatedEnemies;
    }
}

