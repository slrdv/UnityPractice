using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public sealed class UnitFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly IInputProvider _inputProvider;
        private readonly ILevelBoundsService _boundsService;
        private readonly IUnitRegistry _unitRegistry;
        private readonly IProjectileManager _fireManager;

        public UnitFactory(IObjectResolver resolver, IInputProvider inputProvider, ILevelBoundsService boundsService, IUnitRegistry unitRegistry, IProjectileManager fireManager)
        {
            _resolver = resolver;
            _inputProvider = inputProvider;
            _boundsService = boundsService;
            _unitRegistry = unitRegistry;
            _fireManager = fireManager;
        }

        public UnitController CreatePlayer(UnitModel model, UnitView prefab, Transform root, TeamConfig teamConfig)
        {
            IUnitMovementSystem movementSystem = new PlayerMovementSystem(_inputProvider, _boundsService);
            IUnitAimSystem aimSystem = new PlayerAimSystem(_inputProvider);
            IUnitWeaponSystem weaponSystem = new PlayerWeaponSystem(_inputProvider);
            UnitHealthSystem healthSystem = new UnitHealthSystem();

            UnitView view = _resolver.Instantiate(prefab, root);
            view.Intitialze(healthSystem, teamConfig.TeamId);

            return new UnitController(model, view, healthSystem, aimSystem, weaponSystem, movementSystem, teamConfig, _fireManager);
        }

        public UnitController CreateEnemy(UnitModel model, UnitView prefab, Transform root, TeamConfig teamConfig)
        {
            IUnitMovementSystem movementSystem = new EnemyMovementSystem(_boundsService);
            IUnitAimSystem aimSystem = new EnemyAimSystem(_unitRegistry);
            UnitHealthSystem healthSystem = new UnitHealthSystem();
            IUnitWeaponSystem weaponSystem = new EnemyWeaponSystem(_unitRegistry);

            UnitView view = _resolver.Instantiate(prefab, root);
            view.Intitialze(healthSystem, teamConfig.TeamId);

            return new UnitController(model, view, healthSystem, aimSystem, weaponSystem, movementSystem, teamConfig, _fireManager);
        }
    }
}
