using UnityEngine;
using VContainer.Unity;

namespace Game
{
    public sealed class GameScopeInitializer : IInitializable
    {
        private readonly IRepository<string, UnitConfig> _unitRepository;
        private readonly IGameManager _gameManager;
        private readonly GameTickService _gameTickService;

        public GameScopeInitializer(IRepository<string, UnitConfig> unitRepository, IGameManager gameManager, GameTickService gameTickService)
        {
            _unitRepository = unitRepository;
            _gameManager = gameManager;
            _gameTickService = gameTickService;
        }
        public void Initialize()
        {
            _unitRepository.Load();

            _gameManager.Start();
            _gameTickService.Start();

            Debug.Log("Game scope initialized");
        }
    }
}
