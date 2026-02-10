using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace Game
{
    public sealed class GameTickService : IGameTickRegistry, IStartable, ITickable, IFixedTickable
    {
        private List<IGameTickable> _tickables = new();
        private List<IFixedGameTickable> _fixedTickables = new();

        private bool _paused = true;

        public void Register(IGameTickListener tickable)
        {
            if (tickable is IGameTickable t) _tickables.Add(t);
            if (tickable is IFixedGameTickable ft) _fixedTickables.Add(ft);
        }

        public void Unregister(IGameTickListener tickable)
        {
            if (tickable is IGameTickable t) _tickables.Remove(t);
            if (tickable is IFixedGameTickable ft) _fixedTickables.Remove(ft);
        }

        public void StartTick()
        {
            _paused = false;
        }

        public void StopTick()
        {
            _paused = true;
        }

        public void Start()
        {
            Physics.simulationMode = SimulationMode.Script;
            StartTick();
        }

        public void Tick()
        {
            if (_paused) return;

            float delta = Time.deltaTime;
            for (int i = 0; i < _tickables.Count; ++i)
            {
                _tickables[i].Tick(delta);
            }
        }

        public void FixedTick()
        {
            if (_paused) return;

            float delta = Time.fixedDeltaTime;
            for (int i = 0; i < _fixedTickables.Count; ++i)
            {
                _fixedTickables[i].FixedTick(delta);
            }

            Physics.Simulate(delta);
        }
    }
}
