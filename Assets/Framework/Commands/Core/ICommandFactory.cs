using Framework.Commands.BaseCommands;

namespace Framework.Commands.Core
{
    public interface ICommandFactory
    {
        ICommand Create(ICommandInfo binding);
    }
}