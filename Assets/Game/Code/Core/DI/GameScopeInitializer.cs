using UnityEngine;
using VContainer.Unity;

namespace Game
{
    public sealed class GameScopeInitializer : IInitializable
    {
        private readonly IRepository<string, UnitConfig> _unitRepository;
        private readonly GameObjectPool<ProjectileView> _projectilePool;
        private readonly IGameSaveManager _saveManager;
        private readonly IGameSessionManager _sessionManager;
        private readonly HudController _hudManager;

        public GameScopeInitializer(
            IRepository<string, UnitConfig> unitRepository,
            GameObjectPool<ProjectileView> projectilePool,
            IGameSaveManager saveManager,
            IGameSessionManager sessionManager,
            HudController hudManager)
        {
            _unitRepository = unitRepository;
            _projectilePool = projectilePool;
            _saveManager = saveManager;
            _sessionManager = sessionManager;
            _hudManager = hudManager;
        }
        public void Initialize()
        {
            _unitRepository.Load();
            _projectilePool.Prewarm(20);
            _saveManager.LoadGameData();

            _hudManager.Initialize();

            _sessionManager.InitSession();

            Debug.Log("Game scope initialized");
        }
    }
}
