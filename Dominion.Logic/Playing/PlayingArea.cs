using System.Collections.Generic;
using System.Linq;
using Dominion.Logic.Playing.Information;

namespace Dominion.Logic.Playing
{
	public class PlayingArea : IPlayingAreaInformation
	{
		public IEnumerable<Card> Cards => _cards;
		private readonly List<Card> _cards;

		public int NumberOfCards => _cards.Count;

		public PlayingArea(IEnumerable<Card> cards)
		{
			_cards = cards.ToList();
		}

		public PlayingArea() : this(new List<Card>())
		{
		}

		public void Play(Card card)
		{
			_cards.Add(card);
		}

		public IEnumerable<Card> EndTurn()
		{
			List<Card> cardsToDiscard = _cards.ToList();
			_cards.Clear();
			return cardsToDiscard;
		}

	}
}