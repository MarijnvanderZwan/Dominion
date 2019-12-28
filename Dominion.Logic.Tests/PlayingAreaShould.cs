using System.Collections.Generic;
using System.Linq;
using Dominion.Logic.Playing;
using Dominion.Logic.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace Dominion.Logic.Tests
{
	public class PlayingAreaShould
	{
		private readonly CardFactory _cardFactory = new CardFactory();

		[Fact]
		public void Be_Empty_And_Return_All_Cards_After_End_Turn_Is_Called()
		{
			PlayingArea playingArea = new PlayingAreaBuilder()
				.WithCard(CardType.Silver)
				.WithCard(CardType.Silver)
				.Build();

			List<Card> cards = playingArea.EndTurn().ToList();

			playingArea.Cards.Should().BeEmpty();
			cards.Should().HaveCount(2);
			cards.Should().OnlyContain(card => card.Type == CardType.Silver);
		}

		[Fact]
		public void Add_Played_Card()
		{
			Card cardToPlay = _cardFactory.Create(CardType.Copper);
			var playingArea = new PlayingArea();

			playingArea.Play(cardToPlay);

			playingArea.Cards.Should().HaveCount(1);
			playingArea.Cards.Should().Contain(card => card.Type == cardToPlay.Type);
		}

		[Fact]
		public void Show_Correct_Amount_Of_Cards()
		{
			PlayingArea playingArea = new PlayingAreaBuilder()
				.WithCard(CardType.Silver)
				.WithCard(CardType.Silver)
				.Build();

			int numberOfCards = playingArea.NumberOfCards;

			Assert.Equal(2, numberOfCards);
		}
	}
}