using AssetManagement.Framework.ResourceManagement.Configs;
using UnityEngine;
using Zenject;

namespace Core.Framework.Core
{
    public class BaseView<T> : MonoBehaviour
    {
        public T Data { get; private set; }
        protected IInstantiator Instantiator { get; private set; }
        protected IConfigService ConfigService { get; private set; }

        [Inject]
        private void Construct(IInstantiator instantiator, IConfigService configService)
        {
            ConfigService = configService;
            Instantiator = instantiator;
        }

        public void SetData(T data)
        {
            Data = data;
            OnDataSetUpped();
        }

        protected virtual void OnDataSetUpped()
        {
        }
    }
}