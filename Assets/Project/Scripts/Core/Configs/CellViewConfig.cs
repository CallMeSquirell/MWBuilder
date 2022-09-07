using Project.Scripts.Constants;
using Project.Scripts.Core.Cells;
using UnityEngine;

namespace Project.Scripts.Core.Configs
{
    [CreateAssetMenu(fileName = nameof(CellViewConfig), menuName = NamingConstants.Config + nameof(CellViewConfig), order = 0)]
    public sealed class CellViewConfig : ScriptableObject
    {
        public const string Key = NamingConstants.Config + nameof(CellViewConfig);
        
        [SerializeField] 
        private FieldCellView _cellPrefab;

        public FieldCellView CellPrefab => _cellPrefab;
    }
}