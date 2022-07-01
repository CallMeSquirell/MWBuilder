using Framework.UI.MVP.DI.Binding;

namespace Framework.UI.MVP.Installers
{
    public abstract class MVPInstaller : Zenject.Installer
    {
        private readonly IPresenterContainer _presenterContainer;

        protected MVPInstaller(IPresenterContainer presenterContainer)
        {
            _presenterContainer = presenterContainer;
        }

        public sealed override void InstallBindings()
        {
            InstallCommon();
            InstallServices();
            InstallModels();
            InstallWatchers();
            InstallPresenters(_presenterContainer);
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

        protected virtual void InstallModels()
        {
            
        }
    }
}