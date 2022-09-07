using System.Collections.Generic;

namespace Project.Scripts.Core.Processors
{
    public class CardProcessorManager : ICardProcessor
    {
        private readonly List<ICardProcessor> _processors = new();

      
        public void AddProcessor(ICardProcessor takeProcessor)
        {
            _processors.Add(takeProcessor);
        }
    }
}