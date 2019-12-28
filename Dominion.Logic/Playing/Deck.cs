using System;
using System.Collections.Generic;
using System.Linq;
using Dominion.Logic.Playing.Information;
using MoreLinq;

namespace Dominion.Logic.Playing
{
	public class Deck : IDeckInformation
	{
		public IReadOnlyList<Card> Cards => _cards.ToList();
		private readonly Queue<Card> _cards;

		public int NumberOfCards => _cards.Count;

		public Deck(Queue<Card> cards)
		{
			_cards = cards;
		}

		public Deck() : this(new Queue<Card>())
		{
		}

		public IEnumerable<Card> Draw(int amount)
		{
			int cardsToTake = Math.Min(amount, _cards.Count);
			for (int i = 0; i < cardsToTake; i++)
			{
				yield return _cards.Dequeue();
			}
		}

		public void ShuffleIn(IEnumerable<Card> cardsToShuffle)
		{
			cardsToShuffle.ForEach(_cards.Enqueue);
		}
	}
}