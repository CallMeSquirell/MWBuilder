using Commands.Framework.Core;
using UI.Framework.DI.Binding;
using UI.Framework.Installers;

namespace Framework.UI.Animations.Scripts.UI.Core
{
    public class CoreUIInstaller : MVPInstaller
    {
        public CoreUIInstaller(IPresenterContainer presenterContainer, ICommandBinder commandBinder) : base(presenterContainer, commandBinder)
        {
        }
        
        
    }
}