using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Framework.UI.Animations
{
    public abstract class BaseTransition : MonoBehaviour
    {
        public UniTask PlayOpenTransition(CancellationToken cancellationToken = default)
        {
            return Open(cancellationToken);
        }
        
        public UniTask PlayCloseTransition(CancellationToken cancellationToken = default)
        {
            return Close(cancellationToken);
        }
        
        protected abstract UniTask Open(CancellationToken cancellationToken = default);
        protected abstract UniTask Close(CancellationToken cancellationToken = default);
    }
}