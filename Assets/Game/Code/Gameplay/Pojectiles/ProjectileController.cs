using System;
using UnityEngine;

namespace Game
{
    public sealed class ProjectileController : IGameTickable, IDisposable
    {
        public event Action<ProjectileController, GameObject> HitEvent;
        private readonly ProjectileModel _model;
        private readonly ProjectileView _view;

        public ProjectileModel Model => _model;
        public ProjectileView View => _view;

        public ProjectileController(ProjectileModel model, ProjectileView view)
        {
            _model = model;
            _view = view;

            _view.HitEvent += OnHit;
        }

        public void Tick(float delta)
        {
            _model.Move(delta);
            _view.LookAt(_model.Direction);
            _view.SetPosition(_model.Position);
        }

        public void Dispose()
        {
            _view.HitEvent -= OnHit;
            _view.Release();
        }

        private void OnHit(GameObject hitObject)
        {
            HitEvent?.Invoke(this, hitObject);
        }
    }
}
