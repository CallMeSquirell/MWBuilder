using Cysharp.Threading.Tasks;
using Project.Scripts.Core.Cells;
using Project.Scripts.Core.Configs;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class FieldModel
    {
        private GridMask _fieldMask;
        private GridMask _buildingMask;
        private GridMask _itemMask;
        
        private FieldCellData[,] _cells;
        private FieldConfig _config;

        public Vector2Int Size => _config.Size;

        public FieldCellData[,] Cells => _cells;

        public async UniTask Initialize(FieldConfig config)
        {
            _config = config;
            _cells = new FieldCellData[Size.x, Size.y];
            SetUpCells();
        }

        private void SetUpCells()
        {
            for (int y = 0; y < Size.y; y++)
            {
                for (int x = 0; x < Size.x; x++)
                {
                    var pos = new Vector2Int(x, y);
                    if (_fieldMask.IsMarked(pos))
                    {
                        var data = new FieldCellData(pos);
                        _cells[x, y] = data;
                    }
                }
            }
        }
    }
}