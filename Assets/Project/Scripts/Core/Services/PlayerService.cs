using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Framework.Timer;
using Project.Scripts.Core.Services;
using Project.Scripts.Meta.Input;
using Utils.Framework.Extensions;
using Utils.Framework.Property;
using Random = UnityEngine.Random;

namespace Project.Scripts.Core
{
    public class PlayerService : IPlayerService
    {
        private IReadOnlyList<PlayerView> _players;
        
        private readonly List<PlayerView> _pool = new();
        private readonly List<PlayerView> _ignorePlayer = new();
        private readonly PlayerModel _playerModel;
        private IActionTimer _actionTimer;
        
        private PlayerView _currentPlayer;
        private CancellationTokenSource _cancellationTokenSource;
        public IBindableProperty<int> TimeLeft => _actionTimer.CurrentTime;

        public PlayerModel PlayerModel => _playerModel;

        public PlayerService(IInputService inputService)
        {
            _playerModel = new PlayerModel(inputService);
        }

        public void Initialize(IReadOnlyList<PlayerView> players, IActionTimer actionTimer)
        {
            _players = players;
            _actionTimer = actionTimer;
            _actionTimer.Subscribe(Change);
            RefreshPool();
            EnableNewPlayer();
           
            foreach (var playerView in _players.Where(p => !ReferenceEquals(p, _currentPlayer)))
            {
                playerView.gameObject.SetActive(false);
            }
        }

        public void RunTimer()
        {
            _actionTimer.Start();
        }

        public void StopTimer()
        {
            _actionTimer.Stop();
        }

        public void RemovePlayerFromPool(PlayerView view)
        {
            _ignorePlayer.Add(view);
            _actionTimer.Reset();
            Change();
        }

        private void RefreshPool()
        {
            _pool.Clear();
            _pool.AddRange(_players.Except(_ignorePlayer));
            if (_currentPlayer.NonNull())
            {
                _pool.Remove(_currentPlayer);
            }
        }
        
        private void Change()
        {
            DisableOldPlayer();
            EnableNewPlayer();
            TryRefreshPool();
        }

        private void TryRefreshPool()
        {
            if (_pool.Count == 0)
            {
                RefreshPool();
            }
        }

        private void DisableOldPlayer()
        {
            if (!_currentPlayer.NonNull()) return;

            _currentPlayer.Model = null;
            _currentPlayer.gameObject.SetActive(false);
        }

        private void EnableNewPlayer()
        {
            _currentPlayer = _pool[Random.Range(0, _pool.Count)];
            _pool.Remove(_currentPlayer);
            _currentPlayer.Model = _playerModel;
            _currentPlayer.gameObject.SetActive(true);
        }
    }
}