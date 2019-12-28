using System.Collections.Generic;

namespace Dominion.Logic.Tests.Builders
{
	public class CardListBuilder
	{
		private readonly CardFactory _cardFactory = new CardFactory();
		private readonly List<Card> _cards = new List<Card>();

		public CardListBuilder WithCard(CardType cardType)
		{
			_cards.Add(_cardFactory.Create(cardType));
			return this;
		}

		public IEnumerable<Card> Build()
		{
			return _cards;
		}
	}
}