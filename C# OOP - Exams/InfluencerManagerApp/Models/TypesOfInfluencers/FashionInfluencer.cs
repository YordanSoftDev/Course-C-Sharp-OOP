using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models.TypesOfInfluencers
{
    public class FashionInfluencer : Influencer
    {
        private const double fixedEngagementRate = 4.0;
        private const double factor = 0.1;
        public FashionInfluencer(string username, int followers) : base(username,
            followers, fixedEngagementRate)
        {

        }
        public override int CalculateCampaignPrice()
        {
            double price = this.Followers * this.EngagementRate * factor;
            return (int)Math.Floor(price);
        }
    }
}
