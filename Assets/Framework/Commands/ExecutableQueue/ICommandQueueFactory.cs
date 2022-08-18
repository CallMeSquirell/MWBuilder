namespace Commands.Framework.ExecutableQueue
{
    public interface ICommandQueueFactory
    {
        ICommandQueue Create();
    }
}