using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Game;
using Zenject;

namespace Project.Scripts.Application.StateMachine
{
    public class ApplicationStateMachine : IGameStateMachine
    {
        private readonly IInstantiator _instantiator;
        private IGameState _currentState;

        public ApplicationStateMachine(IInstantiator instantiator)
        {
            _instantiator = instantiator;   
        }

        public async UniTask Enter<T>(CancellationToken cancellationToken) where T : class, IGameState
        {
            await CloseCurrentState(cancellationToken);
            await EnterState<T>(cancellationToken);
        }
        

        private async UniTask EnterState<T>(CancellationToken cancellationToken) where T : class, IGameState
        {
            _currentState = _instantiator.Instantiate<T>();
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