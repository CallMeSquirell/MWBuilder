using System.Threading;
using Cysharp.Threading.Tasks;
using Zenject;

namespace GameStateMachine.Framework.GameStateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly IInstantiator _instantiator;
        private IGameState _currentState;

        public GameStateMachine(IInstantiator instantiator)
        {
            _instantiator = instantiator;   
        }

        async UniTask IGameStateMachine.Enter<T>(CancellationToken cancellationToken) where T : class
        {
            await CloseCurrentState(cancellationToken);
            await EnterState<T>(cancellationToken);
        }

        async UniTask IGameStateMachine.Enter<T>(object context, CancellationToken cancellationToken) where T : class
        {
            await CloseCurrentState(cancellationToken);
            await EnterState<T>(cancellationToken, context);
        }
        
        private async UniTask EnterState<T>(CancellationToken cancellationToken, object payload = null) where T : class, IGameState
        {
            _currentState = payload != null ? _instantiator.Instantiate<T>(new[] { payload }) : _instantiator.Instantiate<T>();
            await _currentState.Enter(cancellationToken);
        }

        private async UniTask CloseCurrentState(CancellationToken cancellationToken)
        {
            if (_currentState != null)
            {
                await _currentState.Exit(cancellationToken);
                _currentState = null;
            }
        }
    }
}