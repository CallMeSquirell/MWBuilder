using System.IO;
using UnityEngine;

namespace AssetManagement.Framework.ResourceManagement.Progress
{
    public class ProgressSaver : IProgressSaver
    {
        private string Path => Application.persistentDataPath;

        void IProgressSaver.Save<T>(T obj)
        {
            var json = JsonUtility.ToJson(obj);
            File.WriteAllText($"{Path}/{nameof(T)}.data", json);
        }

        T IProgressSaver.Get<T>()
        {
            var json = File.ReadAllText($"{Path}/{nameof(T)}.data");
            return JsonUtility.FromJson<T>(json);
        }
    }
}