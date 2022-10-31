using System;

namespace Utils
{
    public struct GameEvent
    {
        public event Action m_Action;

        public void Invoke()
        {
            m_Action?.Invoke();
        }

        public void AddListener(Action action)
        {
            m_Action += action;
        }

        public void RemoveListener(Action action)
        {
            m_Action -= action;
        }
    }
    
    public struct GameEvent<T>
    {
        public event Action<T> m_Action;

        public void Invoke(T data)
        {
            m_Action?.Invoke(data);
        }

        public void AddListener(Action<T> action)
        {
            m_Action += action;
        }

        public void RemoveListener(Action<T> action)
        {
            m_Action -= action;
        }
    }
}