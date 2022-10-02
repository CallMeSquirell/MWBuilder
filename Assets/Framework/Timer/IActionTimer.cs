using System;
using Utils.Framework.Property;

namespace Framework.Timer
{
    public interface IActionTimer
    {
        IBindableProperty<int> CurrentTime { get; }
        int RequiredTime { get; }
        void Start();
        void Stop();
        void Subscribe(Action action);
        void Unsubscribe(Action action);
    }
}