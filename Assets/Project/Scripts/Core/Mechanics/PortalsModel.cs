using System;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class PortalsModel
    {
        public event Action PortalsRefreshRequired;
        
        private readonly IUITutorialService _iuiTutorialService;
        
        public Transform TeleportSpawnPoint { get; private set; }

        public PortalsModel(IUITutorialService iuiTutorialService)
        {
            _iuiTutorialService = iuiTutorialService;
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