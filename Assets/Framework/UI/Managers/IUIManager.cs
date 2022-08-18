using System.Threading;
using Cysharp.Threading.Tasks;
using UI.Framework.Data;
using UI.Framework.ViewListeners;
using UI.Framework.Views;

namespace UI.Framework.Managers
{
    public interface IUIManager
    {
        UniTask Initialise(CancellationToken cancellationToken);
        void DeInitialise();
        IViewListener OpenView(IViewDefinition viewDefinition, object payload = null);
        IScreenBaseView GetView(IViewDefinition viewDefinition);
    }
}