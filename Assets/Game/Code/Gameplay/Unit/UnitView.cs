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
