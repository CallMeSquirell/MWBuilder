using System.Threading;
using Cysharp.Threading.Tasks;
using GameStateMachine.Framework.GameStateMachine;
using Project.Scripts.Infrastructure.States;
using UI.Framework.UI.Managers;

namespace Project.Scripts.Game.Impl
{
    public class LoadingState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IUIManager _uiManager;

        public LoadingState(IGameStateMachine gameStateMachine, 
            IUIManager uiManager)
        {
            _gameStateMachine = gameStateMachine;
            _uiManager = uiManager;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            await _uiManager.Initialise(cancellationToken);
            await _gameStateMachine.Enter<MetaState>(new MetaContext(), cancellationToken);
        }

        public UniTask Exit(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}