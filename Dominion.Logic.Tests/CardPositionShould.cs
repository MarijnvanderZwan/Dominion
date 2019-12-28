using CSharpFunctionalExtensions;
using Dominion.Logic.Playing;
using Dominion.Logic.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace Dominion.Logic.Tests
{
	public class CardManagementShould
	{
		[Fact]
		public void Return_Success_When_Playing_Known_Card()
		{
			CardManagement cardManagement = new CardManagementBuilder()
				.WithCardInHand(CardType.Copper)
				.Build();

			Result result = cardManagement.Play(CardType.Copper);

			Assert.True(result.IsSuccess);
		}

		[Fact]
		public void Return_Failure_When_Playing_Unknown_Card()
		{
			CardManagement cardManagement = new CardManagementBuilder()
				.Build();

			Result result = cardManagement.Play(CardType.Silver);

			Assert.True(result.IsFailure);
		}

		[Fact]
		public void Have_Card_In_PlayingArea_After_Playing_Card()
		{
			CardManagement cardManagement = new CardManagementBuilder()
				.WithCardInHand(CardType.Copper)
				.Build();
			cardManagement.PlayingArea.NumberOfCards.Should().Be(0);

			Result result = cardManagement.Play(CardType.Copper);

			Assert.True(result.IsSuccess);
			cardManagement.PlayingArea.NumberOfCards.Should().Be(1);
		}

		[Fact]
		public void Have_No_Cards_In_PlayingArea_After_End_Turn()
		{
			CardManagement cardManagement = new CardManagementBuilder()
				.WithCardInPlayingArea(CardType.Copper)
				.Build();
			cardManagement.PlayingArea.NumberOfCards.Should().Be(1);

			cardManagement.EndTurn();

			cardManagement.PlayingArea.NumberOfCards.Should().Be(0);
		}

		[Fact]
		public void Have_Cards_From_Hand_And_PlayingArea_In_DiscardPile_After_End_Turn()
		{
			CardManagement cardManagement = new CardManagementBuilder()
				.WithDefaultDeck()
				.WithCardInHand(CardType.Silver)
				.WithCardInPlayingArea(CardType.Copper)
				.Build();
			cardManagement.DiscardPile.NumberOfCards.Should().Be(0);

			cardManagement.EndTurn();

			cardManagement.DiscardPile.NumberOfCards.Should().Be(2);
		}

		[Fact]
		public void Have_Five_Cards_In_Hand_After_End_Turn()
		{
			CardManagement cardManagement = new CardManagementBuilder()
				.WithDefaultDeck()
				.Build();

			cardManagement.EndTurn();

			cardManagement.Hand.NumberOfCards.Should().Be(5);
		}

		[Fact]
		public void Take_Cards_From_DiscardPile_When_Deck_Is_Empty()
		{
			CardManagement cardManagement = new CardManagementBuilder()
				.WithDefaultDeckInDiscardPile()
				.Build();
			cardManagement.Deck.NumberOfCards.Should().Be(0);

			cardManagement.EndTurn();

			cardManagement.Hand.NumberOfCards.Should().Be(5);
		}

		[Fact]
		public void Take_Cards_From_DiscardPile_When_Deck_Is_Almost_Empty()
		{
			CardManagement cardManagement = new CardManagementBuilder()
				.WithDefaultDeckInDiscardPile()
				.WithCardInDeck(CardType.Copper)
				.WithCardInDeck(CardType.Copper)
				.Build();

			cardManagement.EndTurn();

			cardManagement.Hand.NumberOfCards.Should().Be(5);
		}

		[Fact]
		public void Draw_Less_Cards_When_Not_Enough_Cards_Are_Available()
		{
			CardManagement cardManagement = new CardManagementBuilder()
				.WithCardInDiscardPile(CardType.Copper)
				.WithCardInDeck(CardType.Copper)
				.WithCardInDeck(CardType.Copper)
				.Build();

			cardManagement.EndTurn();

			cardManagement.Hand.NumberOfCards.Should().Be(3);
		}
	}
}