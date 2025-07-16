using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfluencerManagerApp.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<IInfluencer> influencers;
        private readonly IRepository<ICampaign> campaigns;

        public ReportService(IRepository<IInfluencer> influencers, IRepository<ICampaign> campaigns) 
        {
            this.influencers = influencers;
            this.campaigns = campaigns;
        }
        public string ApplicationReport()
        {
            IEnumerable<IInfluencer> influencers = this.influencers
                .Models.OrderByDescending(i => i.Income)
                .ThenByDescending(i => i.Followers);

            StringBuilder sb = new StringBuilder();
            foreach (var influencer in influencers)
            {
                sb.AppendLine(influencer.ToString());
                int countParticipations = influencer.Participations.Count();
                if (countParticipations > 0)
                {
                    sb.AppendLine("Active Campaigns:");

                    List<ICampaign> campaigns = this.campaigns.Models
                    .Where(c => influencer.Participations.Contains(c.Brand))
                    .OrderBy(c => c.Brand).ToList();
                    foreach (var campaign in campaigns)
                    {
                        sb.AppendLine("--" + campaign.ToString());
                    }
                }
            }

            return sb.ToString();
        }
    }
}
