
using System.Collections.Generic;

namespace InfluencerManagerApp.Models.Contracts
{
    public interface ICampaign
    {
        public string Brand { get; }

        public double Budget { get; }

        public IReadOnlyCollection<string> Contributors { get; } 

        public void Gain(double amount);

        public void Engage(IInfluencer influencer);
    }
}
