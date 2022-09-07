using System;
using System.Collections.Generic;
using Project.Scripts.Core.Cells.Mechanics;

namespace Project.Scripts.Core.Hand
{
    public class HandModel
    {
        public event Action<ICard> CardSelected;

        private List<ICard> _cards;

        public HandModel()
        {
            _cards = new List<ICard>();
        }

        public void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        public void SelectCard(ICard card)
        {
            CardSelected?.Invoke(card);
        }
    }
}