using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class HUDView : MonoBehaviour
    {
        public event Action SaveButtonPressed;
        public event Action ResetButtonPressed;

        [SerializeField]
        private StatsPanel _playerStatsPanel;
        [SerializeField]
        private StatsPanel _enemyStatsPanel;
        [SerializeField]
        private Button _saveButton;
        [SerializeField]
        private Button _resetButton;

        public StatsPanel PlayerStatsPanel => _playerStatsPanel;
        public StatsPanel EnemyStatsPanel => _enemyStatsPanel;

        private void OnSaveButtonPressed()
        {
            SaveButtonPressed?.Invoke();
        }

        private void OnResetButtonPressed()
        {
            ResetButtonPressed?.Invoke();
        }

        private void Awake()
        {
            _saveButton.onClick.AddListener(OnSaveButtonPressed);
            _resetButton.onClick.AddListener(OnResetButtonPressed);
        }

        private void OnDestroy()
        {
            _saveButton.onClick.RemoveListener(OnSaveButtonPressed);
            _resetButton.onClick.RemoveListener(OnResetButtonPressed);
        }
    }
}
