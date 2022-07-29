using Commands.Framework.Commands.Core;
using Commands.Framework.Commands.Core.Impl;
using Commands.Framework.Commands.ExecutableQueue;
using Commands.Framework.Commands.ExecutableQueue.Impl;
using Zenject;

namespace Commands.Framework.Commands.Installers
{
    public class CommandInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<ICommandBinder>().To<CommandBinder>().AsSingle();
            Container.Bind<ICommandExecutor>().To<CommandExecutor>().AsSingle();
            Container.Bind<ICommandFactory>().To<CommandFactory>().AsSingle();
            Container.Bind<ICommandQueueFactory>().To<CommandQueueFactory>().AsSingle();
        }
    }
}