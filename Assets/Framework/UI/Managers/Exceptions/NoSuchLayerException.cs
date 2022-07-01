using System;

namespace Framework.UI.Managers.Exceptions
{
    public class NoSuchLayerException : Exception
    {
        public override string Message { get; } = "No such layer";
    }
}