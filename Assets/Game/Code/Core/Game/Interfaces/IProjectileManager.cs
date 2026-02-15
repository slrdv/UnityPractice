using UnityEngine;

namespace Game
{
    public interface IProjectileManager
    {
        public void Fire(int damage, float speed, string teamId, Color color, Vector3 position, Vector3 direction);
    }
}
