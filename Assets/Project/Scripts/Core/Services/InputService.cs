using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Project.Scripts.Meta.Input
{
    public class InputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        
        public Vector2 Direction { get; private set; }

        private CancellationTokenSource _cancellationTokenSource;

        public InputService()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            //UpdateDirection(_cancellationTokenSource.Token).Forget();
        }
        
        private async UniTask UpdateDirection(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var inputX = UnityEngine.Input.GetAxis(Horizontal);
                var inputY = UnityEngine.Input.GetAxis(Vertical);

                Direction = new Vector2(inputX, inputY);

                await UniTask.Yield(cancellationToken);
            }
        }
    }
}