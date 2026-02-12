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


        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UnitFactory>(Lifetime.Scoped).AsSelf();
            builder.Register(r => new UnitSpawner(r.Resolve<UnitFactory>(), r.Resolve<IRepository<string, UnitConfig>>(), _gameConfig.DefaultPlayerUnitId, _playerSpot, _enemySpot), Lifetime.Scoped);

            builder.Register<UnitManager>(Lifetime.Scoped).As<IUnitManager>();
            builder.Register<GameManager>(Lifetime.Scoped).As<IGameManager>();

            builder.RegisterEntryPoint<GameScopeInitializer>(Lifetime.Scoped);
        }
    }
}
