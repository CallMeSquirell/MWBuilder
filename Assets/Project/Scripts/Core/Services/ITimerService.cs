using System;

namespace Project.Scripts.Core.Services
{
    public interface ITimerService
    {
        ITimer Register(int delay, Action action);
        void Remove(ITimer timer);
    }

    public interface ITimer
    {
        
    }
}