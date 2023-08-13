using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public GameObject coin;
    private Vector3 spawnPos = new Vector3 (35, 0, 0);
    private Vector3 spawnCoinPos = new Vector3(25, 5, 0);

    private float startDelay = 2f;
    private float repeatRate = 2f;

    private float coinRepeatRate = 1f;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnCoin", startDelay, coinRepeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCoin()
    {
        if (playerControllerScript.gameOver == false)
        {
            Debug.Log("CoinSpawned");
            Instantiate(coin, spawnCoinPos, coin.transform.rotation);
        }
    }

    void SpawnObstacle() 
    {
        int index = Random.Range(0, obstaclePrefab.Length);
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);
        }
    }
}
