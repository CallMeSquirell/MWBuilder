using UnityEngine;
using Zenject;

namespace Project.Scripts.Infrastructure.Installers
{
    public class BootStrapInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private Bootstrapper _bootstrapper;

        public void Initialize()
        {
            Container.Inject(_bootstrapper);
        }

        public override void InstallBindings()
        {
         
        }
    }
}