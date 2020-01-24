using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.App;

namespace PokerApp.Tests
{
    public class CardInputShould
    {
        [Test]
        public void GetMatrixShould()
        {
            var actual = Program.GetMatrixArray();

            Assert.That(actual.Length, Is.EqualTo(52));
        }

    }
}
