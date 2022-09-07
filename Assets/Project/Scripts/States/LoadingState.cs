using System.Threading;
using AssetManagement.Framework.Configs;
using Cysharp.Threading.Tasks;
using GameStateMachine.Framework;
using Project.Scripts.Infrastructure.Data;
using UI.Framework.Managers;

namespace Project.Scripts.Infrastructure.States
{
    public class LoadingState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IUIManager _uiManager;
        private readonly IConfigService _configService;

        public LoadingState(IGameStateMachine gameStateMachine,
            IUIManager uiManager, 
            IConfigService configService)
        {
            _gameStateMachine = gameStateMachine;
            _uiManager = uiManager;
            _configService = configService;
        }

        public async UniTask Enter(CancellationToken cancellationToken)
        {
            await _configService.Initialize(cancellationToken);
            await _uiManager.Initialise(cancellationToken);
            await _gameStateMachine.Enter<MetaState>(new MetaContext(), cancellationToken);
        }

        public UniTask Exit(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
    }
}