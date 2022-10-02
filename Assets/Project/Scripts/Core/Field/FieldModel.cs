using Project.Scripts.Core.Services;

namespace Project.Scripts.Core
{
    public class FieldModel
    {
        private readonly IPlayerChangeService _changeService;

        public FieldModel(IPlayerChangeService changeService)
        {
            _changeService = changeService;
        }

        public void StateChangeStarted()
        {
            _changeService.PlayerModel.Locked = true;
        }

        public void StateChangeEnded()
        {
            _changeService.PlayerModel.Locked = false;
        }
    }
}