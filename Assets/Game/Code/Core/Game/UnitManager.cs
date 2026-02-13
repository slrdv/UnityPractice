using System;
using UnityEngine;

namespace Game
{
    public sealed class UnitManager : IUnitManager, IDisposable
    {
        private readonly UnitSpawner _unitSpawner;
        private readonly IGameTickRegistry _tickRegistry;

        public UnitManager(UnitSpawner unitSpawner, IGameTickRegistry tickRegistry)
        {
            _unitSpawner = unitSpawner;
            _tickRegistry = tickRegistry;
        }

        public void SpawnUnits()
        {
            UnitController player = _unitSpawner.SpawnDefaultPlayer();
            UnitController enemy = _unitSpawner.SpawnRandomEnemy();
            _tickRegistry.Register(player);
            _tickRegistry.Register(enemy);

            Debug.Log("Units spawned");
        }

        public void Dispose()
        {
            _tickRegistry.Unregister(_unitSpawner.SpawnDefaultPlayer());
            _tickRegistry.Unregister(_unitSpawner.SpawnRandomEnemy());
        }
    }
}
