using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public sealed class GameObjectPool<T> where T : PooledObjectBase<T>
    {
        private readonly T _prefab;
        private readonly Transform _container;
        private readonly IObjectResolver _objectResolver;
        private readonly int _maxPoolSize;

        private readonly Stack<T> _pool;

        public GameObjectPool(IObjectResolver objectResolver, T prefab, Transform container, int maxPoolSize = 100, int defaultCapacity = 10)
        {
            _objectResolver = objectResolver;
            _prefab = prefab;
            _container = container;
            _maxPoolSize = maxPoolSize;

            _pool = new Stack<T>(defaultCapacity);
        }

        public T Get()
        {
            T obj = _pool.Count > 0 ? _pool.Pop() : Create();
            obj.SetActive(true);
            return obj;
        }

        public void Release(T obj)
        {
            obj.SetActive(false);

            if (_pool.Count >= _maxPoolSize)
            {
                Object.Destroy(obj.gameObject);
                return;
            }

            _pool.Push(obj);
        }

        public void Prewarm(int amount)
        {
            amount = Mathf.Min(amount, _maxPoolSize - _pool.Count);
            List<T> prewarm = new List<T>(amount);

            for (int i = 0; i < amount; ++i)
            {
                prewarm.Add(Get());
            }

            for (int i = 0; i < amount; ++i)
            {
                Release(prewarm[i]);
            }
        }

        private T Create()
        {
            T obj = _objectResolver.Instantiate(_prefab, _container);
            obj.SetActive(false);
            obj.SetPool(this);
            return obj;
        }
    }
}
