using Commands.Framework.Core;
using Commands.Framework.Core.Impl;
using Commands.Framework.ExecutableQueue;
using Commands.Framework.ExecutableQueue.Impl;
using Zenject;

namespace Commands.Framework.Installers
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