using System;

namespace Game
{
    [Serializable]
    public sealed class GameSaveData
    {
        public UnitData playerData;
        public UnitData enemyData;
        public ProjectileData[] projectiles;
    }
}
