using System;
using UnityEngine;

namespace Project.Scripts.Core
{
    [Serializable]
    public class TileState
    {
        [SerializeField] private int _index;
        [SerializeField] private int _height;

        public int Index => _index;

        public int Height => _height;
    }
}