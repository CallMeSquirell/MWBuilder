using UI.Framework.DI;
using UI.Framework.DI.Binding;
using UI.Framework.DI.Provider;
using UI.Framework.Managers;
using Zenject;

namespace UI.Framework.Installers
{
    public class ViewManagementInstaller : Installer
    {
        public override void InstallBindings()
        {
            InstallDI();
        }
        
        private void InstallDI()
        {
            Container.Bind<IPresenterProvider>().To<PresenterProvider>().AsSingle();
            Container.Bind<IViewFactory>().To<ViewFactory>().AsSingle();
            Container.Bind<IPresenterContainer>()
                .To<PresenterContainer>()
                .AsSingle()
                .When(context => context.ObjectType == typeof(PresenterProvider) ||
                                 context.ObjectType.IsSubclassOf(typeof(MVPInstaller)));
            Container.Bind<IUIManager>().To<UIManager>().AsSingle();
        }
    }
}