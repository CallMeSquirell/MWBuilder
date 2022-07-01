using Framework.Commands.Core;
using Framework.Commands.Core.Impl;
using Framework.Commands.ExecutableQueue;
using Framework.Commands.ExecutableQueue.Impl;
using Zenject;

namespace Framework.Commands.Installers
{
    public class CommandInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<ICommandBinder>().To<CommandBinder>();
            Container.Bind<ICommandExecutor>().To<CommandExecutor>();
            Container.Bind<ICommandFactory>().To<CommandFactory>();
            Container.Bind<ICommandQueueFactory>().To<CommandQueueFactory>();
        }
    }
}