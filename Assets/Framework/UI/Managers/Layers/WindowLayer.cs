using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UI.Framework.Data;
using UI.Framework.DI;
using UI.Framework.DI.Provider;
using UI.Framework.Views;
using UI.Framework.Views.Impl;
using UnityEngine;
using Zenject;

namespace UI.Framework.Managers.Layers
{
    [RequireComponent(typeof(Canvas))]
    public class WindowLayer : MonoBehaviour
    {
        public event Action<WindowLayer> ViewPlaced;
        public event Action<WindowLayer> Cleared;
        
        private Canvas _canvas;

        private IViewFactory _viewFactory;
        private IPresenterProvider _presenterProvider;

        private IInvokableViewData _placedViewData;
        private IInvokableViewData _viewToPlace;

        private ScreenBaseView _placedView;

        private bool _isFocused;
        private bool _isClosing;
        private Transform _transform;

        private Canvas Canvas => _canvas ? _canvas : _canvas = GetComponent<Canvas>();

        public int Order => Canvas.sortingOrder;
        
        public IViewData PlacedViewData => _placedViewData;

        public IScreenBaseView PlacedView => _placedView;

        private void Awake()
        {
            _transform = transform;
        }

        [Inject]
        public void Construct(IViewFactory factory, IPresenterProvider presenterProvider)
        {
            _viewFactory = factory;
            _presenterProvider = presenterProvider;
        }

        public async UniTask PlaceView(IInvokableViewData data, CancellationToken cancellationToken = default)
        {
            if (_viewToPlace != null)
            {
#if UNITY_EDITOR
                Debug.LogWarning($"Layer is busy with creating {_viewToPlace}");   
#endif
                return;
            }

            _viewToPlace = data;

            await Clear(cancellationToken);

            await OpenNextView(cancellationToken);
        }
        
        private async UniTask OpenNextView(CancellationToken cancellationToken = default)
        {
            if (_viewToPlace != null)
            {
                var task = _viewFactory.Create<ScreenBaseView>(_viewToPlace.Definition, _transform, cancellationToken);
                _viewToPlace.InvokableListener.OpenSource.TrySetResult();
                _placedView = await task;
                _placedViewData = _viewToPlace;
                _presenterProvider.ProvideTo(_placedView, _placedViewData.Payload);
                _placedView.Closed += OnViewClosed;
                _viewToPlace = null;
                ViewPlaced?.Invoke(this);
            }
        }
        
        public async UniTask Clear(CancellationToken cancellationToken = default)
        {
            if (_isClosing)
            {
                _viewToPlace = null;
                return;
            }
            
            if (_placedView != null)
            {
                _isClosing = true;
                await _placedView.Close(false, cancellationToken);
                _isClosing = false;
                Cleared?.Invoke(this);
            }
        }

        public void SetFocus(bool isInFocus)
        {
            _isFocused = isInFocus;
            if (_placedView != null)
            {
                _placedView.SetFocus(_isFocused);
            }
        }

        private void OnViewClosed()
        {
            _placedView.Closed -= OnViewClosed;
            _presenterProvider.DisposePresenterFor(_placedView);
            Destroy(_placedView.gameObject);
            _placedViewData.InvokableListener.CloseSource.TrySetResult();
            _placedViewData = null;
            _placedView = null;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i) == transform)
                {
                    Canvas.overrideSorting = true;
                    Canvas.sortingOrder = i;
                }
            }
        }
#endif
    }
}