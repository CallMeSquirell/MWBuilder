using Framework.UI.MVP.Views.Impl;

namespace Framework.UI.Animations.Scripts.Core
{
    public class LevelPresenter
    {
        private readonly LevelView _levelView;

        public LevelPresenter(LevelView levelView)
        {
            _levelView = levelView;
        }
    }
}