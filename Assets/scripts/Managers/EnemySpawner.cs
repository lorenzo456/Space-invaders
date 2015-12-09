using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    GameObject monsterPrefab;
    GameObject shipPrefab;
    GameObject bossPrefab;

    public GameObject[] enemies;
    public List<GameObject> enemyList = new List<GameObject>();
    public int numberOfEnemies;
    public float spawnHeight;
    public float spawnPos;
    public int enemyWave;
    public bool nextWave;
    public int lastWave;

    void Start()
    {
        spawnHeight = 7;
        spawnPos = 20;
        enemyWave = 0;
        nextWave = false;
        lastWave = 4;
        monsterPrefab = Resources.Load("Prefab/Enemies/Monster", typeof(GameObject)) as GameObject;
        shipPrefab = Resources.Load("Prefab/Enemies/Ship", typeof(GameObject)) as GameObject;
        bossPrefab = Resources.Load("Prefab/Enemies/Boss", typeof(GameObject)) as GameObject;
        waveSpawner();
    }

    void waveSpawner()
    {
        switch(enemyWave)
        {
            case 4:
                spawnPos = 0;
                spawnHeight = 28;
                SpawnEnemies(1, bossPrefab);
                break;
            case 3:
                SpawnEnemies(6, monsterPrefab);
                spawnHeight = 12;
                spawnPos = 10;
                SpawnEnemies(6, shipPrefab);
                break;
            case 2:
                SpawnEnemies(6, shipPrefab);
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
        for(int i = 0; i < numberOfEnemies; i++)
        {
            GameObject newEnemy = Instantiate(prefabType, new Vector3(2 * i - spawnPos,0, spawnHeight), Quaternion.Euler(180,0,0)) as GameObject;
            newEnemy.name = "enemy" + i;
            enemyList.Add(newEnemy);
        }
    }

    void Update()
    {
        
        if (nextWave == true && enemyWave <= lastWave)
        {
            enemyWave = enemyWave + 1;
            waveSpawner();
            nextWave = false;
        }
        
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!enemyList[i].activeInHierarchy)
            {
                Destroy(enemyList[i]);
                enemyList.Remove(enemyList[i]);
                break;
            }

        }
        if(enemyList.Count <= 0)
        {
            nextWave = true;
        }

    }
    
}
