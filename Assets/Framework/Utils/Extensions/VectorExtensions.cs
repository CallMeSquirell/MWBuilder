using UnityEngine;

namespace Framework.Utils.Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 SetY(this Vector3 vector, float y)
        {
            var newVector = vector;
            newVector.y = y;
            return newVector;
        }
    }
}