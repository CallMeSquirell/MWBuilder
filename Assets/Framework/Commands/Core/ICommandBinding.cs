using Commands.Framework.Commands.BaseCommands;

namespace Commands.Framework.Commands.Core
{
    public interface ICommandBinding
    {
        ICommandInfo Info { get; }
        void To<TBind>() where TBind : ICommand;
    }
}