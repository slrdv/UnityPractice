using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class UnitData
    {
        public string id;
        public int damage;
        public int health;
        public Vector3 position;
        public Vector3 velocityDirection;
        public Vector3 faceDirection;
        public float speed;
        public float fireRate;
        public float projectileSpeed;
    }
}
