using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Domain.Enums;

namespace Poker.Domain.Entities
{
    public class Hand : IComparable<Hand>
    {

        public List<Card> Cards { get; set; } 
        public int CompareTo(Hand other)
        {
            throw new NotImplementedException();
        }
    }
}
