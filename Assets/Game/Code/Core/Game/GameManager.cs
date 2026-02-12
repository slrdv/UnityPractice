namespace Game
{
    public sealed class GameManager : IGameManager
    {
        private readonly IUnitManager _unitManager;

        public GameManager(IUnitManager unitManager)
        {
            _unitManager = unitManager;
        }

        public void Start()
        {
            _unitManager.SpawnUnits();
        }
    }
}
