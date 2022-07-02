using Framework.UI.Managers.Manager;
using Framework.UI.MVP.Installers;
using Project.Scripts.Application.StateMachine;
using Zenject;

namespace Project.Scripts.Game.Installers
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallCore();
            InstallersSetUp();
        }

        private void InstallersSetUp()
        {
            Container.Install<ViewManagementInstaller>();
            Container.Install<GlobalInstaller>();
        }

        private void InstallCore()
        {
            Container.Bind<IGameStateMachine>().To<ApplicationStateMachine>().AsSingle();
            Container.Bind<IUIManager>().To<UIManager>().AsSingle();
        }
    }
}