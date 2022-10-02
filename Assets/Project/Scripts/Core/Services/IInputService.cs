using UnityEngine;
using Utils.Framework.Property;

namespace Project.Scripts.Meta.Input
{
    public interface IInputService
    {
        Vector2 Direction { get; }
        IBindableProperty<bool> PressedKeyE { get; }
    }
}