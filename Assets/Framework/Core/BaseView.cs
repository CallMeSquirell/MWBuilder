using AssetManagement.Framework.Configs;
using UnityEngine;
using Zenject;

namespace Core.Framework
{
    public class BaseView<T> : MonoBehaviour where T : class
    {
        private T _model;

        public T Model
        {
            get => _model;
            set
            {
                if (_model != null)
                {
                    OnUnsetModel();
                }
                
                _model = value;

                if (_model != null)
                {
                    OnSetModel();
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
        
        protected virtual void OnSetModel()
        {
        }
        
        protected virtual void OnUnsetModel()
        {
        }

        protected virtual void OnDestroy()
        {
            Model = null;
        }
    }
}