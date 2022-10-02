using Framework.Timer;
using Project.Scripts.Core.Services;

namespace Project.Scripts.Core
{
    public class FieldModel
    {
        private readonly IPlayerService _service;
        private readonly PortalsModel _portalsModel;

        public PortalsModel PortalsModel => _portalsModel;

        public FieldModel(IPlayerService service, IUITutorialService iuiTutorialService, IActionTimer timer)
        {
            _service = service;
            _portalsModel = new PortalsModel(iuiTutorialService, timer);
        }

        public void StateChangeStarted()
        {
            _service.PlayerModel.Locked = true;
        }

        public void StateChangeEnded()
        {
            _service.PlayerModel.Locked = false;
        }
    }
}