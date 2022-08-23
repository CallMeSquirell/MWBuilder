using UnityEngine;
using UnityEngine.Tilemaps;

namespace Project.Scripts.Core.Configs
{
    [CreateAssetMenu(fileName = nameof(FieldStyleConfig), menuName = "Config/" + nameof(FieldStyleConfig), order = 1)]
    public class FieldStyleConfig : ScriptableObject
    {
        [SerializeField]
        private TileBase _backgroundTile;
    }
}