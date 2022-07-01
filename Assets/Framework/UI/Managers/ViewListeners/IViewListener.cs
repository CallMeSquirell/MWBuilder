using Cysharp.Threading.Tasks;

namespace Framework.UI.Managers.ViewListeners
{
    public interface IViewListener
    {
        UniTask Opened { get; }
        UniTask Closed { get; }
    }
}