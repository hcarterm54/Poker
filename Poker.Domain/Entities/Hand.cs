using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Domain.Enums;
using Poker.Domain.Services;

namespace Poker.Domain.Entities
{
    public class Hand : IComparable<Hand>
    {

        public List<Card> Cards { get; set; }

        public Face HighCard
        {
            get
            {
                return Cards[4].Face;
            }
        }

        /// <summary>
        /// This property will hold the ranking - flush, straight, pair, etc.
        /// When comparing two hands, if one hand has a higher ranking the
        /// the other, no further comparison is required.
        /// </summary>
        public Ranking Ranking 
        {
            get
            {
                return HandEvaluator.EvaluateHand(this);
            }
        }

        //public List<Card> BuildHand(string[] cards)
        //{
        //    List<Card> result = new List<Card>();

        //    foreach (string item in cards)
        //    {

        //        var face = ParseFace(item[0]);
        //        var suit = ParseSuit(item[1]);

        //        //var card = new Card(face, suit);
        //        result.Add(new Card(face, suit));
        //    }
        //    return result;
        //}

        //public Face ParseFace(char v)
        //{
        //    Face result = Face.Two;

        //    switch (v)
        //    {
        //        case '2':
        //            break;
        //        case '3':
        //            result = Face.Three;
        //            break;
        //        case '4':
        //            result = Face.Four;
        //            break;
        //        case '5':
        //            result = Face.Five;
        //            break;
        //        case '6':
        //            result = Face.Six;
        //            break;
        //        case '7':
        //            result = Face.Seven;
        //            break;
        //        case '8':
        //            result = Face.Eight;
        //            break;
        //        case '9':
        //            result = Face.Nine;
        //            break;
        //        case 'T':
        //            result = Face.Ten;
        //            break;
        //        case 'J':
        //            result = Face.Jack;
        //            break;
        //        case 'Q':
        //            result = Face.Queen;
        //            break;
        //        case 'K':
        //            result = Face.King;
        //            break;
        //        case 'A':
        //            result = Face.Ace;
        //            break;
        //    }

        //    return result;
        //}

        //public Suit ParseSuit(char v)
        //{
        //    Suit result = Suit.Diamonds;

        //    switch (v)
        //    {
        //        case 'D':
        //            break;
        //        case 'H':
        //            result = Suit.Hearts;
        //            break;
        //        case 'C':
        //            result = Suit.Clubs;
        //            break;
        //        case 'S':
        //            result = Suit.Spades;
        //            break;
        //    }
        //    return result;
        //}

        public void Sort()
        {
            Cards = Cards.OrderBy(f => f.Face).ToList();
        }

        public int CompareTo(Hand other)
        {
            int thisWinner = 0;

            if (Ranking > other.Ranking) // this hand is a winner
            {
                thisWinner = 1;
            }

            else if (Ranking < other.Ranking)
            {
                thisWinner = -1;
            }
            else // Same ranking, so check down cards
            {
                for (int i = 1; i < Cards.Count; i++)
                {
                    if (Cards[i].Face > other.Cards[i].Face)
                    {
                        thisWinner = 1; // tie-breaker, declare the winner and exit
                        break;
                    }                        
                    else if (Cards[i].Face < other.Cards[i].Face)
                    {
                        thisWinner = -1; // tie-breaker, declare the winner and exit
                        break;
                    }
                    else
                        thisWinner = 0; // still a draw, keep checking cards
                }
            }

            return thisWinner;
        }
    }
}
