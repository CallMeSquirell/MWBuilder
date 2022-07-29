using UnityEngine;

namespace Project.Scripts.Core
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