using UnityEngine;

namespace Game
{
    public sealed class ProjectileFactory
    {
        private readonly GameObjectPool<ProjectileView> _pool;

        public ProjectileFactory(GameObjectPool<ProjectileView> pool)
        {
            _pool = pool;
        }

        public ProjectileController Create(int damage, float speed, Vector3 position, Vector3 direction, string teamId, Color color)
        {
            ProjectileModel model = new ProjectileModel(damage, position, direction, speed, teamId, color);
            return new ProjectileController(model, _pool.Get());
        }
    }
}
