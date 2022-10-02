using Project.Scripts.Core.Services;

namespace Project.Scripts.Core
{
    public class FieldModel
    {
        private readonly IPlayerService _service;
        private readonly PortalsModel _portalsModel;

        public PortalsModel PortalsModel => _portalsModel;

        public FieldModel(IPlayerService service, IUITutorialService iuiTutorialService)
        {
            _service = service;
            _portalsModel = new PortalsModel(iuiTutorialService);
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