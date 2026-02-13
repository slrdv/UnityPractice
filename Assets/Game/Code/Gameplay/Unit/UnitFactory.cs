using Unity.VisualScripting;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    /// <summary>
    /// Unit factory
    /// This factory also have a composition root role
    /// </summary>
    public sealed class UnitFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly IInputProvider _inputProvider;
        private readonly ILevelBoundsService _boundsService;
        private readonly IUnitRegistry _unitRegistry;

        public UnitFactory(IObjectResolver resolver, IInputProvider inputProvider, ILevelBoundsService boundsService, IUnitRegistry unitRegistry)
        {
            _resolver = resolver;
            _inputProvider = inputProvider;
            _boundsService = boundsService;
            _unitRegistry = unitRegistry;
        }

        public UnitController CreatePlayer(UnitModel model, UnitView prefab, Transform root)
        {
            IUnitMovementSystem movementSystem = new PlayerMovementSystem(_inputProvider);
            IUnitAimSystem aimSystem = new PlayerAimSystem(_inputProvider);
            return Create(model, prefab, root, movementSystem, aimSystem);
        }

        public UnitController CreateEnemy(UnitModel model, UnitView prefab, Transform root)
        {
            IUnitMovementSystem movementSystem = new EnemyMovementSystem(_boundsService);
            IUnitAimSystem aimSystem = new EnemyAimSystem(_unitRegistry);
            return Create(model, prefab, root, movementSystem, aimSystem);
        }

        private UnitController Create(UnitModel model, UnitView prefab, Transform root, IUnitMovementSystem movementSystem, IUnitAimSystem aimSystem)
        {
            UnitView view = _resolver.Instantiate(prefab, root);
            UnitHealthSystem healthSystem = new UnitHealthSystem();
            UnitWeaponSystem weaponSystem = new UnitWeaponSystem();

            view.Intitialze(healthSystem);

            return new UnitController(model, view, healthSystem, aimSystem, weaponSystem, movementSystem);
        }
    }
}
