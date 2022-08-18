using System;

namespace Commands.Framework.Core.Impl
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