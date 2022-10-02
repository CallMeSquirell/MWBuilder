using Utils.Framework.Property;

namespace Project.Scripts.Core
{
    public class IuiTutorialService : IUITutorialService
    {
        public BindableProperty<bool> PortalHelper { get; } = new();
    }
}