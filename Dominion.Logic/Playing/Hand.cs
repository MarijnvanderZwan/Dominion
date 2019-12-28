using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Dominion.Logic.Playing.Information;

namespace Dominion.Logic.Playing
{
	public class Hand : IHandInformation
	{
		public IReadOnlyList<Card> Cards => _cards;
		private readonly List<Card> _cards;

		public int NumberOfCards => _cards.Count;

		public Hand(IEnumerable<Card> cards)
		{
			_cards = cards.ToList();
		}

		public Hand() : this (new List<Card>())
		{
		}

		public void Add(IEnumerable<Card> cards)
		{
			_cards.AddRange(cards);
		}

		public Maybe<Card> Play(CardType cardType)
		{
			Maybe<Card> maybeCard = _cards.FirstOrDefault(card => card.Type == cardType);
			if (maybeCard.HasValue)
			{
				_cards.Remove(maybeCard.Value);
			}
			return maybeCard;
		}

		public IEnumerable<Card> Empty()
		{
			List<Card> cardsToDiscard = _cards.ToList();
			_cards.Clear();
			return cardsToDiscard;
		}
	}
}