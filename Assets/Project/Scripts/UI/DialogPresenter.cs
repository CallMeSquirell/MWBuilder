using UI.Framework.Views.Impl;

namespace Project.Scripts.UI
{
    public class DialogPresenter : Presenter<DialogView>
    {
        private readonly DialogPayload _payload;

        public DialogPresenter(DialogPayload payload, DialogView view) : base(view)
        {
            _payload = payload;
        }

        public override void Initialize()
        {
            View.SetText(_payload.Text);
        }
    }
}