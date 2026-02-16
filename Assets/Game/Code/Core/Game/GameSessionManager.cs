using System;

namespace Game
{
    public sealed class GameSessionManager : IGameSessionManager, IDisposable
    {
        private readonly IUIInputContext _inputContext;
        private readonly IGameSaveManager _saveManager;
        private readonly IUnitManager _unitManager;
        private readonly IProjectileManager _projectileManager;
        private readonly GameTickService _gameTickService;

        public GameSessionManager(IUIInputContext inputContext, IGameSaveManager saveManager, IUnitManager unitManager, IProjectileManager projectileManager, GameTickService gameTickService)
        {
            _inputContext = inputContext;
            _saveManager = saveManager;
            _unitManager = unitManager;
            _projectileManager = projectileManager;
            _gameTickService = gameTickService;

            inputContext.SaveEvent += OnSave;
            inputContext.ResetEvent += OnReset;
            inputContext.DeleteEvent += OnDelete;
        }

        public void InitSession()
        {
            _projectileManager.DestroyProjectiles();
            _unitManager.DestroyUnits();

            if (_saveManager.HasSaveData)
            {
                _projectileManager.RestoreProjectiles(_saveManager.GetProjectileModelsFromSave());
                _unitManager.RestoreUnits(_saveManager.GetPlayerModelFromSave(), _saveManager.GetEnemyModelFromSave());
            }
            else
            {
                _unitManager.SpawnDefaultUnits();
            }

            _gameTickService.StartTick();
        }

        public void Dispose()
        {
            _inputContext.SaveEvent -= OnSave;
            _inputContext.ResetEvent -= OnReset;
            _inputContext.DeleteEvent -= OnDelete;
        }

        private void OnSave()
        {
            _saveManager.SaveGameData();
        }

        private void OnReset()
        {
            InitSession();
        }

        private void OnDelete()
        {
            _saveManager.DeleteSaveData();
        }
    }
}
