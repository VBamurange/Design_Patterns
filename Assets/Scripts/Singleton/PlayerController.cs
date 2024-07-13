using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IObserver<int>
{
    private GameObjectManager factory;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager._instance;
        factory = FindObjectOfType<GameObjectManager>();

        gameManager.RegisterObserver(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreatePlayer();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            CreateEnemy();
        }
    }

    private void CreatePlayer()
    {
     // GameObject player = factory.CreatePlayer(new Vector3(0, 0, 0));
        gameManager.UpdatePlayerCount(gameManager.PlayerCount + 1);
        GameManager._instance.AdjustScore(10);
        //UnityEngine.Debug.Log("Current Player Count: " + gameManager.PlayerCount);
    }

    private void CreateEnemy()
    {
     // GameObject enemy = factory.CreateEnemy(new Vector3(5, 0, 0));
        gameManager.UpdateEnemyCount(gameManager.EnemyCount + 1);
        GameManager._instance.AdjustScore(-5);
        //UnityEngine.Debug.Log("Current Enemy Count: " + gameManager.EnemyCount);
    }

    public void OnNext(int score)
    {
        UnityEngine.Debug.Log("Score updated: " + score);
    }

    public void OnError(System.Exception error)
    {
        UnityEngine.Debug.LogError("An error occurred: " + error.Message);
    }

    public void OnCompleted()
    {
        UnityEngine.Debug.Log("Observing completed.");
    }

    void OnDestroy()
    {
        GameManager._instance.UnregisterObserver(this);
    }
}
