using System;
using UnityEngine;

namespace Game
{
    public sealed class UnitManager : IUnitManager, IDisposable
    {
        private readonly UnitSpawner _unitSpawner;
        private readonly IGameTickRegistry _tickRegistry;
        private readonly IUnitRegistry _unitRegistry;

        public UnitManager(UnitSpawner unitSpawner, IGameTickRegistry tickRegistry, IUnitRegistry unitRegistry)
        {
            _unitSpawner = unitSpawner;
            _tickRegistry = tickRegistry;
            _unitRegistry = unitRegistry;
        }

        public void SpawnUnits()
        {
            UnitController player = _unitSpawner.SpawnDefaultPlayer();
            UnitController enemy = _unitSpawner.SpawnRandomEnemy();

            _unitRegistry.RegisterPlayer(player);
            _unitRegistry.RegisterEnemy(enemy);

            _tickRegistry.Register(player);
            _tickRegistry.Register(enemy);

            Debug.Log("Units spawned");
        }

        public void Dispose()
        {
            _unitRegistry.UnregisterPlayer();
            _unitRegistry.UnregisterEnemy();
            _tickRegistry.Unregister(_unitSpawner.SpawnDefaultPlayer());
            _tickRegistry.Unregister(_unitSpawner.SpawnRandomEnemy());
        }
    }
}
