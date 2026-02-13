using System.Linq;
using UnityEngine;

namespace Game
{
    public sealed class UnitSpawner
    {
        private readonly UnitFactory _factory;
        private readonly IRepository<string, UnitConfig> _unitRepository;
        private readonly string _defaultPlayerId;
        private readonly Transform _playerSpot;
        private readonly Transform _enemySpot;

        public UnitSpawner(UnitFactory factory, IRepository<string, UnitConfig> unitRepository, string defaultPlayerId, Transform playerSpot, Transform enemySpot)
        {
            _factory = factory;
            _unitRepository = unitRepository;
            _defaultPlayerId = defaultPlayerId;
            _playerSpot = playerSpot;
            _enemySpot = enemySpot;
        }

        public UnitController SpawnDefaultPlayer()
        {
            UnitConfig config = _unitRepository.Get(_defaultPlayerId);
            UnitModel model = new UnitModel(config.Id, config.Damage, config.Health, _playerSpot.position, Vector3.zero, config.Speed, config.FireRate);

            return _factory.CreatePlayer(model, config.Prefab, _playerSpot);
        }

        public UnitController SpawnRandomEnemy()
        {
            UnitConfig config = RandomUtils.GetRandomElement(_unitRepository.GetAll().ToArray());
            UnitModel model = new UnitModel(config.Id, config.Damage, config.Health, _enemySpot.position, RandomUtils.GetRandomDirectionInCircle(), config.Speed, config.FireRate);

            return _factory.CreateEnemy(model, config.Prefab, _enemySpot);
        }

        public UnitController SpawnPlayer(UnitModel model)
        {
            UnitConfig config = _unitRepository.Get(model.Id);
            return _factory.CreatePlayer(model, config.Prefab, _playerSpot);
        }

        public UnitController SpawnEnemy(UnitModel model)
        {
            UnitConfig config = _unitRepository.Get(model.Id);
            return _factory.CreateEnemy(model, config.Prefab, _enemySpot);
        }
    }
}
