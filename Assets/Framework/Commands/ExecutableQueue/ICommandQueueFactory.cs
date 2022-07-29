namespace Commands.Framework.Commands.ExecutableQueue
{
    public interface ICommandQueueFactory
    {
        ICommandQueue Create();
    }
}