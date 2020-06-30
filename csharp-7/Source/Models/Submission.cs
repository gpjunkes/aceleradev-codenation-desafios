using System;

namespace Codenation.Challenge.Models
{
    public class Submission
    {
        public int UserId { get; set; }
        public int ChallengeId { get; set; }
        public decimal Score { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual Challenge Challenge { get; set; }
    }
}
