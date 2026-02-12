using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "Configs/UnitConfig")]
    public sealed class UnitConfig : ScriptableObject, IHasKey<string>
    {
        public string Key => Id;

        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int FireRate { get; private set; }
        [field: SerializeField] public UnitView Prefab { get; private set; }
    }
}
