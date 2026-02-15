using UnityEngine;

namespace Game
{
    public sealed class ProjectileModel
    {
        private int _damage;
        private Vector3 _position;
        private Vector3 _direction;
        private float _speed;
        private string _teamId;
        private Color _color;

        public int Damage => _damage;
        public Vector3 Position => _position;
        public Vector3 Direction => _direction;
        public float Speed => _speed;
        public string TeamId => _teamId;
        public Color Color => _color;


        public ProjectileModel(int damage, Vector3 position, Vector3 direction, float speed, string teamId, Color color)
        {
            _damage = damage;
            _position = position;
            _direction = direction;
            _speed = speed;
            _teamId = teamId;
            _color = color;
        }

        public void Move(float delta)
        {
            _position += _direction * _speed * delta;
        }
    }
}
