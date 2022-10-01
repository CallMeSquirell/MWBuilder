using Core.Framework;
using Project.Scripts.Core.Cells.Factory;
using UnityEngine;
using Zenject;

namespace Project.Scripts.Core
{
    public class FieldView : BaseView<FieldModel>
    {
        public const string Key = nameof(FieldView);
        
        [SerializeField] 
        private Grid _grid;
        
        private ICellViewFactory _cellViewFactory;

        private Transform _container;
        
        [Inject]
        private void Construct(ICellViewFactory cellViewFactory)
        {
            _cellViewFactory = cellViewFactory;
        }
        
        private void Awake()
        {
            _container = _grid.transform;
        }

        protected override void OnDataSetUpped()
        {
            //Resize(Data.Size);
            foreach (var cell in Data.Cells)
            {
                var position = _grid.GetCellCenterLocal((Vector3Int) cell.Position);
                var cellView = _cellViewFactory.Create(_container);
                cellView.transform.localPosition = position;
                cellView.Data = cell;
            }
        }

        private void Resize(Vector2Int dataSize)
        {
            var offset = (Vector2) dataSize / 2 * _grid.cellSize.x;
            _container.position -= (Vector3) offset;
        }
    }
}