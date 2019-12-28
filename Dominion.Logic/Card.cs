using System.Runtime.CompilerServices;

namespace Dominion.Logic
{
	public class Card
	{
		public CardType Type { get; }
		public int Cost { get; }
		public int VictoryPoints { get; }

		public int ExtraCards { get; }
		public int ExtraActions { get; }
		public int ExtraBuys { get; }
		public int ExtraMoney { get; }

		private Card(
			CardType type,
			int cost,
			int victoryPoints,
			int extraCards,
			int extraActions,
			int extraBuys,
			int extraMoney)
		{
			Type = type;
			Cost = cost;
			VictoryPoints = victoryPoints;
			ExtraCards = extraCards;
			ExtraActions = extraActions;
			ExtraBuys = extraBuys;
			ExtraMoney = extraMoney;
		}

		public static Card CreateMoneyCard(CardType type, int cost, int amount)
		{
			return new Card(type, cost, 0, 0, 0, 0, amount);
		}

		public static Card CreateVictoryCard(CardType type, int cost, int amount)
		{
			return new Card(type, cost, amount, 0, 0, 0, 0);
		}

		public static Card CreateWhiteCard(CardType type, int cost, int cards, int actions, int buys, int money)
		{
			return new Card(type, cost, 0, cards, actions, buys, money);
		}

		public override bool Equals(object obj)
		{
			return obj is Card card && Equals(card);
		}

		public override int GetHashCode()
		{
			return (int) Type;
		}

		private bool Equals(Card other)
		{
			return Type == other.Type;
		}
	}
}