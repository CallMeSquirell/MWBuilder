using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Meta.Input;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class PlayerModel
    {
        public event Action<Vector2> DirectionChanged;
        public event Action<Vector3> Teleported;
        
        private readonly IInputService _inputService;
        public bool Locked { get; set; } = false;

        private Vector2 Direction => Locked ? Vector2.zero : _inputService.Direction;

        private CancellationTokenSource _cancellationTokenSource;

        public PlayerModel(IInputService inputService)
        {
            _inputService = inputService;
            _cancellationTokenSource = new CancellationTokenSource();
            UpdateLoop(_cancellationTokenSource.Token).SuppressCancellationThrow();
        }

        private async UniTask UpdateLoop(CancellationToken cancellationToken)
        {
            while (true)
            {
                DirectionChanged?.Invoke(Direction);
                await UniTask.Delay(TimeSpan.FromSeconds(Time.fixedDeltaTime), cancellationToken: cancellationToken);
            }
        }

        public void Teleport(Vector3 payloadPosition)
        {
            Teleported?.Invoke(payloadPosition);
        }
    }
}