using System;
using Cysharp.Threading.Tasks;
using Framework.Timer;
using Project.Scripts.Constants;
using Project.Scripts.Core.Services;
using Project.Scripts.UI;
using UI.Framework.Managers;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class PortalsModel
    {
        private const string SecondTutorialText =
            "Look, it's a portal! With it, you can get to another part of the maze, but be careful, because the entrance and exit of the portal may not match, and there is a chance that you will not come back!";
        
        public event Action PortalsRefreshRequired;
        
        private readonly IPlayerService _playerService;
        private readonly IUIManager _uiManager;
        private readonly IUITutorialService _iuiTutorialService;
        
        public Transform TeleportSpawnPoint { get; private set; }

        private bool _dialogShown;

        public PortalsModel(IPlayerService playerService,IUIManager uiManager, IUITutorialService iuiTutorialService, IActionTimer actionTimer)
        {
            _playerService = playerService;
            _uiManager = uiManager;
            _iuiTutorialService = iuiTutorialService;
            actionTimer.Subscribe(RefreshPortals);
        }

        public void OnGateSelectionChanged(Transform teleportSpawnPoint)
        {
            TeleportSpawnPoint = teleportSpawnPoint;
            _iuiTutorialService.PortalHelper.Value = teleportSpawnPoint != null;
            ShowDialog().Forget();
        }

        private async UniTask ShowDialog()
        {
            if (_dialogShown)
            {
                return;
            }

            _playerService.StopTimer();
            _playerService.PlayerModel.Locked = true;

            await _uiManager.OpenView(ViewNames.DialogBubble, new DialogPayload()
            {
                Text = SecondTutorialText
            }).Closed;

            _playerService.RunTimer();
            _playerService.PlayerModel.Locked = false;
            _dialogShown = true;
        }

        private void RefreshPortals()
        {
            PortalsRefreshRequired?.Invoke();
        }
    }
}