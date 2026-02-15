namespace Game
{
    public interface IProjectileRegistry
    {
        void Register(ProjectileController projectileController);
        void Unregister(ProjectileController projectileController);
    }
}
