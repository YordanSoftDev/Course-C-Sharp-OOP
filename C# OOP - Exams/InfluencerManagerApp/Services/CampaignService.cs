using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Models.TypesOfCampaigns;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfluencerManagerApp.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly IRepository<IInfluencer> influencers;
        private readonly IRepository<ICampaign> campaigns;

        public CampaignService(IRepository<IInfluencer> influencers, IRepository<ICampaign> campaigns) 
        {
            this.influencers = influencers;
            this.campaigns = campaigns;
        }
        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName is not ("ProductCampaign" or "ServiceCampaign"))
            {
                return $"{typeName} is not a valid campaign " +
                "in the application.";
            }

            ICampaign? campaign = this.campaigns.FindByName(brand);

            if (campaign != null)
            {
                return $"{brand} campaign cannot be duplicated.";
            }

            campaign = typeName switch
            {
                "ProductCampaign" => new ProductCampaign(brand),
                "ServiceCampaign" => new ServiceCampaign(brand),
            };

            this.campaigns.AddModel(campaign);
            Console.WriteLine(this.campaigns.Models.Count);
            return $"{brand} started a {typeName}.";
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign? campaign = this.campaigns.FindByName(brand);

            if (campaign == null)
            {
                return $"Trying to fund an invalid campaign.";
            }

            if (amount <= 0)
            {
                return $"Funding amount must " +
                    $"be greater than zero.";
            }

            campaign.Gain(amount);
            return $"{brand} campaign has been successfully " +
                $"funded with {amount} $";
        }

        public string CloseCampaign(string brand)
        {
            ICampaign? campaign = this.campaigns.FindByName(brand);

            if (campaign == null)
            {
                return $"Trying to close an invalid campaign.";
            }

            double campaignBudget = campaign.Budget;

            if (campaignBudget <= 10000)
            {
                return $"{brand} campaign cannot be " +
                    $"closed as it has not met its financial targets.";
            }

            IEnumerable<IInfluencer> influencersInTheCampaign = this.influencers.Models
                .Where(i => i.Participations.Contains(brand));

            foreach (IInfluencer influencer in influencersInTheCampaign)
            {
                influencer.EarnFee(2000);
                influencer.EndParticipation(brand);
            }

            this.campaigns.Remove(campaign);
            return $"{brand} campaign has reached its target.";
        }
    }
}
