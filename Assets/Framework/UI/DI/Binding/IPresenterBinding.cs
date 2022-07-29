using UI.Framework.UI.Views;

namespace UI.Framework.UI.DI.Binding
{
    public interface IPresenterBinding
    {
        void To<P>() where P : IPresenter<IScreenBaseView>;
        void CreatePresenter(IScreenBaseView screenBaseView, object payload = null);
        void DestroyPresenter(IScreenBaseView screenBaseView);
    }
}