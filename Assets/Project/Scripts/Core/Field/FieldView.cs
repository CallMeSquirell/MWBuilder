using System.Collections.Generic;
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
        
        [SerializeField] private List<FinishPointView> _finishes;

        [SerializeField] private PortalsView _portals;
        
        private CancellationTokenSource _cancellationToken;

        protected override void OnSetModel()
        {
            foreach (var trigger in _triggers)
            {
                trigger.Triggered += OnTriggered;
            }
            
            foreach (var finish in _finishes)
            {
                finish.Finished += OnFinished;
            }

            _portals.Model = Model.PortalsModel;
            CoreScreenView.StateChanged += OnTriggered;
        }

        private void OnFinished(PlayerView view)
        {
            Model.PlayerEarnedFinish(view);
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
            await Model.ShowDialog();
            Model.StateChangeEnded();
        }

        protected override void OnUnsetModel()
        {
            foreach (var trigger in _triggers)
            {
                trigger.Triggered -= OnTriggered;
            }
            
            foreach (var finish in _finishes)
            {
                finish.Finished -= OnFinished;
            }
            _portals.Model = null;
            CoreScreenView.StateChanged -= OnTriggered;
        }
    }
}