using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private GameConfig _gameConfig;
        [SerializeField]
        private Transform _playerSpot;
        [SerializeField]
        private Transform _enemySpot;
        [SerializeField]
        private BoxCollider _levelBounds;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register(r => new LevelBoundsService(_levelBounds), Lifetime.Singleton).As<ILevelBoundsService>();
            builder.Register<UnitFactory>(Lifetime.Singleton).AsSelf();
            builder.Register(r => new UnitSpawner(r.Resolve<UnitFactory>(), r.Resolve<IRepository<string, UnitConfig>>(), _gameConfig.DefaultPlayerUnitId, _playerSpot, _enemySpot), Lifetime.Singleton);

            builder.Register<UnitManager>(Lifetime.Singleton).As<IUnitManager>();
            builder.Register<GameManager>(Lifetime.Singleton).As<IGameManager>();

            builder.RegisterEntryPoint<GameScopeInitializer>(Lifetime.Singleton);
        }
    }
}
