namespace Framework.Utils.Factory
{
    public interface IFactory<T>
    {
        T Create();
    }
}