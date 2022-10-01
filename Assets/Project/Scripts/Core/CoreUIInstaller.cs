using Commands.Framework.Core;
using Framework.UI.Animations.Scripts.UI.Core.Views;
using Project.Scripts.Core.Services;
using Project.Scripts.Meta.Input;
using UI.Framework.DI.Binding;
using UI.Framework.Installers;

namespace Project.Scripts.Core
{
    public class CoreUIInstaller : MVPInstaller
    {
        public CoreUIInstaller(IPresenterContainer presenterContainer, ICommandBinder commandBinder) : base(presenterContainer, commandBinder)
        {
        }

        protected override void InstallPresenters(IPresenterContainer presenterContainer)
        {
            presenterContainer.BindView<CoreScreenView>().To<CoreScreenPresenter>();
        }

        protected override void InstallServices()
        {
            Container.Bind<IInputService>().To<InputService>().AsSingle();
            Container.Bind<IPlayerChangeService>().To<PlayerChangeService>().AsSingle();
        }
    }
}