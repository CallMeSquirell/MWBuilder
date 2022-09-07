using Project.Scripts.Core.Cells;
using Project.Scripts.Core.Cells.Factory;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class FieldData
    {
        private FieldCellData[,] _cells;
        private GridMask _mask;
        private Vector2Int _size;
        
        private readonly CellDataBuilder _cellDataBuilder;

        public FieldCellData[,] Cells => _cells;

        public Vector2Int Size => _size;

        public FieldData()
        {
            _cellDataBuilder = new CellDataBuilder(this);
        }

        public void Initialize(Vector2Int size)
        {
            _size = size;
            _mask = new GridMask(size);
            _cells = new FieldCellData[size.x, size.y];
            SetUpCells();
        }

        private void SetUpCells()
        {
            for (int y = 0; y < _size.y; y++)
            {
                for (int x = 0; x < _size.x; x++)
                {
                    var pos = new Vector2Int(x, y);
                    if (_mask.IsMarked(pos))
                    {
                        var data = new FieldCellData(pos);
                        _cellDataBuilder.Build(data);
                        _cells[x, y] = data;
                    }
                }
            }
        }
    }
}