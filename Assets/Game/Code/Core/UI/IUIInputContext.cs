using System;

namespace Game
{
    public interface IUIInputContext
    {
        public event Action SaveEvent;
        public event Action ResetEvent;
        public event Action DeleteEvent;
        public event Action PauseEvent;

        void Save();
        void Reset();
        void Delete();
        void Pause();
    }
}
