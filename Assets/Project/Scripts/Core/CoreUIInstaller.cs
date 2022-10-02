using Commands.Framework.Core;
using Framework.UI.Animations.Scripts.UI.Core.Views;
using Project.Scripts.Core.Services;
using Project.Scripts.Meta.Input;
using Project.Scripts.UI;
using Project.Scripts.UI.Commands;
using UI.Framework.DI.Binding;
using UI.Framework.Installers;

namespace Project.Scripts.Core
{
    public class CoreUIInstaller : MVPInstaller
    {
        public CoreUIInstaller(IPresenterContainer presenterContainer, ICommandBinder commandBinder) : base(
            presenterContainer, commandBinder)
        {
        }

        protected override void InstallPresenters(IPresenterContainer presenterContainer)
        {
            presenterContainer.BindView<CoreScreenView>().To<CoreScreenPresenter>();
            presenterContainer.BindView<SettingPopUpView>().To<SettingPopUpPresenter>();
        }

        protected override void InstallServices()
        {
            Container.Bind<IInputService>().To<InputService>().AsSingle();
            Container.Bind<IPlayerService>().To<PlayerService>().AsSingle();
            Container.Bind<IUITutorialService>().To<IuiTutorialService>().AsSingle();
        }

        protected override void InstallCommands(ICommandBinder commandBinder)
        {
            commandBinder.Bind<IPauseCommand>().To<PauseCommand>();
        }
    }
}