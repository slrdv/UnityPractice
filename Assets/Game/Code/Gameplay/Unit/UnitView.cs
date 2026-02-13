using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(UnitDamageComponent))]
    [RequireComponent(typeof(UnitWeaponComponent))]
    public sealed class UnitView : MonoBehaviour
    {
        private UnitDamageComponent _damageComponent;
        private UnitWeaponComponent _weaponComponent;

        public void Intitialze(IDamageReciever damageReciever)
        {
            _damageComponent.SetDamageReciever(damageReciever);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRotation(Vector3 rotation)
        {
            if (rotation == Vector3.zero) return;

            Quaternion targetRotation = Quaternion.LookRotation(rotation);
            transform.rotation = targetRotation;
        }

        public void Fire(int damage)
        {
            _weaponComponent.Fire(damage);
        }

        private void Awake()
        {
            _damageComponent = GetComponent<UnitDamageComponent>();
            _weaponComponent = GetComponent<UnitWeaponComponent>();
        }
    }
}
