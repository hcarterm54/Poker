using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerApp.Tests
{
    public static class HandBuilder
    {

        public static string[] BuildMatchingPairLeft()
        {
            return new string[5] { "TS", "9D", "4S", "TH", "2H" };
        }

        public static string[] BuildMatchingPairRight()
        {
            return new string[5] { "TC", "9S", "4C", "TD", "2C" };
        }
        public static string[] BuildHighCard()
        {
            return new string[5] { "JC", "KD", "7C", "3S", "9H" };
        }

        public static string[] BuildPair()
        {
            return new string[5] { "TS", "9D", "4S", "TH", "2H" };
        }

        public static string[] BuildTwoPair()
        {
            return new string[5] { "9c", "6C", "5D", "9h", "5H" };
        }

        public static string[] BuildThreeOfAKind()
        {
            return new string[5] { "6S", "QH", "6C", "2C", "6D" };
        }

        public static string[] BuildStraight()
        {
            return new string[5] { "5D", "7S", "9D", "6H", "8C" };
        }

        public static string[] BuildStraightWithAceHigh()
        {
            return new string[5] { "QD", "TH", "JC", "KS", "AH" };
        }

        public static string[] BuildStraightWithAceLow()
        {
            return new string[5] { "5H", "2H", "AC", "3D", "4S" };
        }

        public static string[] BuildFlush()
        {
            return new string[5] { "TS", "6S", "7S", "2S", "QS" };
        }

        public static string[] BuildFourOfAKind()
        {
            return new string[5] { "TS", "6D", "TD", "TC", "TH" };
        }

        public static string[] BuildFullHouse()
        {
            return new string[5] { "9C", "4H", "9H", "9S", "4D" };
        }

        public static string[] BuildStraightFlush()
        {
            return new string[5] { "QD", "KD", "9D", "JD", "TD" };
        }


        public static string[] BuildAceLowStraightFlush()
        {
            return new string[5] { "5C", "2C", "AC", "3C", "4C" };
        }

        public static string[] BuildRoyalFlush()
        {
            return new string[5] { "KC", "TC", "AC", "QC", "JC" };
        }

    }
}
