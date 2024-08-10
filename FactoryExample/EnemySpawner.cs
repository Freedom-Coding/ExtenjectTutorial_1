using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Zenject;

namespace TestExtenjectFactory
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float spawnDelay = 3;
        [SerializeField] private Vector2 spawnPositionMin;
        [SerializeField] private Vector2 spawnPositionMax;

        private GameObject enemyPrefab;

        private DiContainer container;

        [Inject]
        private void Construct(DiContainer _container, [Inject(Id = DependencyIds.EnemyPrefab)] GameObject _enemyPrefab)
        {
            container = _container;
            enemyPrefab = _enemyPrefab;
        }


        private async void Start()
        {
            while (true && Application.isPlaying)
            {
                Vector2 pos = new Vector2(Random.Range(spawnPositionMin.x, spawnPositionMax.x), Random.Range(spawnPositionMin.y, spawnPositionMax.y));
                container.InstantiatePrefab(enemyPrefab, pos, Quaternion.identity, transform);
                await Task.Delay((int)(spawnDelay * 1000));
            }
        }
    }
}