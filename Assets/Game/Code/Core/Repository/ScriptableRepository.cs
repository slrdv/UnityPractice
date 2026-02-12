using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class ScriptableRepository<TKey, TItem> : IRepository<TKey, TItem> where TItem : ScriptableObject, IHasKey<TKey>
    {

        protected abstract string ConfigPath { get; }

        private Dictionary<TKey, TItem> _items;
        private bool _loaded = false;

        public TItem Get(TKey key)
        {
            return _items[key];
        }

        public bool TryGet(TKey key, out TItem item)
        {
            return _items.TryGetValue(key, out item);
        }

        public IReadOnlyCollection<TItem> GetAll()
        {
            return _items.Values;
        }

        public void Load()
        {
            if (_loaded) return;
            _loaded = true;

            TItem[] configs = Resources.LoadAll<TItem>(ConfigPath);
            _items = new Dictionary<TKey, TItem>(configs.Length);
            for (int i = 0; i < configs.Length; ++i)
            {
                _items[configs[i].Key] = configs[i];
            }
        }
    }
}
