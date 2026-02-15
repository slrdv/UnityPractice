using UnityEngine;

namespace Game
{
    public sealed class UnitDamageComponent : MonoBehaviour
    {
        private IDamageReciever _damageReciever;
        private string _teamId;

        public string TeamId => _teamId;

        public void Initialize(IDamageReciever damageReciever, string teamId)
        {
            _damageReciever = damageReciever;
            _teamId = teamId;
        }

        public bool ApplyDamage(int damage, string damageSourceteamId)
        {
            if (_teamId == damageSourceteamId) return false;

            _damageReciever.ApplyDamage(damage);
            return true;
        }
    }
}
