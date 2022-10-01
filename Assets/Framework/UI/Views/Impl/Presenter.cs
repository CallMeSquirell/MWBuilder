namespace UI.Framework.Views.Impl
{
    public abstract class Presenter<V> : IPresenter<V> where V : IScreenBaseView
    {
        protected V View { get; }

        public Presenter(V view)
        {
            View = view;
        }

        public virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}