using System;

namespace Game
{
    public interface IUnitRegistry
    {
        event Action<UnitController> PlayerRegisteredEvent;
        event Action PlayerUnregisteredEvent;
        event Action<UnitController> EnemyRegisteredEvent;
        event Action EnemyUnregisteredEvent;

        UnitController Player { get; }
        UnitController Enemy { get; }

        void RegisterPlayer(UnitController player);
        void UnregisterPlayer();
        void RegisterEnemy(UnitController enemy);
        void UnregisterEnemy();
    }
}
