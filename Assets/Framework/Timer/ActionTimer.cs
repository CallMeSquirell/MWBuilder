using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Utils.Framework.Property;

namespace Framework.Timer
{
    public class ActionTimer : IActionTimer
    {
        private readonly List<Action> _actions = new();
        private readonly int _step;
        private readonly int _requiredTime;
        private readonly BindableProperty<int> _currentTime = new();
        private CancellationTokenSource _cancellationTokenSource;

        public int RequiredTime => _requiredTime;
        public IBindableProperty<int> CurrentTime => _currentTime;

        public ActionTimer(int time, int step)
        {
            _step = step;
            _requiredTime = time;
            Reset();
        }

        public void Reset()
        {
            _currentTime.Value = _requiredTime;
        }

        public void Subscribe(Action action)
        {
            _actions.Add(action);
        }

        public void Unsubscribe(Action action)
        {
            _actions.Remove(action);
        }

        public void Start()
        {
            if (_cancellationTokenSource == null)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                UpdateLoop(_cancellationTokenSource.Token).SuppressCancellationThrow();
            }
        }

        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = null;
        }

        private async UniTask UpdateLoop(CancellationToken cancellationToken)
        {
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_step), cancellationToken: cancellationToken);

                _currentTime.Value -= _step;

                if (_currentTime.Value <= 0)
                {
                    _actions.ForEach(action => action?.Invoke());
                    _currentTime.Value = _requiredTime;
                }
            }
        }
    }
}