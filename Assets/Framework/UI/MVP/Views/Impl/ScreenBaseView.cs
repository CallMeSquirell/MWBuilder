using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Framework.UI.Animations;
using Framework.Utils.Extensions;

namespace Framework.UI.MVP.Views.Impl
{
    public class ScreenBaseView : BaseViewBehaviour, IScreenBaseView
    {
        public event Action<bool> FocusChanged;
        public event Action Closed;

        private bool _interactable;
        private BaseTransition _transition;
        public bool IsFocused { get; private set; } = true;

        public bool Interactable
        {
            set
            {
                _interactable = value;
                OnInteractableChanged(_interactable);
            }
        }

        protected virtual void Awake()
        {
            _transition = GetComponent<BaseTransition>();
        }

        public UniTask Open(CancellationToken cancellationToken = default)
        {
            if (_transition.NonNull())
            {
                return _transition.PlayOpenTransition(cancellationToken);
            }
            return UniTask.CompletedTask;
        }
        
        public async UniTask Close(bool withAnimation = true, CancellationToken cancellationToken = default)
        {
            if (_transition.NonNull() && withAnimation)
            {
                await _transition.PlayCloseTransition(cancellationToken);
                Closed?.Invoke();
            }
            else
            {
                Closed?.Invoke();
            }
        }
        
        public void SetFocus(bool isFocused)
        {
            if (isFocused != IsFocused)
            {
                IsFocused = isFocused;
                OnFocusChanged(isFocused);
                FocusChanged?.Invoke(isFocused);
            }
        }
        
        protected virtual void OnInteractableChanged(bool interactable)
        {
            
        }

        protected virtual void OnFocusChanged(bool isFocused)
        {
        }
    }
}