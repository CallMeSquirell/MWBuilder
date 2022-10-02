using Framework.UI.Animations.Scripts.Constants;
using UI.Framework.Data;

namespace Project.Scripts.Constants
{
    public static class ViewNames
    {
        public static IViewDefinition MetaScreen = new ViewDefinition("MetaScreen", LayersIndexes.Screen, "UI/MetaScreen");
        public static IViewDefinition CoreScreen = new ViewDefinition("CoreScreen", LayersIndexes.Screen, "UI/CoreScreen");
        public static IViewDefinition Settings = new ViewDefinition("Settings", LayersIndexes.PopUp, "UI/Settings");
    }
}