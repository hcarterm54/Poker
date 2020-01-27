using Poker.Domain.Entities;
using Poker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Domain.Services
{
    public static class HandServices
    {

        public static List<Card> BuildHand(string[] cards)
        {
            List<Card> result = new List<Card>();

            foreach (string item in cards)
            {

                var face = ParseFace(item[0]);
                var suit = ParseSuit(item[1]);

                //var card = new Card(face, suit);
                result.Add(new Card(face, suit));
            }
            return result;
        }



        private static Face ParseFace(char v)
        {
            Face result = Face.Two;

            switch (v)
            {
                case '2':
                    break;
                case '3':
                    result = Face.Three;
                    break;
                case '4':
                    result = Face.Four;
                    break;
                case '5':
                    result = Face.Five;
                    break;
                case '6':
                    result = Face.Six;
                    break;
                case '7':
                    result = Face.Seven;
                    break;
                case '8':
                    result = Face.Eight;
                    break;
                case '9':
                    result = Face.Nine;
                    break;
                case 'T':
                    result = Face.Ten;
                    break;
                case 'J':
                    result = Face.Jack;
                    break;
                case 'Q':
                    result = Face.Queen;
                    break;
                case 'K':
                    result = Face.King;
                    break;
                case 'A':
                    result = Face.Ace;
                    break;
            }

            return result;
        }

        private static Suit ParseSuit(char v)
        {
            Suit result = Suit.Diamonds;

            switch (v)
            {
                case 'D':
                    break;
                case 'H':
                    result = Suit.Hearts;
                    break;
                case 'C':
                    result = Suit.Clubs;
                    break;
                case 'S':
                    result = Suit.Spades;
                    break;
            }
            return result;
        }

    }
}
