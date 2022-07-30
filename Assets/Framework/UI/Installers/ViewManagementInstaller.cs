using UI.Framework.UI.DI;
using UI.Framework.UI.DI.Binding;
using UI.Framework.UI.DI.Provider;
using UI.Framework.UI.Managers;
using Utils.Framework.Utils.Installers;
using Zenject;

namespace UI.Framework.UI.Installers
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