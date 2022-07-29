using AssetManagement.Framework.ResourceManagement.Assets;
using AssetManagement.Framework.ResourceManagement.Configs;
using Zenject;

namespace AssetManagement.Framework.ResourceManagement.Installers
{
    public class ResourceManagementInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IAssetManager>().To<AssetManager>().AsSingle();
            Container.Bind<IConfigService>().To<ConfigService>().AsSingle();
        }
    }
}