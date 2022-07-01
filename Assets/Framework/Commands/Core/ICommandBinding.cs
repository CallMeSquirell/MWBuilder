using Framework.Commands.BaseCommands;

namespace Framework.Commands.Core
{
    public interface ICommandBinding
    {
        ICommandInfo Info { get; }
        void To<TBind>() where TBind : ICommand;
    }
}