using System.Collections.Generic;
using CSharpFunctionalExtensions;
using Dominion.Logic.Playing;
using Dominion.Logic.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace Dominion.Logic.Tests
{
	public class HandShould
	{
		[Fact]
		public void Add_Cards_Correctly()
		{
			var hand = new Hand();
			IEnumerable<Card> cardsToAdd = new CardListBuilder()
				.WithCard(CardType.Copper)
				.WithCard(CardType.Silver)
				.Build();

			hand.Add(cardsToAdd);

			hand.Cards.Should().HaveCount(2);
			hand.Cards.Should().Contain(card => card.Type == CardType.Copper);
			hand.Cards.Should().Contain(card => card.Type == CardType.Silver);
		}

		[Fact]
		public void Empty_Correctly()
		{
			Hand hand = new HandBuilder()
				.WithCard(CardType.Silver)
				.WithCard(CardType.Gold)
				.Build();

			IEnumerable<Card> discardedCards = hand.Empty();

			hand.Cards.Should().BeEmpty();
			discardedCards.Should().HaveCount(2);
		}

		[Fact]
		public void Remove_And_Return_Card_When_Playing_Card_In_Hand()
		{
			Hand hand = new HandBuilder()
				.WithCard(CardType.Silver)
				.Build();

			Maybe<Card> result = hand.Play(CardType.Silver);

			Assert.True(result.HasValue);
			Assert.Equal(CardType.Silver, result.Value.Type);
			hand.Cards.Should().BeEmpty();
		}

		[Fact]
		public void Do_Nothing_When_Playing_Card_Not_In_Hand()
		{
			Hand hand = new HandBuilder()
				.WithCard(CardType.Silver)
				.Build();

			Maybe<Card> result = hand.Play(CardType.Gold);

			Assert.False(result.HasValue);
			hand.Cards.Should().HaveCount(1);
		}

		[Fact]
		public void Show_Correct_Amount_Of_Cards()
		{
			Hand hand = new HandBuilder()
				.WithCard(CardType.Silver)
				.WithCard(CardType.Silver)
				.Build();

			int numberOfCards = hand.NumberOfCards;

			Assert.Equal(2, numberOfCards);
		}
	}
}