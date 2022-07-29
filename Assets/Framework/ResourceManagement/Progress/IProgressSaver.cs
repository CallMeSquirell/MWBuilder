namespace AssetManagement.Framework.ResourceManagement.Progress
{
    public interface IProgressSaver
    {
        void Save<T>(T obj);
        T Get<T>();
    }
}