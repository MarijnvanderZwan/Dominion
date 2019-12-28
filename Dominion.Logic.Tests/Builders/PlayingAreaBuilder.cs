using Dominion.Logic.Playing;

namespace Dominion.Logic.Tests.Builders
{
	public class PlayingAreaBuilder
	{
		private CardListBuilder _cardListBuilder = new CardListBuilder();

		public PlayingAreaBuilder WithCard(CardType cardType)
		{
			_cardListBuilder = _cardListBuilder.WithCard(cardType);
			return this;
		}

		public PlayingArea Build()
		{
			return new PlayingArea(_cardListBuilder.Build());
		}
	}
}