using Zenject;

namespace Commands.Framework.Commands.ExecutableQueue.Impl
{
    public class CommandQueueFactory : ICommandQueueFactory
    {
        private readonly IInstantiator _instantiator;

        public CommandQueueFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public ICommandQueue Create()
        {
            return _instantiator.Instantiate<CommandQueue>();
        }
    }
}