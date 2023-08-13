using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20;
    private PlayerController playerControllerScript;
    private Transform playerTransform;
    private float leftBound = -10;
    private Transform coin;
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        //coin = GameObject.Find("Money").GetComponent<Transform>();
    }


    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        //if (playerTransform.transform.position.x < coin.transform.position.x)
        //{
        //    Debug.Log("Missed the Coin");
        //}
    }
}
