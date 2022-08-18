using Cysharp.Threading.Tasks;

namespace UI.Framework.ViewListeners
{
    public interface IViewListener
    {
        UniTask Opened { get; }
        UniTask Closed { get; }
    }
}