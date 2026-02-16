namespace Game
{
    public interface IGameSaveManager
    {
        bool HasSaveData { get; }
        void LoadGameData();
        void SaveGameData();
        void DeleteSaveData();
        UnitModel GetPlayerModelFromSave();
        UnitModel GetEnemyModelFromSave();
        ProjectileModel[] GetProjectileModelsFromSave();
    }
}
