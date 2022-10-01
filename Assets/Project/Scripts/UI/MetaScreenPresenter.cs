using Commands.Framework.Core;
using Cysharp.Threading.Tasks;
using Project.Scripts.UI.Commands;
using UI.Framework.Views.Impl;

namespace Project.Scripts.UI.Meta
{
    public class MetaScreenPresenter : Presenter<MetaScreenView>
    {
        private readonly ICommandExecutor _commandExecutor;

        public MetaScreenPresenter(MetaScreenView view, ICommandExecutor commandExecutor) : base(view)
        {
            _commandExecutor = commandExecutor;
        }

        public override void Initialize()
        {
            View.PlayClicked += OnPlayClicked;
        }

        private void OnPlayClicked()
        {
            View.Interactable = false;
            _commandExecutor.Execute<IPlayNextLevelCommand>().Forget();
        }

        public override void Dispose()
        {
            View.PlayClicked -= OnPlayClicked;
        }
    }
}