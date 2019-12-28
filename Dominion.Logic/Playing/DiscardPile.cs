using System.Collections.Generic;
using System.Linq;
using Dominion.Logic.Playing.Information;

namespace Dominion.Logic.Playing
{
	public class DiscardPile : IDiscardPileInformation
	{
		public IReadOnlyList<Card> Cards => _cards;
		private readonly List<Card> _cards;

		public int NumberOfCards => _cards.Count;

		public DiscardPile(IEnumerable<Card> cards)
		{
			_cards = cards.ToList();
		}

		public DiscardPile() : this(new List<Card>())
		{
		}

		public void Add(Card card)
		{
			_cards.Add(card);
		}

		public void Add(IEnumerable<Card> cards)
		{
			_cards.AddRange(cards);
		}

		public IEnumerable<Card> Reshuffle()
		{
			List<Card> cardsToShuffle = _cards.ToList();
			_cards.Clear();
			return cardsToShuffle;
		}
	}
}