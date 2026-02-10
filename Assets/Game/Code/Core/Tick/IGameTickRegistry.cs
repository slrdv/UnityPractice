namespace Game
{
    public interface IGameTickRegistry
    {
        void Register(IGameTickListener tickable);
        void Unregister(IGameTickListener tickable);
    }
}
