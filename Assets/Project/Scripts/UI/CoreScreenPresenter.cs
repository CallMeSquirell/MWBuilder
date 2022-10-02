using Commands.Framework.Core;
using Cysharp.Threading.Tasks;
using Project.Scripts.Core;
using Project.Scripts.Core.Services;
using Project.Scripts.UI.Commands;
using UI.Framework.Views.Impl;

namespace Framework.UI.Animations.Scripts.UI.Core.Views
{
    public class CoreScreenPresenter : Presenter<CoreScreenView>
    {
        private readonly IPlayerService _playerService;
        private readonly IUITutorialService _tutorialService;
        private readonly ICommandExecutor _commandExecutor;

        public CoreScreenPresenter(CoreScreenView view, IPlayerService playerService, IUITutorialService tutorialService, ICommandExecutor commandExecutor) : base(view)
        {
            _playerService = playerService;
            _tutorialService = tutorialService;
            _commandExecutor = commandExecutor;
        }

        public override void Initialize()
        {
            _playerService.TimeLeft.AddListener(View.UpdateTimer);
            _tutorialService.PortalHelper.AddListener(View.OnPortalHelperChanged);
            View.SettingsClicked += OnSettingsClicked;
        }

        private void OnSettingsClicked()
        {
            _commandExecutor.Execute<IPauseCommand>().Forget();
        }

        public override void Dispose()
        {
            _playerService.TimeLeft.RemoveListener(View.UpdateTimer);
            _tutorialService.PortalHelper.RemoveListener(View.OnPortalHelperChanged);
            View.SettingsClicked -= OnSettingsClicked;
        }
    }
}