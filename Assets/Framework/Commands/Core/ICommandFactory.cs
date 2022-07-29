using Commands.Framework.Commands.BaseCommands;

namespace Commands.Framework.Commands.Core
{
    public interface ICommandFactory
    {
        ICommand Create(ICommandInfo binding);
    }
}