using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestExtenjectFactory
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject enemyPrefab;

        public override void InstallBindings()
        {
            Container.BindIFactory<ArmourType, IArmour>().FromFactory<ArmourFactory>();

            Container.Bind<GameObject>().WithId(DependencyIds.EnemyPrefab).FromInstance(enemyPrefab);
        }
    }

    public enum DependencyIds { EnemyPrefab, PlayerPrefab }
}