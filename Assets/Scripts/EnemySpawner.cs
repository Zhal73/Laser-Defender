﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs; //List of waves
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    /*
     * 
     */
    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex ++ )
        {
            var currentWave = waveConfigs[waveIndex];
            yield return SpawnAllEnemyInWave(currentWave);
        }


    }

    /*
     * Coroutine that spwns all the enemy in a wave
     */
    private IEnumerator SpawnAllEnemyInWave(WaveConfig waveConfig)
    {
        for(int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++ )
        {
            //object to instantiate, position and rotation
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), 
                                       waveConfig.GetWayPoints()[0].transform.position, 
                                       Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
        
    }


}
