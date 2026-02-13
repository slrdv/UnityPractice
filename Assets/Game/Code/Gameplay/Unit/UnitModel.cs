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
        private Vector3 _direction;
        private float _speed;
        private float _fireRate;

        public string Id => _id;
        public int Damage => _damage;
        public int Health => _health;
        public Vector3 Position => _position;
        public Vector3 Direction => _direction;
        public float Speed => _speed;
        public float FireRate => _fireRate;


        public UnitModel(string id, int damage, int health, Vector3 position, Vector3 direction, float speed, float fireRate)
        {
            _id = id;
            _damage = damage;
            _health = health;
            _position = position;
            _direction = direction;
            _speed = speed;
            _fireRate = fireRate;
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

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void ApplyVelocity(Vector3 velocity)
        {
            _position += velocity;
            _direction = velocity.normalized;
        }
    }
}
