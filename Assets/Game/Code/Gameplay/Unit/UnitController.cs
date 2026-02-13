using System;
using UnityEngine;

namespace Game
{
    public sealed class UnitController : IDisposable, IGameTickable
    {
        private readonly UnitModel _model;
        private readonly UnitView _view;
        private readonly UnitHealthSystem _healthSystem;
        private readonly IUnitAimSystem _aimSystem;
        private readonly UnitWeaponSystem _weaponSystem;
        private readonly IUnitMovementSystem _movementSystem;

        public UnitView View => _view;
        public UnitModel Model => _model;

        public UnitController(UnitModel model, UnitView view, UnitHealthSystem healthSystem, IUnitAimSystem aimSystem, UnitWeaponSystem weaponSystem, IUnitMovementSystem movementSystem)
        {
            _model = model;
            _view = view;
            _healthSystem = healthSystem;
            _aimSystem = aimSystem;
            _weaponSystem = weaponSystem;
            _movementSystem = movementSystem;

            healthSystem.ApplyDamgeEvent += OnApplyDamage;

            weaponSystem.SetFireRate(model.FireRate);
            weaponSystem.FireEvent += OnFire;

            model.HealthChangedEvent += HealthChanged;
        }

        public void Tick(float delta)
        {
            ApplyVelocity(_movementSystem.CalculateMovement(delta, _model.Position, _model.Direction, _model.Speed));
            ApplyRotation(_aimSystem.CalculateRotation(_model.Position));

            _weaponSystem.Tick(delta);
        }

        public void Dispose()
        {
            _healthSystem.ApplyDamgeEvent -= OnApplyDamage;
            _weaponSystem.FireEvent -= OnFire;

            _model.HealthChangedEvent -= HealthChanged;

            _aimSystem.Dispose();
        }

        private void ApplyVelocity(Vector3 velocity)
        {
            _model.ApplyVelocity(velocity);
            _view.SetPosition(_model.Position);
        }

        private void ApplyRotation(Vector3 rotation)
        {
            _model.SetRotation(rotation);
            _view.SetRotation(rotation);
        }

        private void OnFire()
        {
            _view.Fire(_model.Damage);
        }

        private void OnApplyDamage(int damage)
        {
            _model.ApplyDamage(damage);
        }

        private void HealthChanged(int health)
        {

        }
    }
}
