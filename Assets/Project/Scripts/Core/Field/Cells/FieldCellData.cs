using UnityEngine;

namespace Project.Scripts.Core.Cells
{
    public class FieldCellData
    {
        public Vector2Int Position { get; }

        public FieldCellData(Vector2Int position)
        {
            Position = position;
        }
    }
}