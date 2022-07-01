using System;

namespace Framework.Commands.Core.Impl
{
    public class CommandInfo : ICommandInfo
    {
        public Type BindedType { get; }
        
        public CommandInfo(Type bindedType)
        {
            BindedType = bindedType;
        }
    }
}