using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

    GameObject playerLives;
    GameObject player;

    GameObject wave;
    GameObject level;

    GameObject result;

    GameObject restartGameButton;

	// Use this for initialization
	void Start () {
        restartGameButton = GameObject.Find("RestartButton");
        restartGameButton.SetActive(false);

        playerLives = GameObject.Find("Life");
        player = GameObject.Find("Player");

        level = this.gameObject;
        wave = GameObject.Find("Wave");

        result = GameObject.Find("Result");

    }

    // Update is called once per frame
    void Update () {


        if (level.GetComponent<EnemySpawner>().enemyWave > level.GetComponent<EnemySpawner>().lastWave)
        {
            result.GetComponent<Text>().text = "You won!";
            restartGameButton.SetActive (true);
        }else if (player.GetComponent<Character>().isAlive == false)
        {
            result.GetComponent<Text>().text = "You lose!";
            restartGameButton.SetActive(true);
        }
        else
        {
            playerLives.GetComponent<Text>().text = "Lives: " + player.GetComponent<Character>().hp;
            wave.GetComponent<Text>().text = "Wave: " + level.GetComponent<EnemySpawner>().enemyWave;
        }
        
    }
}
