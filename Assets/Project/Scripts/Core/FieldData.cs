using UnityEngine;

namespace Project.Scripts.Core
{
    public class FieldData
    {
        private readonly FieldCellData[,] _cells;
        private readonly GridMask _mask;
        private readonly Vector2Int _size;

        public FieldCellData[,] Cells => _cells;

        public Vector2Int Size => _size;

        public FieldData(Vector2Int size)
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
                        _cells[x, y] = new FieldCellData(pos);
                    }
                }
            }
        }
    }
}