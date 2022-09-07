using Project.Scripts.Constants;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Project.Scripts.Core.Configs
{
    [CreateAssetMenu(fileName = nameof(FieldStyleConfig), menuName = NamingConstants.Config + nameof(FieldStyleConfig), order = 1)]
    public sealed class FieldStyleConfig : ScriptableObject
    {
        [SerializeField]
        private TileBase _backgroundTile;
    }
}