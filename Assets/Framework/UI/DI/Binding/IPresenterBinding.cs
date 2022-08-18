using UI.Framework.Views;

namespace UI.Framework.DI.Binding
{
    public interface IPresenterBinding
    {
        void To<P>() where P : IPresenter<IScreenBaseView>;
        void CreatePresenter(IScreenBaseView screenBaseView, object payload = null);
        void DestroyPresenter(IScreenBaseView screenBaseView);
    }
}