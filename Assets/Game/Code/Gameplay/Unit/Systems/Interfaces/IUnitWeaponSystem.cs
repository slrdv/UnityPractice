namespace Game
{
    public interface IUnitWeaponSystem
    {
        void SetFireRate(float fireRate);
        bool ProcessFire(float delta);
    }
}
