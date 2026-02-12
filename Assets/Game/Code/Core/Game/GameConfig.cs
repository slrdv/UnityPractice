using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        [field: SerializeField] public string DefaultPlayerUnitId { get; private set; }
    }
}
