namespace Utils.Framework.Factory
{
    public interface IFactory<T>
    {
        T Create();
    }
}