using UnityEngine;
using Utils.Framework.Utils.Pool;
using Zenject;

namespace Utils.Framework.Utils.UI.LayoutListUtil
{
    public class LayoutListPool<T> : AbstractPool<T> where T : ObjectPoolItem
    {
        private readonly IInstantiator _instantiator;
        private readonly Transform _container;
        private readonly T _prefab;

        public LayoutListPool(IInstantiator instantiator, Transform container, T prefab)
        {
            _instantiator = instantiator;
            _container = container;
            _prefab = prefab;
        }

        protected override T CreateItem()
        {
            return _instantiator.InstantiatePrefabForComponent<T>(_prefab, _container);
        }
    }
}