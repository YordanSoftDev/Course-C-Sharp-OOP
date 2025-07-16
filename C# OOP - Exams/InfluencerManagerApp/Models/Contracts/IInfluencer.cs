using System.Collections.Generic;

namespace InfluencerManagerApp.Models.Contracts
{
    public interface IInfluencer
    {
    
        public string Username { get; }

        public int Followers { get; }

        public double EngagementRate { get; }

        public double Income { get; }

        public IReadOnlyCollection<string> Participations { get; }

        public void EarnFee(double amount);

        public void EnrollCampaign(string brand);

        public void EndParticipation(string brand);

        public int CalculateCampaignPrice();
    }
}
