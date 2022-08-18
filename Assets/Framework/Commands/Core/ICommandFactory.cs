using Commands.Framework.BaseCommands;

namespace Commands.Framework.Core
{
    public interface ICommandFactory
    {
        ICommand Create(ICommandInfo binding);
    }
}