using Commands.Framework.BaseCommands;
using Cysharp.Threading.Tasks;

namespace Commands.Framework.Core
{
    public interface ICommandExecutor
    {
        UniTask Execute<T>() where T : ICommand;
        UniTask Execute<T>(ICommandPayload payload) where T : ICommand;
    }
}