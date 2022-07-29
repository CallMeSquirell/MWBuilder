namespace Utils.Framework.Utils.Pool
{
    public interface IPool<T>
    {
        T Get();
        void Prepare(int count);
    }
}