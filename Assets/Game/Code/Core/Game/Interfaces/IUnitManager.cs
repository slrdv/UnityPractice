namespace Game
{
    public interface IUnitManager
    {
        void SpawnDefaultUnits();
        void RestoreUnits(UnitModel playerModel, UnitModel enemyModel);
        void DestroyUnits();
    }
}
