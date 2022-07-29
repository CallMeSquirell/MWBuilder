using System.Threading;
using Cysharp.Threading.Tasks;
using Framework.UI.Managers.Manager;

namespace Project.Scripts.Game.Impl
{
    public class LoadingState : BaseState
    {
        private readonly IUIManager _uiManager;

        protected LoadingState(IGameStateMachine gameStateMachine, 
            IUIManager uiManager) : base(gameStateMachine)
        {
            _uiManager = uiManager;
        }

        public override async UniTask Enter(CancellationToken cancellationToken)
        {
            await _uiManager.Initialise(cancellationToken);
            await GameStateMachine.Enter<MetaState>(cancellationToken);
        }
    }
}