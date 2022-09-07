using Commands.Framework.Core;
using Framework.UI.Animations.Scripts.UI.Core.Views;
using Project.Scripts.Core.Cells.Factory;
using UI.Framework.DI.Binding;
using UI.Framework.Installers;

namespace Project.Scripts.Core
{
    public class CoreUIInstaller : MVPInstaller
    {
        public CoreUIInstaller(IPresenterContainer presenterContainer, ICommandBinder commandBinder) : base(presenterContainer, commandBinder)
        {
        }

        protected override void InstallPresenters(IPresenterContainer presenterContainer)
        {
            presenterContainer.BindView<CoreScreenView>().To<CoreScreenPresenter>();
        }

        protected override void InstallCommon()
        {
            Container.Bind<ICellViewFactory>().To<CellViewFactory>().AsSingle();
        }
    }
}