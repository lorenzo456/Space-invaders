using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    public GameObject monsterPrefab;
    public GameObject shipPrefab;

    public GameObject[] enemies;
    public int numberOfEnemies;
    public float spawnHeight;
    public int enemyWave;

    void Start()
    {
        spawnHeight = 12;
        monsterPrefab = Resources.Load("Prefab/Enemies/Monster", typeof(GameObject)) as GameObject;
        shipPrefab = Resources.Load("Prefab/Enemies/Ship", typeof(GameObject)) as GameObject;
        SpawnEnemies(numberOfEnemies, shipPrefab);
    }


    void waveSpawner()
    {
        switch(enemyWave)
        {
            case 2:
                SpawnEnemies(20, shipPrefab);
                break;
            case 1:
                SpawnEnemies(12, monsterPrefab);
                break;
            default:
                SpawnEnemies(6, monsterPrefab);
                break;
        }
    }

    void SpawnEnemies(int numberOfEnemies, GameObject prefabType)
    {
        enemies = new GameObject[numberOfEnemies];
        for(int i = 0; i < enemies.Length; i++)
        {
            GameObject newEnemy = Instantiate(prefabType, new Vector3(2 * i - 20,1, spawnHeight), Quaternion.Euler(180,0,0)) as GameObject;
            newEnemy.name = "enemy" + i;

            enemies[i] = newEnemy;
        }
    }
    
}
