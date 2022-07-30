using Commands.Framework.Commands.Core;
using Cysharp.Threading.Tasks;
using UI.Framework.UI.Views.Impl;

namespace Project.Scripts.UI.Meta
{
    public class MetaScreenPresenter : Presenter<MetaScreenView>
    {
        private readonly ICommandExecutor _commandExecutor;

        public MetaScreenPresenter(MetaScreenView view, ICommandExecutor commandExecutor) : base(view)
        {
            _commandExecutor = commandExecutor;
        }

        public override void Initialise()
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