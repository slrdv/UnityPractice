using System;

namespace Game
{
    public sealed class UnitHealthSystem : IDamageReciever
    {
        public event Action<int> ApplyDamgeEvent;

        public void ApplyDamage(int damage)
        {
            ApplyDamgeEvent?.Invoke(damage);
        }
    }
}
