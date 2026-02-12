using System;
using UnityEngine;

namespace Game
{
    public sealed class UnitController : IDisposable, IGameTickable
    {
        private readonly UnitModel _model;
        private readonly UnitView _view;
        private readonly UnitHealthSystem _healthSystem;
        private readonly UnitWeaponSystem _weaponSystem;
        private readonly IUnitMovementSystem _movementSystem;

        public UnitController(UnitModel model, UnitView view, UnitHealthSystem healthSystem, UnitWeaponSystem weaponSystem, IUnitMovementSystem movementSystem)
        {
            _model = model;
            _view = view;
            _healthSystem = healthSystem;
            _weaponSystem = weaponSystem;
            _movementSystem = movementSystem;

            healthSystem.ApplyDamgeEvent += OnApplyDamage;

            weaponSystem.SetFireRate(model.FireRate);
            weaponSystem.FireEvent += OnFire;

            movementSystem.SetSpeed(model.Speed);
            movementSystem.MoveEvent += OnMove;

            model.HealthChangedEvent += HealthChanged;
        }

        public void Tick(float delta)
        {
            _movementSystem.Tick(delta);
            _weaponSystem.Tick(delta);
        }

        public void Dispose()
        {
            _healthSystem.ApplyDamgeEvent -= OnApplyDamage;
            _weaponSystem.FireEvent -= OnFire;
            _movementSystem.MoveEvent -= OnMove;

            _model.HealthChangedEvent -= HealthChanged;
        }

        private void OnFire()
        {
            _view.Fire(_model.Damage);
        }

        private void OnApplyDamage(int damage)
        {
            _model.ApplyDamage(damage);
        }

        private void OnMove(Vector3 position)
        {
            _model.SetPosition(position);
            _view.SetPosition(position);
        }


        private void HealthChanged(int health)
        {

        }
    }
}
