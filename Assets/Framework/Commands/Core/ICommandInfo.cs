using System;

namespace Framework.Commands.Core
{
    public interface ICommandInfo
    {
        Type BindedType { get; }
    }
}