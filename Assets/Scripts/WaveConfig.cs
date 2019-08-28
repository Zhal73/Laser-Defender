using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make an Assets menu to create Wave Config objects
[CreateAssetMenu(menuName = "Enemy Wave Config")]

public class WaveConfig : ScriptableObject
{
    //configuration parameters
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;


    //getter method for the variable enemyPrefab
    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    //getter method for the variable timeBetweenSpawns
    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    //getter method for the variable spawnRandomFactor
    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    //getter method for the variable numberOfEnemies
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    //getter method for the variable moveSpeed
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    //helper method to get the waypoint on the pathPrefab
    public List<Transform> GetWayPoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform waypoint in pathPrefab.transform)
        {
            waveWaypoints.Add(waypoint);
        }
        return waveWaypoints;
    }

}
