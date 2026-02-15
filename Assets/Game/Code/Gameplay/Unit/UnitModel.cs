using System;
using UnityEngine;

namespace Game
{
    public sealed class UnitModel
    {
        public event Action<int> HealthChangedEvent;

        private string _id;
        private int _damage;
        private int _health;
        private Vector3 _position;
        private Vector3 _velocityDirection;
        private Vector3 _faceDirection;
        private float _speed;
        private float _fireRate;
        private float _projectileSpeed;

        public string Id => _id;
        public int Damage => _damage;
        public int Health => _health;
        public Vector3 Position => _position;
        public Vector3 VelocityDirection => _velocityDirection;
        public Vector3 FaceDirection => _faceDirection;
        public float Speed => _speed;
        public float FireRate => _fireRate;
        public float ProjectileSpeed => _projectileSpeed;


        public UnitModel(string id, int damage, int health, Vector3 position, Vector3 velocityDirection, Vector3 faceDirection, float speed, float fireRate, float projectileSpeed)
        {
            _id = id;
            _damage = damage;
            _health = health;
            _position = position;
            _velocityDirection = velocityDirection;
            _faceDirection = faceDirection;
            _speed = speed;
            _fireRate = fireRate;
            _projectileSpeed = projectileSpeed;
        }

        public void ApplyDamage(int damage)
        {
            if (IsDead()) return;

            _health = Math.Max(0, _health - damage);
            HealthChangedEvent?.Invoke(_health);
        }

        public bool IsDead()
        {
            return _health == 0;
        }

        public void SetPosition(Vector3 position)
        {
            _position = position;
        }

        public void SetVelocityDirection(Vector3 direction)
        {
            _velocityDirection = direction;
        }

        public void ApplyVelocity(Vector3 velocity)
        {
            _position += velocity;
            _velocityDirection = velocity.normalized;
        }

        public void SetFaceDirection(Vector3 direction)
        {
            _faceDirection = direction;
        }

        public Vector3 GetFaceDirection()
        {
            return _faceDirection;
        }
    }
}
