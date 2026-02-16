using System;

namespace Game
{
    public sealed class HudController : IDisposable
    {
        private readonly HUDView _hudView;
        private readonly IUnitRegistry _unitRegistry;
        private readonly IUIInputContext _inputContext;

        private StatsController _playerStatsController;
        private StatsController _enemyStatsController;

        public HudController(HUDView hudView, IUnitRegistry unitRegistry, IUIInputContext inputContext)
        {
            _hudView = hudView;
            _unitRegistry = unitRegistry;
            _inputContext = inputContext;

            unitRegistry.PlayerRegisteredEvent += OnPlayerRegistered;
            unitRegistry.EnemyRegisteredEvent += OnEnemyRegistered;
            unitRegistry.PlayerUnregisteredEvent += OnPlayerUnregistered;
            unitRegistry.EnemyUnregisteredEvent += OnEnemyUnregistered;

            _hudView.SaveButtonPressed += OnSavePressed;
            _hudView.ResetButtonPressed += OnResetPressed;
            _hudView.DeleteButtonPressed += OnDeleteSavePressed;
            _hudView.PauseButtonPressed += OnPausePressed;
        }

        public void Dispose()
        {
            _unitRegistry.PlayerRegisteredEvent -= OnPlayerRegistered;
            _unitRegistry.EnemyRegisteredEvent -= OnEnemyRegistered;
            _unitRegistry.PlayerUnregisteredEvent -= OnPlayerUnregistered;
            _unitRegistry.EnemyUnregisteredEvent -= OnEnemyUnregistered;

            _hudView.SaveButtonPressed -= OnSavePressed;
            _hudView.ResetButtonPressed -= OnResetPressed;
            _hudView.DeleteButtonPressed -= OnDeleteSavePressed;
            _hudView.PauseButtonPressed -= OnPausePressed;

            _playerStatsController?.Dispose();
            _enemyStatsController?.Dispose();
        }

        public void Initialize()
        {
            if (_unitRegistry.Player != null)
            {
                OnPlayerRegistered(_unitRegistry.Player);
            }

            if (_unitRegistry.Enemy != null)
            {
                OnEnemyRegistered(_unitRegistry.Enemy);
            }
        }

        private void OnSavePressed()
        {
            _inputContext.Save();
        }

        private void OnResetPressed()
        {
            _inputContext.Reset();
        }

        private void OnDeleteSavePressed()
        {
            _inputContext.Delete();
        }

        private void OnPausePressed()
        {
            _inputContext.Pause();
        }

        private void OnPlayerRegistered(UnitController player)
        {
            _playerStatsController?.Dispose();
            _playerStatsController = new StatsController(_hudView.PlayerStatsPanel, player.Model, "Player");
        }

        private void OnPlayerUnregistered()
        {
            _playerStatsController?.Dispose();
            _playerStatsController = null;
        }

        private void OnEnemyRegistered(UnitController enemy)
        {
            _enemyStatsController?.Dispose();
            _enemyStatsController = new StatsController(_hudView.EnemyStatsPanel, enemy.Model, "Enemy");
        }

        private void OnEnemyUnregistered()
        {
            _enemyStatsController?.Dispose();
            _enemyStatsController = null;
        }
    }
}
