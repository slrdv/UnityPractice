using UnityEngine;

namespace Game
{
    public sealed class UnitDamageComponent : MonoBehaviour
    {
        private IDamageReciever _damageReciever;

        public void SetDamageReciever(IDamageReciever damageReciever)
        {
            _damageReciever = damageReciever;
        }
    }
}
