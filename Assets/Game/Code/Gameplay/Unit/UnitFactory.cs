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

        public UnitFactory(IObjectResolver resolver, IInputProvider inputProvider)
        {
            _resolver = resolver;
            _inputProvider = inputProvider;
        }

        public UnitController CreatePlayer(UnitModel model, UnitView prefab, Transform root)
        {
            IUnitMovementSystem movementSystem = new PlayerMovementSystem(_inputProvider);
            return Create(model, prefab, root, movementSystem);
        }

        public UnitController CreateEnemy(UnitModel model, UnitView prefab, Transform root)
        {
            IUnitMovementSystem movementSystem = new EnemyMovementSystem();
            return Create(model, prefab, root, movementSystem);
        }

        private UnitController Create(UnitModel model, UnitView prefab, Transform root, IUnitMovementSystem movementSystem)
        {
            UnitView view = _resolver.Instantiate(prefab, root);
            UnitHealthSystem healthSystem = new UnitHealthSystem();
            UnitWeaponSystem weaponSystem = new UnitWeaponSystem();

            view.Intitialze(healthSystem);

            return new UnitController(model, view, healthSystem, weaponSystem, movementSystem);
        }
    }
}
