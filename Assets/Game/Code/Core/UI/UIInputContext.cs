using System;

namespace Game
{
    public sealed class UIInputContext : IUIInputContext
    {
        public event Action SaveEvent;
        public event Action ResetEvent;
        public event Action DeleteEvent;
        public event Action PauseEvent;

        public void Reset()
        {
            ResetEvent?.Invoke();
        }

        public void Save()
        {
            SaveEvent?.Invoke();
        }

        public void Delete()
        {
            DeleteEvent?.Invoke();
        }

        public void Pause()
        {
            PauseEvent?.Invoke();
        }
    }
}
