using Poker.Domain.Enums;

namespace Poker.Domain.Entities
{

    public class Card
    {
        public Card(Face face, Suit suit)
        {
            Face = face;
            Suit = suit;
        }

        public Face Face { get; }
        public Suit Suit { get; }
    }
}

