using System;

namespace Game
{
    public interface IUnitWeaponSystem
    {
        event Action FireEvent;

        void SetFireRate(float fireRate);
        void Tick(float delta);
    }
}
