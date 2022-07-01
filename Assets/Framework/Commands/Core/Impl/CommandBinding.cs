using Framework.Commands.BaseCommands;

namespace Framework.Commands.Core.Impl
{
    public class CommandBinding : ICommandBinding
    {
        public ICommandInfo Info { get; private set; }

        public void To<TBind>() where TBind : ICommand
        {
            Info = new CommandInfo(typeof(TBind));
        }
    }
}