using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public sealed class HUDView : MonoBehaviour
    {
        public event Action SaveButtonPressed;
        public event Action ResetButtonPressed;
        public event Action DeleteButtonPressed;

        [SerializeField]
        private StatsPanel _playerStatsPanel;
        [SerializeField]
        private StatsPanel _enemyStatsPanel;
        [SerializeField]
        private Button _saveButton;
        [SerializeField]
        private Button _resetButton;
        [SerializeField]
        private Button _deleteButton;

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

        private void OnDeleteButtonPressed()
        {
            DeleteButtonPressed?.Invoke();
        }

        private void Awake()
        {
            _saveButton.onClick.AddListener(OnSaveButtonPressed);
            _resetButton.onClick.AddListener(OnResetButtonPressed);
            _deleteButton.onClick.AddListener(OnDeleteButtonPressed);
        }

        private void OnDestroy()
        {
            _saveButton.onClick.RemoveListener(OnSaveButtonPressed);
            _resetButton.onClick.RemoveListener(OnResetButtonPressed);
            _deleteButton.onClick.RemoveListener(OnDeleteButtonPressed);
        }
    }
}
