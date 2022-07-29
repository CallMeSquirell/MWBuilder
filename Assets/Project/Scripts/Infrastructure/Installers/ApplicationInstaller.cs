using Framework.ResourceManagement;
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
        }

        private void InstallCore()
        {
            Container.Bind<IGameStateMachine>().To<ApplicationStateMachine>().AsSingle();
            Container.Bind<IAssetManager>().To<AssetManager>().AsSingle();
            Container.Bind<IConfigService>().To<ConfigService>().AsSingle();
            Container.Bind<IUIManager>().To<UIManager>().AsSingle();
        }
    }
}