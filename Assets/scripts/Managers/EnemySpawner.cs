using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject[] enemies;
    public int numberOfEnemies;

    void Start()
    {
        SpawnEnemies(numberOfEnemies);
    }



    void SpawnEnemies(int enemyNumber)
    {
        enemies = new GameObject[enemyNumber];
        for(int i = 0; i < enemyNumber; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(i * 2,0, 0), Quaternion.identity) as GameObject;
            newEnemy.name = "enemy" + i;

            enemies[i] = newEnemy;
        }
    }
    
}
