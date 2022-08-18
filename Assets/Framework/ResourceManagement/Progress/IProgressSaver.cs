namespace AssetManagement.Framework.Progress
{
    public interface IProgressSaver
    {
        void Save<T>(T obj);
        T Get<T>();
    }
}