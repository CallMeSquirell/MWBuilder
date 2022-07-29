using System;

namespace Commands.Framework.Commands.Core.Impl
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