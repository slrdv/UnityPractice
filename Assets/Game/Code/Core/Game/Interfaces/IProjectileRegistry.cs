using System.Collections.Generic;

namespace Game
{
    public interface IProjectileRegistry
    {
        void Register(ProjectileController projectileController);
        void Unregister(ProjectileController projectileController);
        void Clear();

        IReadOnlyList<ProjectileController> Projectiles { get; }
    }
}
