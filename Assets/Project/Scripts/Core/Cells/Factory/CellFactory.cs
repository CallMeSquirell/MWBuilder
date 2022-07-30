using UnityEngine;

namespace Project.Scripts.Core.Cells.Factory
{
    [CreateAssetMenu(fileName = nameof(CellFactory), menuName = "Core/CellFactory", order = 0)]
    public class CellFactory : ScriptableObject
    {
        [SerializeField] 
        private FieldCellView _cellPrefab;
        
        public FieldCellView Create(Transform container)
        {
            return Instantiate(_cellPrefab, container);
        }
    }
}