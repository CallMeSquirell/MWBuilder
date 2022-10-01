using System;
using UnityEngine;

namespace Project.Scripts.Core
{
    [Serializable]
    public class TileState
    {
        [SerializeField] private int _index;
        [SerializeField] private float _height;

        public int Index => _index;

        public float Height => _height;
    }
}