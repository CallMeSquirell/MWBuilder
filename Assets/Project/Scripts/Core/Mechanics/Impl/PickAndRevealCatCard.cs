namespace Project.Scripts.Core.Cells.Mechanics
{
    public class PickAndRevealCatCard : BaseCatCard, IPickUpCard, IRevealCard
    {
        private readonly int _pickUpCount;
        private readonly int _revealCount;
        private readonly int _range;

        int IPickUpCard.Count => _pickUpCount;

        int IRevealCard.Count => _revealCount;

        int IRevealCard.Range => _range;

        public PickAndRevealCatCard(int pickUpCount, int revealCount, int range)
        {
            _pickUpCount = pickUpCount;
            _revealCount = revealCount;
            _range = range;
        }
    }
}