using Dominion.Logic.Playing;

namespace Dominion.Logic.Tests.Builders
{
	public class DiscardPileBuilder
	{
		private CardListBuilder _cardListBuilder = new CardListBuilder();

		public DiscardPileBuilder WithCard(CardType cardType)
		{
			_cardListBuilder = _cardListBuilder.WithCard(cardType);
			return this;
		}

		public DiscardPileBuilder WithCard(CardType cardType, int amount)
		{
			for (int i = 0; i < amount; i++)
			{
				WithCard(cardType);
			}
			return this;
		}

		public DiscardPile Build()
		{
			return new DiscardPile(_cardListBuilder.Build());
		}
	}
}