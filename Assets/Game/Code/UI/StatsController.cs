using System;

namespace Game
{
    public sealed class StatsController : IDisposable
    {
        private StatsPanel _statsPanelView;
        private UnitModel _model;

        public StatsController(StatsPanel statsPanelView, UnitModel model, string name)
        {
            _statsPanelView = statsPanelView;
            _model = model;

            _model.HealthChangedEvent += OnHealthChanged;

            ShowStatsPanel(name);
        }

        public void Dispose()
        {
            _model.HealthChangedEvent -= OnHealthChanged;
            _model = null;
            if (_statsPanelView != null)
            {
                _statsPanelView.Hide();
            }
        }

        private void OnHealthChanged(int health)
        {
            _statsPanelView.SetHealth(health);
        }

        private void ShowStatsPanel(string name)
        {
            _statsPanelView.SetName(name);
            _statsPanelView.SetHealth(_model.Health);
            _statsPanelView.SetDamage(_model.Damage);
            _statsPanelView.SetSpeed(_model.Speed);
            _statsPanelView.SetFireRate(_model.FireRate);

            _statsPanelView.Show();
        }
    }
}
