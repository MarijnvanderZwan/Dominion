using System.Collections.Generic;
using Dominion.Logic.Playing;
using Dominion.Logic.Tests.Builders;

namespace Dominion.Logic.Tests
{
	public sealed class HandBuilder
	{
		private CardListBuilder _cardListBuilder = new CardListBuilder();

		public HandBuilder WithCard(CardType cardType)
		{
			_cardListBuilder = _cardListBuilder.WithCard(cardType);
			return this;
		}

		public Hand Build()
		{
			return new Hand(_cardListBuilder.Build());
		}
	}
}