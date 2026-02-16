using System.Collections.Generic;

namespace Game
{
    public sealed class GameSaveManager : IGameSaveManager
    {
        private readonly IGameSaveRepository _repository;
        private readonly IUnitRegistry _unitRegistry;
        private readonly IProjectileRegistry _projectileRegistry;

        private GameSaveData _gameSaveData;

        public bool HasSaveData => _gameSaveData != null;

        public GameSaveManager(IGameSaveRepository repository, IUnitRegistry unitRegistry, IProjectileRegistry projectileRegistry)
        {
            _repository = repository;
            _unitRegistry = unitRegistry;
            _projectileRegistry = projectileRegistry;
        }

        public void LoadGameData()
        {
            if (!_repository.TryLoad(out _gameSaveData))
            {
                _gameSaveData = null;
            }
        }

        public void SaveGameData()
        {
            GameSaveData data = new GameSaveData();
            if (_unitRegistry.Player != null)
            {
                data.playerData = ConvertUtils.FromModel(_unitRegistry.Player.Model);
            }

            if (_unitRegistry.Enemy != null)
            {
                data.enemyData = ConvertUtils.FromModel(_unitRegistry.Enemy.Model);
            }

            IReadOnlyList<ProjectileController> projectiles = _projectileRegistry.Projectiles;
            data.projectiles = new ProjectileData[projectiles.Count];
            for (int i = 0; i < projectiles.Count; ++i)
            {
                data.projectiles[i] = ConvertUtils.FromModel(projectiles[i].Model);
            }

            _repository.Save(data);
            _gameSaveData = data;
        }

        public void DeleteSaveData()
        {
            _repository.Delete();
            _gameSaveData = null;
        }

        public UnitModel GetPlayerModelFromSave()
        {
            if (_gameSaveData == null) return null;

            return ConvertUtils.ToModel(_gameSaveData.playerData);
        }

        public UnitModel GetEnemyModelFromSave()
        {
            if (_gameSaveData == null) return null;

            return ConvertUtils.ToModel(_gameSaveData.enemyData);
        }

        public ProjectileModel[] GetProjectileModelsFromSave()
        {
            if (_gameSaveData == null) return new ProjectileModel[0];

            ProjectileModel[] models = new ProjectileModel[_gameSaveData.projectiles.Length];
            for (int i = 0; i < _gameSaveData.projectiles.Length; ++i)
            {
                models[i] = ConvertUtils.ToModel(_gameSaveData.projectiles[i]);
            }
            return models;
        }

    }
}
