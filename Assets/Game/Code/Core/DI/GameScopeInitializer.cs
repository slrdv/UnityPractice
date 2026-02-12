using UnityEngine;
using VContainer.Unity;

namespace Game
{
    public sealed class GameScopeInitializer : IInitializable
    {
        private readonly IRepository<string, UnitConfig> _unitRepository;
        private readonly IGameManager _gameManager;

        public GameScopeInitializer(IRepository<string, UnitConfig> unitRepository, IGameManager gameManager)
        {
            _unitRepository = unitRepository;
            _gameManager = gameManager;
        }
        public void Initialize()
        {
            _unitRepository.Load();

            _gameManager.Start();

            Debug.Log("Game scope initialized");
        }
    }
}
