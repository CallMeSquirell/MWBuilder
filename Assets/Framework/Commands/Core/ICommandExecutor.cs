using Cysharp.Threading.Tasks;
using Framework.Commands.BaseCommands;

namespace Framework.Commands.Core
{
    public interface ICommandExecutor
    {
        UniTask Execute<T>() where T : IExecutableCommand;
        UniTask Execute<T>(ICommandPayload payload) where T : IExecutableCommand<ICommandPayload>;
    }
}