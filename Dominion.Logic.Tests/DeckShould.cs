using System.Collections.Generic;
using System.Linq;
using Dominion.Logic.Playing;
using Dominion.Logic.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace Dominion.Logic.Tests
{
	public class DeckShould
	{
		[Fact]
		public void Draw_No_Cards_When_Drawing_From_An_Empty_Deck()
		{
			var deck = new Deck();

			IEnumerable<Card> result = deck.Draw(5);

			result.Should().HaveCount(0);
		}

		[Fact]
		public void Draw_Correct_Card_When_Drawing_Single_Card_From_Two_Card_Deck()
		{
			Deck deck = new DeckBuilder()
				.WithCard(CardType.Copper)
				.WithCard(CardType.Silver)
				.Build();

			List<Card> cards = deck.Draw(1).ToList();

			cards.Should().HaveCount(1);
			Assert.Equal(CardType.Copper, cards.First().Type);
			deck.NumberOfCards.Should().Be(1);
		}

		[Fact]
		public void Add_ShuffledIn_Cards_To_BottomOfDeck()
		{
			Deck deck = new DeckBuilder()
				.WithCard(CardType.Copper)
				.Build();
			deck.ShuffleIn(
				new CardListBuilder()
					.WithCard(CardType.Gold)
					.Build());

			List<Card> cards = deck.Draw(2).ToList();

			cards.Should().HaveCount(2);
			Assert.Equal(CardType.Gold, cards.Last().Type);
		}

		[Fact]
		public void Show_Correct_Amount_Of_Cards()
		{
			Deck deck = new DeckBuilder()
				.WithCard(CardType.Copper)
				.WithCard(CardType.Copper)
				.Build();

			int numberOfCards = deck.NumberOfCards;

			Assert.Equal(2, numberOfCards);
		}
	}
}