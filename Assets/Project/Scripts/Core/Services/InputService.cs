using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Utils.Framework.Property;

namespace Project.Scripts.Meta.Input
{
    public class InputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        private readonly BindableProperty<bool> _pressedKeyE = new();
        public IBindableProperty<bool> PressedKeyE => _pressedKeyE;
        public Vector2 Direction { get; private set; }

        public InputService()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            UpdateDirection(cancellationTokenSource.Token).Forget();
        }
        
        private async UniTask UpdateDirection(CancellationToken cancellationToken)
        {
            while (true)
            {
                var inputX = UnityEngine.Input.GetAxis(Horizontal);
                var inputY = UnityEngine.Input.GetAxis(Vertical);
                var pressedE = UnityEngine.Input.GetKeyDown(KeyCode.E);

                if (pressedE != _pressedKeyE.Value)
                {
                    _pressedKeyE.Value = pressedE;
                }
                
                Direction = new Vector2(inputX, inputY);

                await UniTask.Yield(cancellationToken);
            }
        }
    }
}