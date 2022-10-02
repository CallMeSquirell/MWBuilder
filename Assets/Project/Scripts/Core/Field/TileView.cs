using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private List<TileState> _tileStates;

        [SerializeField] private Transform _root;

        [SerializeField] private float _moveDuration = 0.3f;
        [SerializeField] private Ease _moveCurve = Ease.Linear;

        public UniTask ApplyState(int index, CancellationToken cancellationTokenSource)
        {
            var state = _tileStates.FirstOrDefault(state => state.Index == index);
            if (state != null)
            {
                return _root.DOMoveY(state.Height, _moveDuration)
                    .SetEase(_moveCurve)
                    .ToUniTask(cancellationToken: cancellationTokenSource);
            }

            return UniTask.CompletedTask;
        }
    }
}