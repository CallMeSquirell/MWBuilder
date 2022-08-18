using System.Threading;
using Cysharp.Threading.Tasks;

namespace UI.Framework.Views
{
    public interface IManagedView : IScreenBaseView
    {
#if PLATFORM_ANDROID
        UniTask AndroidButtonGoBack(CancellationToken cancellationToken = default);
#endif
    }
}