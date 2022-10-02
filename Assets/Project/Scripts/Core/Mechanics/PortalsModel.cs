using System;
using Framework.Timer;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class PortalsModel
    {
        public event Action PortalsRefreshRequired;
        
        private readonly IUITutorialService _iuiTutorialService;
        
        public Transform TeleportSpawnPoint { get; private set; }

        public PortalsModel(IUITutorialService iuiTutorialService, IActionTimer actionTimer)
        {
            _iuiTutorialService = iuiTutorialService;
            actionTimer.Subscribe(RefreshPortals);
        }

        public void OnGateSelectionChanged(Transform teleportSpawnPoint)
        {
            TeleportSpawnPoint = teleportSpawnPoint;
            _iuiTutorialService.PortalHelper.Value = teleportSpawnPoint != null;
        }

        public void RefreshPortals()
        {
            PortalsRefreshRequired?.Invoke();
        }
    }
}