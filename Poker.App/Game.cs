using Poker.Domain.Entities;
using Poker.Domain.Enums;
using Poker.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.App
{
    public class Game
    {
        public string Play(string[] left, string[] right)
        {
            string winner;
            // build Hand objects for each player

            Hand leftHand = new Hand();
            leftHand.Cards = HandServices.BuildHand(left);
            leftHand.Sort();

            Hand rightHand = new Hand();
            rightHand.Cards = HandServices.BuildHand(right);
            rightHand.Sort();

            var result = leftHand.CompareTo(rightHand);

            if (result == -1)
                winner = "right";
            else if (result == 1)
                winner = "left";
            else
                winner = "draw";

            return winner;
        }

    }
}
