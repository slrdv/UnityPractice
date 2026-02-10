namespace Game
{
    public interface IGameTickListener { };

    public interface IGameTickable : IGameTickListener
    {
        public void Tick(float delta);
    }

    public interface IFixedGameTickable : IGameTickListener
    {
        public void FixedTick(float delta);
    }
}
