using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Framework.UI.Animations
{
    public class DefaultTransition : BaseTransition
    {
        [Header("Open")]
        [SerializeField] private float _openDuration = 0.4f;
        [SerializeField] private AnimationCurve _openCurve = AnimationCurve.EaseInOut(0,0,1,1);
        
        [Header("Close")]
        [SerializeField] private float _closeDuration = 0.4f;
        [SerializeField] private AnimationCurve _closeCurve = AnimationCurve.EaseInOut(0,0,1,1);
        
        [Space]
        [SerializeField] private Vector3 _closedScale = new Vector3(1, 1, 0);

        private Sequence _activeSequence;
        private Transform _transform;
        
        protected virtual void Awake()
        {
            _transform = transform;
            _transform.localScale = _closedScale;
        }

        protected override UniTask Open(CancellationToken cancellationToken = default)
        {
            if (_activeSequence != null)
            {
                _activeSequence.Kill(true);
            }
            
            _activeSequence = DOTween.Sequence()
                .Append(_transform.DOScale(Vector3.one, _openDuration).SetEase(_openCurve));
            return _activeSequence.ToUniTask(cancellationToken: cancellationToken);
        }
        
        protected override UniTask Close(CancellationToken cancellationToken = default)
        {
            if (_activeSequence != null)
            {
                _activeSequence.Kill(true);
            }

            _activeSequence = DOTween.Sequence()
                .Append(_transform.DOScale(_closedScale, _closeDuration).SetEase(_closeCurve));
            return _activeSequence.ToUniTask(cancellationToken: cancellationToken);
        }
    }
}