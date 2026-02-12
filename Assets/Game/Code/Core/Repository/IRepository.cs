using System.Collections.Generic;

namespace Game
{
    public interface IRepository<TKey, TItem>
    {
        TItem Get(TKey key);
        bool TryGet(TKey key, out TItem item);
        IReadOnlyCollection<TItem> GetAll();
        void Load();
    }
}
