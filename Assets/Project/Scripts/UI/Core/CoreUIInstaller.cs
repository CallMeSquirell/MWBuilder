using Commands.Framework.Commands.Core;
using UI.Framework.UI.DI.Binding;
using Utils.Framework.Utils.Installers;

namespace Framework.UI.Animations.Scripts.UI.Core
{
    public class CoreUIInstaller : MVPInstaller
    {
        public CoreUIInstaller(IPresenterContainer presenterContainer, ICommandBinder commandBinder) : base(presenterContainer, commandBinder)
        {
        }
        
        
    }
}