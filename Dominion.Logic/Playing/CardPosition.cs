using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Dominion.Logic.Playing.Information;

namespace Dominion.Logic.Playing
{
	public sealed class Player
	{
		private const int CardsToDrawEachTurn = 5;

		public IDeckInformation Deck => _deck;
		public IHandInformation Hand => _hand;
		public IPlayingAreaInformation PlayingArea => _playingArea;
		public IDiscardPileInformation DiscardPile => _discardPile;

		private readonly Deck _deck;
		private readonly Hand _hand;
		private readonly PlayingArea _playingArea;
		private readonly DiscardPile _discardPile;

		public Player(Deck deck, Hand hand, PlayingArea playingArea, DiscardPile discardPile)
		{
			_deck = deck;
			_hand = hand;
			_playingArea = playingArea;
			_discardPile = discardPile;
		}

		public Result Play(CardType cardType)
		{
			Maybe<Card> playedCard = _hand.Play(cardType);
			if (playedCard.HasNoValue)
			{
				return Result.Failure($"Card {cardType} not in hand.");
			}
			_playingArea.Play(playedCard.Value);
			return Result.Ok();
		}

		public void EndTurn()
		{
			IEnumerable<Card> cardsToDiscard = _hand.Empty()
					.Concat(_playingArea.EndTurn());
			_discardPile.Add(cardsToDiscard);

			FillHandTo(CardsToDrawEachTurn);
		}

		private void FillHandTo(int numberOfCards)
		{
			int drawnCards = TryDrawing(numberOfCards);
			if (drawnCards != numberOfCards)
			{
				Shuffle();
				TryDrawing(numberOfCards - drawnCards);
			}
		}

		private int TryDrawing(int numberOfCards)
		{
			List<Card> drawnCards = _deck.Draw(numberOfCards).ToList();
			_hand.Add(drawnCards);
			return drawnCards.Count;
		}

		private void Shuffle()
		{
			IEnumerable<Card> cardsToShuffle = _discardPile.Reshuffle();
			_deck.ShuffleIn(cardsToShuffle);
		}
	}
}