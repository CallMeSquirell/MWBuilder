using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Framework.UI.Animations
{
    public abstract class BaseTransition : MonoBehaviour
    {
        public UniTask PlayCloseTransition(CancellationToken cancellationToken = default)
        {
            return Close(cancellationToken);
        }

        public UniTask PlayOpenTransition(CancellationToken cancellationToken = default)
        {
            return Open(cancellationToken);
        }

        protected abstract UniTask Open(CancellationToken cancellationToken = default);
        protected abstract UniTask Close(CancellationToken cancellationToken = default);
    }
}