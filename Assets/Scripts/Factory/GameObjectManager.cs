using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public GameObject CreatePlayer(Vector3 position)
    {
        return Instantiate(playerPrefab, position, Quaternion.identity);
    }

    public GameObject CreateEnemy(Vector3 position)
    {
        return Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
