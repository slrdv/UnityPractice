using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "TeamConfig", menuName = "Configs/TeamConfig")]
    public sealed class TeamConfig : ScriptableObject
    {
        [field: SerializeField] public string TeamId { get; private set; }
        [field: SerializeField] public Color TeamColor { get; private set; }
    }
}
