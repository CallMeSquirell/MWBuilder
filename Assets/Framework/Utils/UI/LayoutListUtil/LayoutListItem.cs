using Utils.Framework.Utils.Pool;

namespace Utils.Framework.Utils.UI.LayoutListUtil
{
    public abstract class LayoutListItem<T> : ObjectPoolItem
    {
        private T _data;

        public T Data => _data;

        public virtual void SetData(T data)
        {
            _data = data;
        }
    }
}