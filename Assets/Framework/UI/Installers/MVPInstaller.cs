using Commands.Framework.Core;
using UI.Framework.DI.Binding;

namespace UI.Framework.Installers
{
    public abstract class MVPInstaller : Zenject.Installer
    {
        private readonly IPresenterContainer _presenterContainer;
        private readonly ICommandBinder _commandBinder;

        protected MVPInstaller(IPresenterContainer presenterContainer, ICommandBinder commandBinder)
        {
            _presenterContainer = presenterContainer;
            _commandBinder = commandBinder;
        }

        public sealed override void InstallBindings()
        {
            InstallCommon();
            InstallServices();
            InstallModels();
            InstallWatchers();
            InstallPresenters(_presenterContainer);
            InstallCommands(_commandBinder);
        }

        protected virtual void InstallServices()
        {
           
        }
        
        protected virtual void InstallWatchers()
        {
           
        }
        
        protected virtual void InstallCommon()
        {
           
        }

        protected virtual void InstallPresenters(IPresenterContainer presenterContainer)
        {
            
        }
        
        protected virtual void InstallCommands(ICommandBinder commandBinder)
        {
            
        }

        protected virtual void InstallModels()
        {
            
        }
    }
}