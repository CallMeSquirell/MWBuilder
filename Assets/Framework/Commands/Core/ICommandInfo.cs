using System;

namespace Commands.Framework.Core
{
    public interface ICommandInfo
    {
        Type BindedType { get; }
    }
}