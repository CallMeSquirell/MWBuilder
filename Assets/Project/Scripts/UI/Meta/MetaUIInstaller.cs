using Commands.Framework.Commands.Core;
using UI.Framework.UI.DI.Binding;
using Utils.Framework.Utils.Installers;

namespace Project.Scripts.UI.Meta
{
    public class MetaUIInstaller : MVPInstaller
    {
        public MetaUIInstaller(IPresenterContainer presenterContainer,
            ICommandBinder commandBinder) : base(presenterContainer, commandBinder)
        {
        }

        protected override void InstallCommands(ICommandBinder commandBinder)
        {
            commandBinder.Bind<IPlayNextLevelCommand>().To<PlayNextLevelCommand>();
        }

        protected override void InstallPresenters(IPresenterContainer presenterContainer)
        {
            presenterContainer.BindView<MetaScreenView>().To<MetaScreenPresenter>();
        }
    }
}