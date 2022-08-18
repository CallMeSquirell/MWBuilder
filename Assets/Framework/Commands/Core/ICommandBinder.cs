using Commands.Framework.BaseCommands;

namespace Commands.Framework.Core
{
    public interface ICommandBinder
    {
        ICommandBinding Bind<T>() where T : ICommand;
        void UnBind<T>() where T : ICommand;
        bool TryGetBind<T>(out ICommandBinding binding) where T : ICommand;
    }
}