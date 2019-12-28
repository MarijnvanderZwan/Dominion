using System;

namespace Dominion.Logic
{
	public class CardFactory
	{
		public Card Create(CardType cardType)
		{
			return cardType switch
			{
				CardType.Copper => Card.CreateMoneyCard(CardType.Copper, 0, 1),
				CardType.Silver => Card.CreateMoneyCard(CardType.Silver, 3, 2),
				CardType.Gold => Card.CreateMoneyCard(CardType.Gold, 6, 3),
				CardType.Estate => Card.CreateVictoryCard(CardType.Estate, 2, 1),
				CardType.Duchy => Card.CreateVictoryCard(CardType.Duchy, 5, 3),
				CardType.Province => Card.CreateVictoryCard(CardType.Province, 8, 6),
				CardType.Market => Card.CreateWhiteCard(CardType.Market, 5, 1, 1, 1, 1),
				CardType.Smithy => Card.CreateWhiteCard(CardType.Smithy, 4, 3, 0, 0, 0),
				CardType.Village => Card.CreateWhiteCard(CardType.Village, 3, 1, 2, 0, 0),
				_ => throw new ArgumentOutOfRangeException(nameof(cardType), cardType, null)
			};
		}
	}
}