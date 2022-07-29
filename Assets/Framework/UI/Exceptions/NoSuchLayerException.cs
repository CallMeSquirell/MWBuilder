using System;

namespace UI.Framework.UI.Exceptions
{
    public class NoSuchLayerException : Exception
    {
        public override string Message { get; } = "No such layer";
    }
}