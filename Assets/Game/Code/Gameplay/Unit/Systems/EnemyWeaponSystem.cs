namespace Game
{
    public sealed class EnemyWeaponSystem : IUnitWeaponSystem
    {
        private readonly IUnitRegistry _registry;
        private float _fireRate;
        private float _fireTimeCounter;

        public EnemyWeaponSystem(IUnitRegistry registry)
        {
            _registry = registry;
        }

        public void SetFireRate(float fireRate)
        {
            _fireRate = fireRate;
        }

        public bool ProcessFire(float delta)
        {
            _fireTimeCounter += delta;
            if (_fireTimeCounter >= 1 / _fireRate)
            {
                _fireTimeCounter = 0f;
                return _registry.Player != null;
            }

            return false;
        }
    }
}
