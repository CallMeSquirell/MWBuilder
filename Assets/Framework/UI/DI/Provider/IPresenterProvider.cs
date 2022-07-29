using UI.Framework.UI.Views;

namespace UI.Framework.UI.DI.Provider
{
    public interface IPresenterProvider
    {
        void ProvideTo(IScreenBaseView screenBaseView, object payload);
        void DisposePresenterFor(IScreenBaseView screenBaseView);
    }
}