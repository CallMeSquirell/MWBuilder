using UI.Framework.Views.Impl;

namespace Project.Scripts.UI
{
    public class SettingPopUpPresenter : Presenter<SettingPopUpView>
    {
        public SettingPopUpPresenter(SettingPopUpView view) : base(view)
        {
          
        }

        public override void Initialize()
        {
            View.CloseClicked += OnViewClosed;
        }

        private void OnViewClosed()
        {
            View.Close();
        }

        public override void Dispose()
        {
            View.CloseClicked += OnViewClosed;
        }
    }
}