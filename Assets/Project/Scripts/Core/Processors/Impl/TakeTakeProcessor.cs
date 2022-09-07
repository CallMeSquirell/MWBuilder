using Project.Scripts.Core.Cells.Mechanics;
using Project.Scripts.Core.Hand;
using Project.Scripts.Core.Input;
using Project.Scripts.Core.Input.Strategy;

namespace Project.Scripts.Core.Processors
{
    public class TakeTakeProcessor : BaseTakeProcessor<IPickUpCard>
    {
        private FieldInputModel _fieldInputModel;

        protected override void InternalTake(IPickUpCard processableCard)
        {
            
        }

        protected override void InternalReveal(IPickUpCard processableCard)
        {
           
        }

        protected override void InternalUse(IPickUpCard processableCard)
        {
            _fieldInputModel.ApplyStrategy(new SelectStackStrategy());
        }
    }
}