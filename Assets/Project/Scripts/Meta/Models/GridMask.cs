using System;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class GridMask
    {
        private readonly Vector2Int _size;
        private readonly uint[] _mask;
       
        public GridMask(Vector2Int size, uint[] mask)
        {
            _size = size;
            _mask = mask;
        }
        
        public GridMask(Vector2Int size)
        {
            _size = size;
            _mask = new uint[size.y];
            
            Clear();
        }

        public void Set(Vector2Int cell)
        {
            _mask[cell.y] |= 1u << _size.x - cell.x - 1;
        }
        
        public void Remove(Vector2Int cell)
        {
            _mask[cell.y] ^= 1u <<  _size.x - cell.x - 1;
        }

        public bool IsMarked(Vector2Int cell)
        {
            return (_mask[cell.y] & 1u <<  _size.x - cell.x - 1) != 0;
        }

        private void Clear()
        {
            for (int i = 0; i < _size.y; i++)
            {
                _mask[i] = ~((1u << _size.x) & 0);
                Debug.Log(Convert.ToString( _mask[i], toBase: 2));
            }
        }
    }
}