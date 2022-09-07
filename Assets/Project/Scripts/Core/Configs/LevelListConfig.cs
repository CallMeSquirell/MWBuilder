using System;
using System.Collections.Generic;
using Project.Scripts.Constants;
using UnityEngine;

namespace Project.Scripts.Core.Configs
{
    [CreateAssetMenu(fileName = nameof(LevelListConfig), menuName = NamingConstants.Config + nameof(LevelListConfig), order = 0)]
    [Serializable]
    public class LevelListConfig : ScriptableObject
    {
        public const string Key = NamingConstants.Config + nameof(LevelListConfig);
        
        [SerializeField] private List<LevelConfig> _levels;

        public List<LevelConfig> Levels => _levels;
    }
}