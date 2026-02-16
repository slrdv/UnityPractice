using System.Collections.Generic;

namespace Game
{
    public sealed class ProjectileRegistry : IProjectileRegistry
    {
        private readonly List<ProjectileController> _projectiles = new();

        public IReadOnlyList<ProjectileController> Projectiles => _projectiles;

        public void Register(ProjectileController projectileController)
        {
            _projectiles.Add(projectileController);
        }

        public void Unregister(ProjectileController projectileController)
        {
            _projectiles.Remove(projectileController);
        }

        public void Clear()
        {
            _projectiles.Clear();
        }

    }
}
