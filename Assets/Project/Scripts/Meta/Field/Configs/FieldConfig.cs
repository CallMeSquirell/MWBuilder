using UnityEngine;

namespace Project.Scripts.Core.Configs
{
    [CreateAssetMenu(fileName = nameof(FieldConfig), menuName = Key)]
    public class FieldConfig : ScriptableObject
    {
        public const string Key = "Configs/" + nameof(FieldConfig);
        
        [SerializeField] 
        private uint _fieldMask;

        [SerializeField] 
        private Vector2Int _size;

        public uint FieldMask => _fieldMask;

        public Vector2Int Size => _size;
    }
}