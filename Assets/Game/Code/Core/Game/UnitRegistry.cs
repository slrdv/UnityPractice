using System;

namespace Game
{
    public sealed class UnitRegistry : IUnitRegistry
    {
        public event Action<UnitController> PlayerRegisteredEvent;
        public event Action PlayerUnregisteredEvent;
        public event Action<UnitController> EnemyRegisteredEvent;
        public event Action EnemyUnregisteredEvent;

        private UnitController _player;
        private UnitController _enemy;

        public UnitController Player => _player;
        public UnitController Enemy => _enemy;


        public void RegisterEnemy(UnitController enemy)
        {
            _enemy = enemy;
            EnemyRegisteredEvent?.Invoke(enemy);
        }

        public void RegisterPlayer(UnitController player)
        {
            _player = player;
            PlayerRegisteredEvent?.Invoke(player);
        }

        public void UnregisterPlayer()
        {
            _player = null;
            PlayerUnregisteredEvent?.Invoke();
        }

        public void UnregisterEnemy()
        {
            _enemy = null;
            EnemyUnregisteredEvent?.Invoke();
        }

    }
}
