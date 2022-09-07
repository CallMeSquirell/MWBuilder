using System;
using Project.Scripts.Constants;
using UnityEngine;

namespace Project.Scripts.Core.Configs
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = NamingConstants.Config + nameof(LevelConfig), order = 0)]
    [Serializable]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private Vector2Int _fieldSize;

        public Vector2Int FieldSize => _fieldSize;
    }
}