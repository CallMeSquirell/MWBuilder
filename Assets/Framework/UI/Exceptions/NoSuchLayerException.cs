using System;

namespace UI.Framework.Exceptions
{
    public class NoSuchLayerException : Exception
    {
        public override string Message { get; } = "No such layer";
    }
}