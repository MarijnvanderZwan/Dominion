using Dominion.Logic.Playing;

namespace Dominion.Logic.Tests.Builders
{
	public class CardPositionBuilder
	{
		private DeckBuilder _deckBuilder = new DeckBuilder();
		private HandBuilder _handBuilder = new HandBuilder();
		private PlayingAreaBuilder _playingAreaBuilder = new PlayingAreaBuilder();
		private DiscardPileBuilder _discardPileBuilder = new DiscardPileBuilder();

		public CardPositionBuilder WithDefaultDeck()
		{
			_deckBuilder = _deckBuilder.WithCard(CardType.Copper, 7);
			_deckBuilder = _deckBuilder.WithCard(CardType.Estate, 3);
			return this;
		}

		public CardPositionBuilder WithCardInDeck(CardType cardType)
		{
			_deckBuilder = _deckBuilder.WithCard(cardType);
			return this;
		}

		public CardPositionBuilder WithCardInHand(CardType cardType)
		{
			_handBuilder = _handBuilder.WithCard(cardType);
			return this;
		}

		public CardPositionBuilder WithCardInPlayingArea(CardType cardType)
		{
			_playingAreaBuilder = _playingAreaBuilder.WithCard(cardType);
			return this;
		}

		public CardPositionBuilder WithDefaultDeckInDiscardPile()
		{
			_discardPileBuilder = _discardPileBuilder.WithCard(CardType.Copper, 7);
			_discardPileBuilder = _discardPileBuilder.WithCard(CardType.Estate, 3);
			return this;
		}

		public CardPositionBuilder WithCardInDiscardPile(CardType cardType)
		{
			_discardPileBuilder = _discardPileBuilder.WithCard(cardType);
			return this;
		}

		public CardPosition Build()
		{
			return new CardPosition(
				_deckBuilder.Build(),
				_handBuilder.Build(),
				_playingAreaBuilder.Build(),
				_discardPileBuilder.Build());
		}
	}
}