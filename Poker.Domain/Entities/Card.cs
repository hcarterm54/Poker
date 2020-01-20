using Poker.Domain.Enums;

namespace Poker.Domain.Entities
{

    public class Card : SystemCard
    {
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override Rank Rank { get; }
        public Suit Suit { get; }
    }
}

