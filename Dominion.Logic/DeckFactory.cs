using System;
using System.Collections.Generic;
using System.Linq;
using Dominion.Logic.Playing;

namespace Dominion.Logic
{
	public class DeckFactory
	{
		private readonly CardFactory _cardFactory;

		public DeckFactory(CardFactory cardFactory)
		{
			_cardFactory = cardFactory;
		}

		public Deck CreateDefault()
		{
			IEnumerable<Card> defaultCards = CreateDefaultCards();
			return new Deck(new Queue<Card>(defaultCards));
		}

		public Deck CreateShuffledDefault()
		{
			List<Card> defaultCards = CreateDefaultCards().ToList();
			defaultCards.Shuffle(new Random());
			return new Deck(new Queue<Card>(defaultCards));
		}

		private IEnumerable<Card> CreateDefaultCards()
		{
			IEnumerable<Card> coppers = Enumerable.Repeat(_cardFactory.Create(CardType.Copper), 7);
			IEnumerable<Card> estates = Enumerable.Repeat(_cardFactory.Create(CardType.Estate), 3);
			return coppers.Concat(estates);
		}
	}
}