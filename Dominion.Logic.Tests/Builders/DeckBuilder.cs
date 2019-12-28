
using System.Collections.Generic;
using System.Linq;
using Dominion.Logic.Playing;

namespace Dominion.Logic.Tests.Builders
{
    internal class DeckBuilder
    {
	    private CardListBuilder _cardListBuilder = new CardListBuilder();

	    public DeckBuilder WithCard(CardType cardType)
	    {
		    _cardListBuilder = _cardListBuilder.WithCard(cardType);
			return this;
	    }

	    public DeckBuilder WithCard(CardType cardType, int amount)
	    {
		    for (int i = 0; i < amount; i++)
		    {
			    WithCard(cardType);
		    }
		    return this;
	    }

	    public Deck Build()
	    {
		    var queue = new Queue<Card>(_cardListBuilder.Build());
		    return new Deck(queue);
	    }
    }
}
