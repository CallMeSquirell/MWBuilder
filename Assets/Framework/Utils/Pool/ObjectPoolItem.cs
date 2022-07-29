using UnityEngine;

namespace Utils.Framework.Utils.Pool
{
    public class ObjectPoolItem : MonoBehaviour, IPoolItem
    {
        public bool IsFree { get; private set; }
        
        public virtual void Load()
        {
            Release();
        }

        public virtual void Retain()
        {
            IsFree = false;
            gameObject.SetActive(true);
        }

        public virtual void Release()
        {
            IsFree = true;
            gameObject.SetActive(false);
        }
    }
}