using System.Threading;
using Cysharp.Threading.Tasks;

namespace Framework.UI.MVP.Views.Impl
{
    public abstract class ManagedView : ScreenBaseView, IManagedView
    {
#if PLATFORM_ANDROID
        public virtual UniTask AndroidButtonGoBack(CancellationToken cancellationToken)
        {
            return UniTask.CompletedTask;
        }
#endif
        
    }
}