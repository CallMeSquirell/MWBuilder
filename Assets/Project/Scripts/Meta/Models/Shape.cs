using System;
using UnityEngine;

namespace Project.Scripts.Meta.Models
{
    [Serializable]
    public class Shape
    {
        [SerializeField]
        private int _width;
        
        [SerializeField]
        private int _height;
        
        [SerializeField]
        private uint[] _cells;

        public uint[] Cells => _cells;

        public int Width => _width;

        public int Height => _height;
    }
}