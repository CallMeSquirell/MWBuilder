using Zenject;

namespace GameStateMachine.Framework
{
    public class GameStateMachineInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }
    }
}