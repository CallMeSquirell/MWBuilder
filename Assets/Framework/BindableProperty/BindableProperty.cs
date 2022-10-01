using System;

namespace Utils.Framework.Property
{
    public interface IBindableProperty<out T>
    {
        T Value { get; }
        void AddListener(Action<T> listener, bool silent = false);
        void RemoveListener(Action<T> listener);
    }

    public class BindableProperty<T> : IBindableProperty<T>
    {
        public event Action<T> Changed;
        
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                Changed?.Invoke(_value);
            }
        }

        public BindableProperty(T value)
        {
            _value = value;
        }
        
        public BindableProperty()
        {
            _value = default;
        }

        public void AddListener(Action<T> listener, bool silent = false)
        {
            if (listener == null)
            {
                return;
            }
            
            Changed += listener;
            
            if (!silent)
            {
                listener.Invoke(_value);
            }
        }

        public void RemoveListener(Action<T> listener)
        {
            if (listener == null)
            {
                return;
            }
            
            Changed += listener;
        }
    }
}