using Project.Scripts.Core.Services;
using UI.Framework.Views.Impl;

namespace Framework.UI.Animations.Scripts.UI.Core.Views
{
    public class CoreScreenPresenter : Presenter<CoreScreenView>
    {
        private readonly IPlayerChangeService _playerChangeService;

        public CoreScreenPresenter(CoreScreenView view, IPlayerChangeService playerChangeService) : base(view)
        {
            _playerChangeService = playerChangeService;
        }

        public override void Initialize()
        {
            _playerChangeService.TimeLeft.AddListener(View.UpdateTimer);
        }

        public override void Dispose()
        {
            _playerChangeService.TimeLeft.RemoveListener(View.UpdateTimer);
        }
    }
}