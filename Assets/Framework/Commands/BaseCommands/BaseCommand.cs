using Cysharp.Threading.Tasks;

namespace Framework.Commands.BaseCommands
{
    public abstract class BaseCommand : ICommand
    {
        private readonly UniTaskCompletionSource _completionSource = new();

        protected UniTask Task => _completionSource.Task;
        
        protected void Release()
        {
            _completionSource.TrySetResult();
        }

        protected void Abort()
        {
            _completionSource.TrySetCanceled();
        }

        public virtual void Dispose(){}
    }
}