using UnityEngine;

namespace Game
{
    public sealed class UnitManager : IUnitManager
    {
        private readonly UnitSpawner _unitSpawner;

        public UnitManager(UnitSpawner unitSpawner)
        {
            _unitSpawner = unitSpawner;
        }

        public void SpawnUnits()
        {
            _unitSpawner.SpawnDefaultPlayer();
            _unitSpawner.SpawnRandomEnemy();

            Debug.Log("Units spawned");
        }
    }
}
