using UnityEngine;

namespace Game
{
    public sealed class CollisionComponent : MonoBehaviour
    {
        public event System.Action<GameObject> HitEvent;

        private void OnCollisionEnter(Collision collision)
        {
            HitEvent?.Invoke(collision.collider.gameObject);
        }

        private void OnTriggerEnter(Collider collider)
        {
            HitEvent?.Invoke(collider.gameObject);
        }
    }
}
