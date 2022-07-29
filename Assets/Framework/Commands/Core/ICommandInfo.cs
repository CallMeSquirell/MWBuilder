using System;

namespace Commands.Framework.Commands.Core
{
    public interface ICommandInfo
    {
        Type BindedType { get; }
    }
}