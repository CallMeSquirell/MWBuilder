using UnityEngine;
using Zenject;

namespace Framework.Core
{
    public class BaseView<T> : MonoBehaviour
    {
        public T Data { get; private set; }
        public IInstantiator Instantiator { get; private set; }

        [Inject]
        private void Construct(IInstantiator instantiator)
        {
            Instantiator = instantiator;
        }

        public void SetData(T data)
        {
            Data = data;
        }

        protected virtual void OnDataSetUpped()
        {
        }
    }
}