using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject[] enemies;
    public int numberOfEnemies;
    public float spawnHeight;
    public int enemyWave;

    void Start()
    {
        spawnHeight = 12;
        enemyPrefab = Resources.Load("Prefab/Enemies/Monster", typeof(GameObject)) as GameObject;
        SpawnEnemies(numberOfEnemies);
    }


    void waveSpawner()
    {
        switch(enemyWave)
        {
            case 2:
                SpawnEnemies(20);
                break;
            case 1:
                SpawnEnemies(12);
                break;
            default:
                SpawnEnemies(6);
                break;
        }
    }

    void SpawnEnemies(int enemyNumber)
    {
        enemies = new GameObject[enemyNumber];
        for(int i = 0; i < enemyNumber; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(2 * i,0, spawnHeight), Quaternion.Euler(180,0,0)) as GameObject;
            newEnemy.name = "enemy" + i;

            enemies[i] = newEnemy;
        }
    }
    
}
