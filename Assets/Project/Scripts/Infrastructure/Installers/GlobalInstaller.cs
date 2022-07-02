using Framework.UI.MVP.DI.Binding;
using Framework.UI.MVP.Installers;

namespace Project.Scripts.Game.Installers
{
    public class GlobalInstaller : MVPInstaller
    {
        public GlobalInstaller(IPresenterContainer presenterContainer) : base(presenterContainer)
        {
        }
    }
}