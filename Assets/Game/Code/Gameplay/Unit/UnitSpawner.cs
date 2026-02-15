using System.Linq;
using UnityEngine;

namespace Game
{
    public sealed class UnitSpawner
    {
        private readonly UnitFactory _factory;
        private readonly IRepository<string, UnitConfig> _unitRepository;
        private readonly GameConfig _gameConfig;
        private readonly Transform _playerSpot;
        private readonly Transform _enemySpot;

        public UnitSpawner(UnitFactory factory, IRepository<string, UnitConfig> unitRepository, GameConfig gameConfig, Transform playerSpot, Transform enemySpot)
        {
            _factory = factory;
            _unitRepository = unitRepository;
            _gameConfig = gameConfig;
            _playerSpot = playerSpot;
            _enemySpot = enemySpot;
        }

        public UnitController SpawnDefaultPlayer()
        {
            UnitConfig config = _unitRepository.Get(_gameConfig.DefaultPlayerUnitId);
            UnitModel model = new UnitModel(config.Id, config.Damage, config.Health, _playerSpot.position, Vector3.zero, Vector3.zero, config.Speed, config.FireRate, config.ProjectileSpeed);

            return _factory.CreatePlayer(model, config.Prefab, _playerSpot, _gameConfig.PlayerTeamConfig);
        }

        public UnitController SpawnRandomEnemy()
        {
            UnitConfig config = RandomUtils.GetRandomElement(_unitRepository.GetAll().ToArray());
            UnitModel model = new UnitModel(config.Id, config.Damage, config.Health, _enemySpot.position, RandomUtils.GetRandomDirectionInCircle(), Vector3.zero, config.Speed, config.FireRate, config.ProjectileSpeed);

            return _factory.CreateEnemy(model, config.Prefab, _enemySpot, _gameConfig.EnemyTeamConfig);
        }

        public UnitController SpawnPlayer(UnitModel model)
        {
            UnitConfig config = _unitRepository.Get(model.Id);
            return _factory.CreatePlayer(model, config.Prefab, _playerSpot, _gameConfig.PlayerTeamConfig);
        }

        public UnitController SpawnEnemy(UnitModel model)
        {
            UnitConfig config = _unitRepository.Get(model.Id);
            return _factory.CreateEnemy(model, config.Prefab, _enemySpot, _gameConfig.EnemyTeamConfig);
        }
    }
}
