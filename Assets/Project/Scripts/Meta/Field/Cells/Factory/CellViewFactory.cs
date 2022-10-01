using AssetManagement.Framework.Configs;
using Project.Scripts.Core.Configs;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Core.Cells.Factory
{

    public class CellViewFactory : ICellViewFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly CellViewConfig _cellViewConfig;

        public CellViewFactory(IConfigService configService, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _cellViewConfig = configService.Get<CellViewConfig>();
        }

        public FieldCellView Create(Transform container)
        {
            return _instantiator.InstantiatePrefabForComponent<FieldCellView>(_cellViewConfig.CellPrefab, container);
        }
    }
}