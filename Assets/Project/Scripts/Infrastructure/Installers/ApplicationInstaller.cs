using AssetManagement.Framework.Installers;
using Commands.Framework.Installers;
using Framework.UI.Animations.Scripts.UI.Core;
using GameStateMachine.Framework;
using Project.Scripts.Core;
using Project.Scripts.UI.Meta;
using UI.Framework.Installers;
using Zenject;

namespace Project.Scripts.Infrastructure.Installers
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallersSetUp();
        }

        private void InstallersSetUp()
        {
            Container.Install<ViewManagementInstaller>();
            Container.Install<CommandInstaller>();
            Container.Install<ResourceManagementInstaller>();
            Container.Install<GameStateMachineInstaller>();
            Container.Install<MetaUIInstaller>();
            Container.Install<CoreUIInstaller>();
            Container.Install<InfrastructureInstaller>();
            Container.Install<GlobalServicesInstaller>();
        }
    }
}