using System.Threading;
using Cysharp.Threading.Tasks;
using Framework.UI.Managers.Data;
using Framework.UI.Managers.ViewListeners;
using Framework.UI.MVP.Views;

namespace Framework.UI.Managers.Manager
{
    public interface IUIManager
    {
        UniTask Initialise(CancellationToken cancellationToken);
        void DeInitialise();
        IViewListener OpenView(IViewDefinition viewDefinition, object payload = null);
        IScreenBaseView GetView(IViewDefinition viewDefinition);
    }
}