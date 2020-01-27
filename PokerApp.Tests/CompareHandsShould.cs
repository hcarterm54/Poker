using Autofac;
using NUnit.Framework;
using Poker.App;
using Poker.Domain;
using Poker.Domain.Entities;
using Poker.Domain.Enums;
using Poker.Domain.Services;

namespace PokerApp.Tests
{
    public class CompareHandsShould
    {
        [Test]
        public void PairBeatsHighCard()
        {
            // Arrange
            // build first hand - high card, second hand - one pair
            Game game = new Game();

            var left = HandBuilder.BuildPair();
            var right = HandBuilder.BuildHighCard();

            // Act
            string winner = game.Play(left, right);

            // Assert
            Assert.That(winner, Is.EqualTo("left"));
        }

        [Test]
        public void MatchingPairIsDraw()
        {
            // Arrange
            // build first hand - high card, second hand - one pair
            Game game = new Game();

            var right = HandBuilder.BuildMatchingPairLeft();

            var left = HandBuilder.BuildMatchingPairRight();


            // Act
            string winner = game.Play(left, right);

            // Assert
            Assert.That(winner, Is.EqualTo("draw"));
        }

        [Test]
        public void TwoPairBeatsOnePair()
        {
            // Arrange
            // build first hand - high card, second hand - one pair
            Game game = new Game();

            var left = HandBuilder.BuildTwoPair();
            var right = HandBuilder.BuildPair();


            // Act
            string winner = game.Play(left, right);

            // Assert
            Assert.That(winner, Is.EqualTo("left"));
        }

        [Test]
        public void ThreeOfAKindBeatsTwoPair()
        {
            // Arrange
            // build first hand - high card, second hand - one pair
            Game game = new Game();

            var left = HandBuilder.BuildThreeOfAKind();
            var right = HandBuilder.BuildTwoPair();


            // Act
            string winner = game.Play(left, right);

            // Assert
            Assert.That(winner, Is.EqualTo("left"));
        }

        [Test]
        public void StraightBeatsThreeOfAKind()
        {
            // Arrange
            // build first hand - high card, second hand - one pair
            Game game = new Game();

            var left = HandBuilder.BuildStraight();
            var right = HandBuilder.BuildThreeOfAKind();


            // Act
            string winner = game.Play(left, right);

            // Assert
            Assert.That(winner, Is.EqualTo("left"));
        }

        [Test]
        public void FlushBeatsStraight()
        {
            // Arrange
            // build first hand - high card, second hand - one pair
            Game game = new Game();

            var left = HandBuilder.BuildFlush();
            var right = HandBuilder.BuildStraight();


            // Act
            string winner = game.Play(left, right);

            // Assert
            Assert.That(winner, Is.EqualTo("left"));
        }

        [Test]
        public void StraightAceHighBeatsStraightAceLow()
        {
            // Arrange
            // build first hand - high card, second hand - one pair
            Game game = new Game();

            var left = HandBuilder.BuildStraightWithAceHigh();
            var right = HandBuilder.BuildStraightWithAceLow();


            // Act
            string winner = game.Play(left, right);

            // Assert
            Assert.That(winner, Is.EqualTo("left"));
        }

        [Test]
        public void FullHouseBeatsFlush()
        {
            // Arrange
            // build first hand - high card, second hand - one pair
            Game game = new Game();

            var left = HandBuilder.BuildFullHouse();
            var right = HandBuilder.BuildFlush();


            // Act
            string winner = game.Play(left, right);

            // Assert
            Assert.That(winner, Is.EqualTo("left"));
        }

        [Test]
        public void FourOfAKindBeatsFullHouse()
        {
            // Arrange
            // build first hand - high card, second hand - one pair
            Game game = new Game();

            var left = HandBuilder.BuildFourOfAKind();
            var right = HandBuilder.BuildFullHouse();


            // Act
            string winner = game.Play(left, right);

            // Assert
            Assert.That(winner, Is.EqualTo("left"));
        }

        [Test]
        public void StraightFlushBeatsFourOfAKind()
        {
            // Arrange
            // build first hand - high card, second hand - one pair
            Game game = new Game();

            var left = HandBuilder.BuildStraightFlush();
            var right = HandBuilder.BuildFourOfAKind();


            // Act
            string winner = game.Play(left, right);

            // Assert
            Assert.That(winner, Is.EqualTo("left"));
        }

        [Test]
        public void RoyalFlushBeatsStraightFlush()
        {
            // Arrange
            // build first hand - high card, second hand - one pair
            Game game = new Game();

            var left = HandBuilder.BuildRoyalFlush();
            var right = HandBuilder.BuildStraightFlush();


            // Act
            string winner = game.Play(left, right);

            // Assert
            Assert.That(winner, Is.EqualTo("left"));
        }
    }

}
