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
        private readonly IUnitWeaponSystem _weaponSystem;
        private readonly IUnitMovementSystem _movementSystem;
        private readonly TeamConfig _teamConfig;
        private readonly IProjectileManager _fireManager;

        public UnitView View => _view;
        public UnitModel Model => _model;

        public UnitController(UnitModel model, UnitView view, UnitHealthSystem healthSystem, IUnitAimSystem aimSystem, IUnitWeaponSystem weaponSystem, IUnitMovementSystem movementSystem, TeamConfig teamConfig, IProjectileManager fireManager)
        {
            _model = model;
            _view = view;
            _healthSystem = healthSystem;
            _aimSystem = aimSystem;
            _weaponSystem = weaponSystem;
            _movementSystem = movementSystem;
            _teamConfig = teamConfig;
            _fireManager = fireManager;

            healthSystem.ApplyDamgeEvent += OnApplyDamage;

            _movementSystem.SetSpeed(model.Speed);
            weaponSystem.SetFireRate(model.FireRate);

            model.HealthChangedEvent += HealthChanged;

            ApplyFaceDirection(model.FaceDirection);
            _view.SetPosition(model.Position);
            _view.SetColor(teamConfig.TeamColor);
        }

        public void Tick(float delta)
        {
            ApplyVelocity(_movementSystem.CalculateMovement(delta, _model.Position, _model.VelocityDirection));
            ApplyFaceDirection(_aimSystem.CalculateFaceDirection(_model.Position));
            ProcessFire(delta);
        }

        public void Dispose()
        {
            _healthSystem.ApplyDamgeEvent -= OnApplyDamage;
            _model.HealthChangedEvent -= HealthChanged;
            _view.DestroyView();
        }

        private void ApplyVelocity(Vector3 velocity)
        {
            _model.ApplyVelocity(velocity);
            _view.SetPosition(_model.Position);
        }

        private void ApplyFaceDirection(Vector3 direction)
        {
            if (direction.sqrMagnitude < MathConstants.EPSILON) return;

            _model.SetFaceDirection(direction);
            _view.LookAt(direction);
        }

        private void ProcessFire(float deltaTime)
        {
            if (_weaponSystem.ProcessFire(deltaTime))
            {
                _fireManager.Fire(_model.Damage, _model.ProjectileSpeed, _teamConfig.TeamId, _teamConfig.TeamColor, _view.GetFirePoint(), _model.GetFaceDirection());
            }
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
