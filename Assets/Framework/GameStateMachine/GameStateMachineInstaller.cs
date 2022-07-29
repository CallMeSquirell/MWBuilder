using Zenject;

namespace GameStateMachine.Framework.GameStateMachine
{
    public class GameStateMachineInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }
    }
}