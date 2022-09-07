using System.Linq;
using System.Threading;
using AssetManagement.Framework.Configs;
using Commands.Framework.BaseCommands;
using Cysharp.Threading.Tasks;
using GameStateMachine.Framework;
using Project.Scripts.Core.Configs;
using Project.Scripts.Infrastructure.Data;
using Project.Scripts.Infrastructure.States;

namespace Project.Scripts.UI.Meta
{
    public class PlayNextLevelCommand : Command, IPlayNextLevelCommand
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly LevelListConfig _levelListConfig;

        public PlayNextLevelCommand(IGameStateMachine gameStateMachine, IConfigService configService)
        {
            _gameStateMachine = gameStateMachine;
            _levelListConfig = configService.Get<LevelListConfig>();
        }

        public async UniTask Execute(CancellationToken cancellationToken = default)
        {
            var nextLevel = _levelListConfig.Levels.First();
            var context = new CoreContext()
            {
                LevelConfig = nextLevel
            };
            await _gameStateMachine.Enter<CoreState>(context, cancellationToken);
        }
    }
}