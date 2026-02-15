using System;
using UnityEngine;

namespace Game
{
    public sealed class ProjectileView : PooledObjectBase<ProjectileView>
    {
        public event Action<GameObject> HitEvent;

        [SerializeField]
        private CollisionComponent _collisionComponent;

        public void SetColor(Color color)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = color;
            }
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void LookAt(Vector3 direction)
        {
            transform.forward = direction;
        }

        private void OnHit(GameObject collider)
        {
            HitEvent?.Invoke(collider.gameObject);
        }

        private void Awake()
        {
            _collisionComponent.HitEvent += OnHit;
        }

        private void OnDestroy()
        {
            _collisionComponent.HitEvent -= OnHit;
        }
    }
}
