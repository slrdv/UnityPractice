using System;

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

        public void SpawnDefaultUnits()
        {
            RegisterPlayer(_unitSpawner.SpawnDefaultPlayer());
            RegisterEnemy(_unitSpawner.SpawnRandomEnemy());
        }

        public void RestoreUnits(UnitModel playerModel, UnitModel enemyModel)
        {
            RegisterPlayer(_unitSpawner.SpawnPlayer(playerModel));
            RegisterEnemy(_unitSpawner.SpawnEnemy(enemyModel));
        }

        public void DestroyUnits()
        {
            DestroyPlayer();
            DestroyEnemy();
        }

        public void Dispose()
        {

        }

        private void RegisterPlayer(UnitController player)
        {
            _unitRegistry.RegisterPlayer(player);
            _tickRegistry.Register(player);
        }

        private void RegisterEnemy(UnitController enemy)
        {
            _unitRegistry.RegisterEnemy(enemy);
            _tickRegistry.Register(enemy);
        }

        private void DestroyPlayer()
        {
            UnitController unit = _unitRegistry.Player;
            if (unit == null) return;

            _tickRegistry.Unregister(unit);
            _unitRegistry.UnregisterPlayer();
            unit.Dispose();
        }

        private void DestroyEnemy()
        {
            UnitController unit = _unitRegistry.Enemy;
            if (unit == null) return;

            _tickRegistry.Unregister(unit);
            _unitRegistry.UnregisterEnemy();
            unit.Dispose();
        }
    }
}
