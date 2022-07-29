using UI.Framework.UI.DI.Binding;

namespace UI.Framework.UI.Installers
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