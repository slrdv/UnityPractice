using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(UnitDamageComponent))]
    public sealed class UnitView : MonoBehaviour
    {
        [SerializeField]
        private Transform _firePoint;

        private UnitDamageComponent _damageComponent;

        public void Intitialze(IDamageReciever damageReciever, string teamId)
        {
            _damageComponent.Initialize(damageReciever, teamId);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void LookAt(Vector3 direction)
        {
            transform.forward = direction;
        }

        public Vector3 GetFirePoint()
        {
            return _firePoint.position;
        }

        private void Awake()
        {
            _damageComponent = GetComponent<UnitDamageComponent>();
        }
    }
}
