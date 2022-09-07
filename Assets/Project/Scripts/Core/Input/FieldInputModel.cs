namespace Project.Scripts.Core.Input
{
    public class FieldInputModel
    {
        private ICoreInputStrategy _inputStrategy;

        public void ApplyStrategy(ICoreInputStrategy inputStrategy)
        {
            _inputStrategy = inputStrategy;
        }
    }
}