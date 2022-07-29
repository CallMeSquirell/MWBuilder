using UnityEngine;

namespace Utils.Framework.Utils.Extensions
{
    public static class ObjectExtensions
    {
        public static bool NonNull(this Object obj)
        {
            return !ReferenceEquals(obj, null);
        }
    }
}