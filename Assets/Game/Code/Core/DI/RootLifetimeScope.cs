using VContainer;
using VContainer.Unity;

namespace Game
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UnitConfigRepository>(Lifetime.Singleton).As<IRepository<string, UnitConfig>>();

            builder.Register<KeyboardInputProvider>(Lifetime.Singleton).As<IInputProvider>();
            builder.RegisterEntryPoint<GameTickService>(Lifetime.Singleton).As<IGameTickRegistry>();
        }
    }
}
