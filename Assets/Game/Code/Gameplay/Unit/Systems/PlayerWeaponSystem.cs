namespace Game
{
    public sealed class PlayerWeaponSystem : IUnitWeaponSystem
    {
        private readonly IInputProvider _inputProvider;

        private float _fireRate;
        private float _fireCooldown;

        public PlayerWeaponSystem(IInputProvider inputProvider)
        {
            _inputProvider = inputProvider;
        }

        public void SetFireRate(float fireRate)
        {
            _fireRate = fireRate;
        }

        public bool ProcessFire(float delta)
        {
            _fireCooldown += delta;
            if (_fireCooldown >= 1 / _fireRate)
            {
                _fireCooldown = 0f;
                return _inputProvider.GetFireButtonPressed();
            }

            return false;
        }
    }
}
