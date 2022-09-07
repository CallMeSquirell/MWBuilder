using AssetManagement.Framework.Assets;
using AssetManagement.Framework.Configs;
using Zenject;

namespace AssetManagement.Framework.Installers
{
    public class ResourceManagementInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IAssetManager>().To<AssetManager>().AsSingle();
        }
    }
}