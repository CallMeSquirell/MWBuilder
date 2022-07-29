using AssetManagement.Framework.ResourceManagement.Installers;
using Commands.Framework.Commands.Installers;
using GameStateMachine.Framework.GameStateMachine;
using UI.Framework.UI.Installers;
using Zenject;

namespace Project.Scripts.Game.Installers
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
        }
    }
}