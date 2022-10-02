using Commands.Framework.BaseCommands;
using UnityEngine;

namespace Project.Scripts.UI.Commands
{
    public class TeleportCommandPayload : ICommandPayload
    {
        public Vector3 Position { get; set; }
    }
}