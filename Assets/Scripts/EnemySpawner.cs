using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WavesConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WavesConfigSO currentWave;

    [SerializeField] bool isLooping;
    

    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves());    
    }

    public WavesConfigSO GetCurrentWave()
    {
        return currentWave;
    }


    //Adding a coroutine
    IEnumerator SpawnEnemiesWaves()
    {
        do
        {
            foreach (WavesConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    //Create an enemy prefab runtime, start from the position we give it, MUST include rotation, transform
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.Euler(0, 0, 180),
                                transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);

    }

}

