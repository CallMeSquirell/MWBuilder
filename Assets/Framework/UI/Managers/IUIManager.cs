using System.Threading;
using Cysharp.Threading.Tasks;
using UI.Framework.UI.Data;
using UI.Framework.UI.ViewListeners;
using UI.Framework.UI.Views;

namespace UI.Framework.UI.Managers
{
    public interface IUIManager
    {
        UniTask Initialise(CancellationToken cancellationToken);
        void DeInitialise();
        IViewListener OpenView(IViewDefinition viewDefinition, object payload = null);
        IScreenBaseView GetView(IViewDefinition viewDefinition);
    }
}