using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(UnitDamageComponent))]
    public sealed class UnitView : MonoBehaviour
    {
        [SerializeField]
        private Transform _firePoint;
        [SerializeField]
        private Renderer _renderer;

        private UnitDamageComponent _damageComponent;

        public void Intitialze(IDamageReciever damageReciever, string teamId)
        {
            _damageComponent.Initialize(damageReciever, teamId);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void LookAt(Vector3 direction)
        {
            transform.forward = direction;
        }

        public Vector3 GetFirePoint()
        {
            return _firePoint.position;
        }

        public void SetColor(Color color)
        {
            _renderer.material.color = color;
        }

        public void DestroyView()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            _damageComponent = GetComponent<UnitDamageComponent>();
        }
    }
}
