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
        [SerializeField]
        private Transform _projectileRoot;

        [SerializeField]
        private HUDView _hudView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UnitRegistry>(Lifetime.Singleton).As<IUnitRegistry>();
            builder.Register<ProjectileRegistry>(Lifetime.Singleton).As<IProjectileRegistry>();

            builder.Register(r => new LevelBoundsService(_levelBounds), Lifetime.Singleton).As<ILevelBoundsService>();
            builder.Register<UnitFactory>(Lifetime.Singleton).AsSelf();
            builder.Register(r => new UnitSpawner(r.Resolve<UnitFactory>(), r.Resolve<IRepository<string, UnitConfig>>(), _gameConfig, _playerSpot, _enemySpot), Lifetime.Singleton);

            builder.Register<UnitManager>(Lifetime.Singleton).As<IUnitManager>();
            builder.Register<GameManager>(Lifetime.Singleton).As<IGameManager>();

            builder.Register(r => new GameObjectPool<ProjectileView>(r, _gameConfig.ProjectilePrefab, _projectileRoot), Lifetime.Singleton);
            builder.Register<ProjectileFactory>(Lifetime.Singleton).AsSelf();
            builder.Register<ProjectileManager>(Lifetime.Singleton).As<IProjectileManager>();

            builder.Register(r => new HudController(_hudView, r.Resolve<IUnitRegistry>()), Lifetime.Singleton).AsSelf();

            builder.RegisterEntryPoint<GameScopeInitializer>(Lifetime.Singleton);
        }
    }
}
