using Poker.Domain.Entities;
using Poker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Domain.Services
{
    public class HandEvaluator
    {
        private static Ranking _rank;

        public static Ranking EvaluateHand(Hand hand)
        {
            var cards = hand.Cards;
            bool isFlush;

            int[] faces = new int[13];
            int[] suits = new int[4];

            foreach (var card in cards)
            {
                faces[(int)card.Face - 2]++;
                suits[(int)card.Suit]++;
            }

            // evaluate faces for grouping
            _rank = EvaluateFace(faces); // 

            if (_rank < Ranking.OnePair) // if ranking is a pair or higher, can't be a straight or flush
            {
                isFlush = EvaluateSuit(cards);

                _rank = EvaluateStraight(cards, isFlush);
            }
            return _rank;
        }

        /// <summary>
        /// high card / one pair / two pair / three / full house
        /// </summary>
        /// <param name="faces"></param>
        /// <returns></returns>
        private static Ranking EvaluateFace(int[] faces)
        {
            // Default is lowest hand
            Ranking rank = Ranking.HighCard;

            // 
            for (int i = 0; i < faces.Length; i++)
            {
                if (faces[i] == 0) // no cards of this rank
                    continue;

                if (faces[i] == 4)
                {
                    rank = Ranking.FourOfAKind;
                }
                else if (faces[i] == 3)
                {
                    if (rank == Ranking.OnePair) // already have a pair
                    {
                        rank = Ranking.FullHouse;
                        break;
                    }
                    else
                    {
                        rank = Ranking.ThreeOfAKind;
                    }
                }
                else if (faces[i] == 2) {
                    if (rank == Ranking.OnePair) // already have a pair
                    {
                        rank = Ranking.TwoPair;
                        break;
                    }
                    else if (rank == Ranking.ThreeOfAKind) // already have three of a kind
                    {
                        rank = Ranking.FullHouse;
                        break;
                    }
                    else
                    {
                        rank = Ranking.OnePair;
                    }
                }

            }
            //if (IsFlush(cards))
            //    _rank = Ranking.Flush;

            return rank;
        }

        /// <summary>
        /// All cards must be the same suit
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static bool EvaluateSuit(List<Card> cards)
        {
            int hearts = 0;
            int diamonds = 0;
            int clubs = 0;
            int spades = 0;

            foreach (var card in cards)
            {
                if (card.Suit == Suit.Hearts)
                    hearts++;
                else if (card.Suit == Suit.Diamonds)
                    diamonds++;
                else if (card.Suit == Suit.Clubs)
                    clubs++;
                else
                    spades++;
            }

            return (hearts == 5 || diamonds == 5 || clubs == 5 || spades == 5);
        }

        /// <summary>
        /// Cards must be in sequence, any break means that a straight does 
        /// not exist. The Ace may function as the low card in a straight with 
        /// cards 2 - 5 or high card in a straight. Check for the existence
        /// of a flush to determine straight flush including royal flush.
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="isFlush"></param>
        /// <returns></returns>
        private static Ranking EvaluateStraight(List<Card> cards, bool isFlush)
        {
            var rank = Ranking.Straight;
            var highCard = cards[cards.Count-1].Face;
            bool isAceLow = false;

            // face values in sequence
            for (int i = 0; i < cards.Count; i++)
            {
                if (i == 0) continue;
                if (cards[i].Face - cards[i - 1].Face == 1)
                {
                    continue;
                }
                else 
                {
                    if (i == 4 && highCard == Face.Ace) 
                    {
                        // Ace low straight
                        isAceLow = true;
                    }
                    else 
                    {
                        rank = Ranking.HighCard;
                    }
                    
                    break;
                }
            }

            if (isFlush)
            {
                if (rank == Ranking.Straight)
                {
                    if (highCard == Face.Ace && !isAceLow)
                        rank = Ranking.RoyalFlush;
                    else
                        rank = Ranking.StraightFlush;
                }
                else
                {
                    rank = Ranking.Flush;
                }
            }
            return rank;
        }
    }
}
