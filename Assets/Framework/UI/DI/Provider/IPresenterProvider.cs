using UI.Framework.Views;

namespace UI.Framework.DI.Provider
{
    public interface IPresenterProvider
    {
        void ProvideTo(IScreenBaseView screenBaseView, object payload);
        void DisposePresenterFor(IScreenBaseView screenBaseView);
    }
}