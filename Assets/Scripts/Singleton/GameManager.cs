using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int currentScore;
    private int playerCount;
    private int enemyCount;

    public static GameManager _instance;

    private List<IObserver<int>> observers = new List<IObserver<int>>();

    public Text scoreText;
    public Text playerCountText;
    public Text enemyCountText;

    public int PlayerCount => playerCount;
    public int EnemyCount => enemyCount;

    void Awake()
    {
        _instance = this;
        playerCount = 0;
        enemyCount = 0;
    }

    public void AdjustScore(int x)
    {
        currentScore = currentScore + x;
        NotifyObservers();
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore; // Update the text with the current score
        }
    }

    public void RegisterObserver(IObserver<int> observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IObserver<int> observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnNext(currentScore);
        }
    }

    public void UpdatePlayerCount(int count)
    {
        
        playerCount = count;
        UpdatePlayerCountUI();
    }

   public void UpdateEnemyCount(int count)
   {
     enemyCount = count;
      UpdateEnemyCountUI();
  }

    public void UpdatePlayerCountUI()
    {
        if (playerCountText != null)
        {
            playerCountText.text = "Players: " + playerCount;
            UnityEngine.Debug.Log("Player Count UI: " + playerCount);
        }
    }

    public void UpdateEnemyCountUI()
    {
        if (enemyCountText != null)
        {
            enemyCountText.text = "Enemies: " + enemyCount;
            UnityEngine.Debug.Log("Enemy Count UI: " + enemyCount);
        }
    }
}
    

