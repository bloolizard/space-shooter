﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    
    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject _powerUpPrefab;

    [SerializeField]
    private GameObject _powerUpContainer;

    private bool _stopSpawning = false;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while (true)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newPowerUp = Instantiate(_powerUpPrefab, posToSpawn, Quaternion.identity);
            newPowerUp.transform.parent = _powerUpContainer.transform;
            float randomSeconds = Random.Range(3f, 7f);
            yield return new WaitForSeconds(randomSeconds);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
