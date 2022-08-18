using Commands.Framework.BaseCommands;

namespace Commands.Framework.Core
{
    public interface ICommandBinding
    {
        ICommandInfo Info { get; }
        void To<TBind>() where TBind : ICommand;
    }
}