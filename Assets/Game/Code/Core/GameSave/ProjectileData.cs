using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class ProjectileData
    {
        public int damage;
        public Vector3 position;
        public Vector3 direction;
        public float speed;
        public string teamId;
        public Color color;
    }
}
