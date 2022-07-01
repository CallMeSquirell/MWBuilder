namespace Framework.Commands.ExecutableQueue
{
    public interface ICommandQueueFactory
    {
        ICommandQueue Create();
    }
}