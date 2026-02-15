using UnityEngine;
using VContainer.Unity;

namespace Game
{
    public sealed class GameScopeInitializer : IInitializable
    {
        private readonly IRepository<string, UnitConfig> _unitRepository;
        private readonly IGameManager _gameManager;
        private readonly GameTickService _gameTickService;
        private readonly GameObjectPool<ProjectileView> _projectilePool;
        private readonly HudController _hudManager;

        public GameScopeInitializer(IRepository<string, UnitConfig> unitRepository, IGameManager gameManager, GameTickService gameTickService, GameObjectPool<ProjectileView> projectilePool, HudController hudManager)
        {
            _unitRepository = unitRepository;
            _gameManager = gameManager;
            _gameTickService = gameTickService;
            _projectilePool = projectilePool;
            _hudManager = hudManager;
        }
        public void Initialize()
        {
            _unitRepository.Load();
            _projectilePool.Prewarm(20);

            _hudManager.Initialize();

            _gameManager.Start();
            _gameTickService.Start();

            Debug.Log("Game scope initialized");
        }
    }
}
