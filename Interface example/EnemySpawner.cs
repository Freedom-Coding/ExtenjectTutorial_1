using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

namespace TestExtenject
{
    public class EnemySpawner : MonoBehaviour
    {
        private IEnemy enemyToSpawn;

        [Inject]
        private void Initialize(IEnemy _enemyToSpawn)
        {
            enemyToSpawn = _enemyToSpawn;
        }

        private void Start()
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            GameObject enemyObject = new GameObject(enemyToSpawn.ToString());

            if (enemyToSpawn is MonoBehaviour)
            {
                enemyObject.AddComponent(enemyToSpawn.GetType());
            }
        }
    }
}