using UnityEngine;
using Zenject;

namespace Project.Scripts.Game
{
    public class BootStrapInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private Bootstrapper _bootstrapper;

        public void Initialize()
        {
            Container.Inject(_bootstrapper);
        }
    }
}