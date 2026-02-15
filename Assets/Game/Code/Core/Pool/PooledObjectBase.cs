using UnityEngine;

namespace Game
{
    public abstract class PooledObjectBase<TSelf> : MonoBehaviour where TSelf : PooledObjectBase<TSelf>
    {
        private GameObjectPool<TSelf> _pool = null;

        public void SetPool(GameObjectPool<TSelf> pool)
        {
            if (_pool != null)
            {
                Debug.LogError($"Pool is already set for {typeof(TSelf).Name}");
                return;
            }
            _pool = pool;
        }

        public void Release()
        {
            OnRelease();

            if (_pool == null)
            {
                Debug.LogError($"Pool is not set for {typeof(TSelf).Name}");
                return;
            }
            _pool.Release((TSelf)this);
        }

        public virtual void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        protected virtual void OnRelease() { }
    }
}
