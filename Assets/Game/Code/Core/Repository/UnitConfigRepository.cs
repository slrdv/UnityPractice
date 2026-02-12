namespace Game
{
    public sealed class UnitConfigRepository : ScriptableRepository<string, UnitConfig>
    {
        protected override string ConfigPath => PathConstants.UNIT_CONFIG_PATH;
    }
}
