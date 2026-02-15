using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        [field: SerializeField] public string DefaultPlayerUnitId { get; private set; }
        [field: SerializeField] public TeamConfig PlayerTeamConfig { get; private set; }
        [field: SerializeField] public TeamConfig EnemyTeamConfig { get; private set; }
        [field: SerializeField] public ProjectileView ProjectilePrefab { get; private set; }
    }
}
