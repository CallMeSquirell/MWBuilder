using Cysharp.Threading.Tasks;

namespace UI.Framework.UI.ViewListeners
{
    public interface IViewListener
    {
        UniTask Opened { get; }
        UniTask Closed { get; }
    }
}