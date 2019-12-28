using System.Collections.Generic;
using System.Linq;
using Dominion.Logic.Playing;
using Dominion.Logic.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace Dominion.Logic.Tests
{
	public class DiscardPileShould
	{
		private readonly CardFactory _cardFactory = new CardFactory();

		[Fact]
		public void Add_Card_Correctly()
		{
			Card cardToAdd = _cardFactory.Create(CardType.Copper);
			var discardPile = new DiscardPile();

			discardPile.Add(cardToAdd);

			discardPile.Cards.Should().HaveCount(1);
			Assert.Equal(CardType.Copper, discardPile.Cards.First().Type);
		}

		[Fact]
		public void Be_Empty_After_Reshuffle()
		{
			DiscardPile discardPile = new DiscardPileBuilder()
				.WithCard(CardType.Copper)
				.WithCard(CardType.Copper)
				.Build();

			List<Card> result = discardPile.Reshuffle().ToList();

			discardPile.Cards.Should().BeEmpty();
			result.Should().HaveCount(2);
			result.Should().OnlyContain(card => card.Type == CardType.Copper);
		}

		[Fact]
		public void Show_Correct_Amount_Of_Cards()
		{
			DiscardPile discardPile = new DiscardPileBuilder()
				.WithCard(CardType.Copper)
				.WithCard(CardType.Copper)
				.Build();

			int numberOfCards = discardPile.NumberOfCards;

			Assert.Equal(2, numberOfCards);
		}
	}
}