using Utils.Framework.Property;

namespace Project.Scripts.Core
{
    public class TimerModel : ITimerModel
    {
        private readonly BindableProperty<int> _timeLeft;

        public IBindableProperty<int> TimeLeft => _timeLeft;
        
        public TimerModel()
        {
            _timeLeft = new BindableProperty<int>();
        }
    }
}