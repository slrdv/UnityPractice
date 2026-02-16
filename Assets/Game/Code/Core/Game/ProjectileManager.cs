using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public sealed class ProjectileManager : IProjectileManager
    {
        private readonly ProjectileFactory _projectileFactory;
        private readonly IProjectileRegistry _projectileRegistry;
        private readonly IGameTickRegistry _tickRegistry;

        public ProjectileManager(ProjectileFactory projectileFactory, IProjectileRegistry projectileRegistry, IGameTickRegistry tickRegistry)
        {
            _projectileFactory = projectileFactory;
            _projectileRegistry = projectileRegistry;
            _tickRegistry = tickRegistry;
        }

        public void Fire(int damage, float speed, string teamId, Color color, Vector3 position, Vector3 direction)
        {
            ProjectileController projectile = _projectileFactory.Create(damage, speed, position, direction, teamId, color);
            RegisterProjectile(projectile);
        }

        public void RestoreProjectiles(ProjectileModel[] models)
        {
            for (int i = 0; i < models.Length; ++i)
            {
                ProjectileController projectile = _projectileFactory.Create(models[i]);
                RegisterProjectile(projectile);
            }
        }

        public void DestroyProjectiles()
        {
            IReadOnlyList<ProjectileController> projectiles = _projectileRegistry.Projectiles;
            for (int i = projectiles.Count - 1; i >= 0; --i)
            {
                DestroyProjectile(projectiles[i]);
            }

            _projectileRegistry.Clear();
        }

        private void OnProjectileHit(ProjectileController projectile, GameObject hitObject)
        {
            UnitDamageComponent damageComponent = hitObject.GetComponentInParent<UnitDamageComponent>();
            if (damageComponent != null)
            {
                if (damageComponent.ApplyDamage(projectile.Model.Damage, projectile.Model.TeamId))
                {
                    DestroyProjectile(projectile);
                }

                return;
            }

            DestroyProjectile(projectile);
        }

        private void DestroyProjectile(ProjectileController projectile)
        {
            projectile.HitEvent -= OnProjectileHit;
            _tickRegistry.Unregister(projectile);
            _projectileRegistry.Unregister(projectile);

            projectile.Dispose();
        }

        private void RegisterProjectile(ProjectileController projectile)
        {
            _projectileRegistry.Register(projectile);
            _tickRegistry.Register(projectile);
            projectile.HitEvent += OnProjectileHit;
        }
    }
}
