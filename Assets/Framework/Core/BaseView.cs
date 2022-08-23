using AssetManagement.Framework.Configs;
using UnityEngine;
using Zenject;

namespace Core.Framework
{
    public class BaseView<T> : MonoBehaviour
    {
        private T _data;

        public T Data
        {
            get => _data;
            set
            {
                if (_data != null)
                {
                    OnDataRemoved();
                }
                
                _data = value;

                if (_data != null)
                {
                    OnDataSetUpped();
                }
            }
        }

        protected IInstantiator Instantiator { get; private set; }
        protected IConfigService ConfigService { get; private set; }

        [Inject]
        private void Construct(IInstantiator instantiator, IConfigService configService)
        {
            ConfigService = configService;
            Instantiator = instantiator;
        }
        
        protected virtual void OnDataSetUpped()
        {
        }
        
        protected virtual void OnDataRemoved()
        {
        }
    }
}