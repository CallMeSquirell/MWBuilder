using Commands.Framework.Core;
using Project.Scripts.UI.Commands;
using UI.Framework.DI.Binding;
using UI.Framework.Installers;

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