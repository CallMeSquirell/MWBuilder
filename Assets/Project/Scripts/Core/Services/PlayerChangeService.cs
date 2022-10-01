﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Project.Scripts.Core.Services;
using Project.Scripts.Meta.Input;
using Utils.Framework.Extensions;
using Utils.Framework.Property;
using Random = UnityEngine.Random;

namespace Project.Scripts.Core
{
    public class PlayerChangeService : IPlayerChangeService
    {
        private const int Delay = 1;
        private const int RequiredDelay = 10;

        private IReadOnlyList<PlayerView> _players;

        private readonly BindableProperty<int> _index = new(RequiredDelay);
        private readonly List<PlayerView> _pool = new();
        private readonly PlayerModel _playerModel;
        
        private PlayerView _currentPlayer;
        private CancellationTokenSource _cancellationTokenSource;
        public IBindableProperty<int> TimeLeft => _index;

        public PlayerModel PlayerModel => _playerModel;

        public PlayerChangeService(IInputService inputService)
        {
            _playerModel = new PlayerModel(inputService);
        }

        public void Initialize(IReadOnlyList<PlayerView> players)
        {
            _players = players;
            RefreshPool();
            EnableNewPlayer();
            foreach (var playerView in _players.Where(p => !ReferenceEquals(p, _currentPlayer)))
            {
                playerView.gameObject.SetActive(false);
            }
        }

        private void RefreshPool()
        {
            _pool.Clear();
            _pool.AddRange(_players);
            if (_currentPlayer.NonNull())
            {
                _pool.Remove(_currentPlayer);
            }
        }

        public void Run()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            UpdateLoop(_cancellationTokenSource.Token).SuppressCancellationThrow();
        }

        private async UniTask UpdateLoop(CancellationToken cancellationToken)
        {
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(Delay), cancellationToken: cancellationToken);

                _index.Value -= Delay;

                if (_index.Value == 0)
                {
                    await Change();
                    _index.Value = RequiredDelay;
                }
            }
        }

        private UniTask Change()
        {
            DisableOldPlayer();
            EnableNewPlayer();
            TryRefreshPool();
            return UniTask.CompletedTask;
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

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = null;
        }
    }
}