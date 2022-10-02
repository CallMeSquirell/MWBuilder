using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Core
{
    public class PlayerCubeCollisionDetector : MonoBehaviour
    {
        public event Action<bool> Changed;
        
        private readonly List<DraggingCubeView> _collidedCubes = new();

        private void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.gameObject.TryGetComponent(out DraggingCubeView cubeView) &&
                !_collidedCubes.Contains(cubeView))
            {
                if (_collidedCubes.Count == 0)
                {
                    Changed?.Invoke(true);
                }
                _collidedCubes.Add(cubeView);
            }
        }

        private void OnCollisionExit(Collision collisionInfo)
        {
            if (collisionInfo.gameObject.TryGetComponent(out DraggingCubeView cubeView))
            {
                _collidedCubes.Remove(cubeView);
                if (_collidedCubes.Count == 0)
                {
                    Changed?.Invoke(false);
                }
            }
        }
    }
}