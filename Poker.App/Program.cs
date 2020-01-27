using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.App
{
    public class Program
    {
        private static string[] leftHand = new string[5];
        private static string[] rightHand = new string[5];

        static void Main(string[] args)
        {
            Game game = new Game();

            bool exit = false;

            PrintCardMatrix();

            while (!exit)
            {
                Console.WriteLine("Select Option:\r\n 1. New Game\r\n 2. Pick Winner\r\n 3. Exit");

                char x = (char)Console.Read();
                if (x == '1')

                {
                    InputCards();
                    //var winner = game.Play(leftHand, rightHand);
                    
                }
                else if (x == '2')
                {
                    PickWinner();
                }
                else if (x == '3')
                {
                    exit = true;
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                FlushKeyboard();
            }
        }

        /// <summary>
        /// Feed "hand" arrays to determine winner.
        /// Get the card values into objects over which rules
        /// can be applied including a sorting algrorithm
        /// </summary>
        private static void PickWinner()
        {
            Game game = new Game();

            string winner = game.Play(leftHand, rightHand);
            Console.WriteLine("And the winner iiiisss.... " + winner + " hand!!!");
        }

        /// <summary>
        /// Get input from user and store in string arrays.
        /// First iteration only takes input; no validation other than
        /// correct number of cards.
        /// 
        /// Version 2 We would add validation to ensure that only valid card values
        /// are being entered, and that duplicate entries don't occur in 
        /// either hand (e.g. both players can't be dealt the same card nor
        /// can the one player be dealt the same card twice)
        /// </summary>
        private static void InputCards()
        {
            int leftCount = 0;
            int rightCount = 0;

            Console.WriteLine("Input left hand cards:");
            while (leftCount < 5)
            {
                var response = Console.ReadLine();
                // first time through loop doesn't wait for response
                if (String.IsNullOrEmpty(response))
                    continue;

                leftHand[leftCount] = response;
                leftCount++;
            }

            Console.WriteLine("Input right hand cards:");
            while (rightCount < 5)
            {
                var response = Console.ReadLine();
                // first time through loop doesn't wait for response
                if (String.IsNullOrEmpty(response))
                    continue;

                rightHand[rightCount] = response;
                rightCount++;
            }

            Console.WriteLine("Last card entered: " + rightHand[4]);

            //Console.ReadLine();

        }

        #region Card matrix display
        /// <summary>
        /// Build structure to display valid card codes
        /// on the console for users.
        /// </summary>
        /// <returns></returns>
        public static string[,] GetMatrixArray()
        {
            string[,] altMatrix = new string[4, 13] { { "2H", "3H","4H","5H","6H","7H","8H","9H","TH","JH","QH","KH","AH" },
                                                      { "2C", "3C","4C","5C","6C","7C","8C","9C","TC","JC","QC","KC","AC" },
                                                      { "2D", "3D","4D","5D","6D","7D","8D","9D","TD","JD","QD","KD","AD" },
                                                      { "2S", "3S","4S","5S","6S","7S","8S","9S","TS","JS","QS","KS","AS" } };
            return altMatrix;
        }

        /// <summary>
        /// Display valid card codes in a table/matrix format
        /// </summary>
        private static void PrintCardMatrix()
        {
            Console.WriteLine("Valid cards to deal. S - Spades, H - Hearts, C - Clubs, D - Diamonds");
            Console.WriteLine("--------------------------------------------------------------------");
            string[,] cards = GetMatrixArray();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Console.Write(cards[i, j] + " ");
                }
                Console.WriteLine("\n\r");
            }
        }

        #endregion

        private static void FlushKeyboard()
        {
            while (Console.In.Peek() != -1)
                Console.In.Read();
        }
    }
}
