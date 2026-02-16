namespace Game
{
    public interface IGameSaveRepository
    {
        bool TryLoad(out GameSaveData data);
        void Save(GameSaveData data);
        void Delete();
    }
}
