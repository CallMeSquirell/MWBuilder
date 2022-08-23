using Core.Framework;
using Project.Scripts.Core.Cells.Factory;
using Project.Scripts.Core.Configs;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class FieldView : BaseView<FieldData>
    {
        [SerializeField] 
        private Grid _grid;
        
        [SerializeField] 
        private CellFactory _cellFactory;

        private Transform _container;

        private void Awake()
        {
            _container = _grid.transform;
        }

        protected override void OnDataSetUpped()
        {
            Resize(Data.Size);
            foreach (var cell in Data.Cells)
            {
                var position = _grid.GetCellCenterLocal((Vector3Int)cell.Position);
                var cellView = _cellFactory.Create(_container);
                cellView.transform.localPosition = position;
                cellView.Data = cell;
            }
        }

        private void Resize(Vector2Int dataSize)
        {
            
        }
    }
}