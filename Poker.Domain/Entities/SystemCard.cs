using Poker.Domain.Enums;

namespace Poker.Domain.Entities
{
    public abstract class SystemCard
    {
        public abstract Rank Rank { get; }
    }
}
