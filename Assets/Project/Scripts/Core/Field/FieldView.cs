﻿using System.Collections.Generic;
using System.Threading;
using Core.Framework;
using Cysharp.Threading.Tasks;
using Framework.UI.Animations.Scripts.UI.Core.Views;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class FieldView : BaseView<FieldModel>
    {
        [SerializeField] private List<TileView> _tiles = new();

        [SerializeField] private List<LandscapeChangeTriggerView> _triggers;

        [SerializeField] private PortalsView _portals;

        private CancellationTokenSource _cancellationToken;

        protected override void OnSetModel()
        {
            foreach (var trigger in _triggers)
            {
                trigger.Triggered += OnTriggered;
            }

            _portals.Model = Model.PortalsModel;
            CoreScreenView.StateChanged += OnTriggered;
        }

        private void OnTriggered(int index)
        {
            _cancellationToken = new CancellationTokenSource();
            ApplyState(index, _cancellationToken.Token).Forget();
        }

        private async UniTask ApplyState(int index, CancellationToken cancellationToken)
        {
            Model.StateChangeStarted();
            var tasks = new List<UniTask>();
            foreach (var tile in _tiles)
            {
                tasks.Add(tile.ApplyState(index, cancellationToken));
            }

            await tasks;
            Model.StateChangeEnded();
        }

        protected override void OnUnsetModel()
        {
            foreach (var trigger in _triggers)
            {
                trigger.Triggered -= OnTriggered;
            }

            CoreScreenView.StateChanged -= OnTriggered;
        }
    }
}