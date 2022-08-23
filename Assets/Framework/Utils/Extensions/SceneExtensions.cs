using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils.Framework.Extensions
{
    public static class SceneExtensions
    {
        public static T FindComponentInRootObjects<T>(this Scene scene) where T : Component
        {
            foreach (var gameObject in scene.GetRootGameObjects())
            {
                if (gameObject.TryGetComponent(out T component))
                {
                    return component;
                }
            }
            return null;
        }
    }
}