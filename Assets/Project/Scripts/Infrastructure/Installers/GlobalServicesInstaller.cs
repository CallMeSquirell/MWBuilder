using AssetManagement.Framework.Configs;
using Project.Scripts.Infrastructure.Services;
using Zenject;

namespace Project.Scripts.Infrastructure.Installers
{
    public class GlobalServicesInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IConfigService>().To<MMBuilderConfigService>().AsSingle();
        }
    }
}