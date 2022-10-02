using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Utils.Framework.Property;

namespace Project.Scripts.Core.Services
{
    public class TimeService : ITimerService
    {
        private List<ITimer> _list = new();
        
        public ITimer Register(int delay, Action action)
        {
            var timer = new Timer(delay, action);
            _list.Add(timer);
            return timer;
        }

        public void Remove(ITimer timer)
        {
            _list.Remove(timer);
        }
    }

    public class Timer : ITimer
    {
        private readonly Action _action;
        private readonly int _step;
        private readonly int _requiredTime;
        private readonly BindableProperty<int> _currentTime = new();

        public Timer(int time, Action action, int step = 1)
        {
            _action = action;
            _step = step;
            _requiredTime = time;
            _currentTime.Value = time;
        }
        
        
        private async UniTask UpdateLoop(CancellationToken cancellationToken)
        {
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_step), cancellationToken: cancellationToken);

                _currentTime.Value -= _step;

                if (_currentTime.Value == 0)
                {
                    _action?.Invoke();
                    _currentTime.Value = _requiredTime;
                }
            }
        }
    }
}