using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Models.TypesOfCampaigns;
using InfluencerManagerApp.Models.TypesOfInfluencers;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Services.Contracts;
using System;
using System.Linq;

namespace InfluencerManagerApp.Services
{
    public class InfluencerService : IInfluencerService
    {
        private readonly IRepository<IInfluencer> influencers;
        private readonly IRepository<ICampaign> campaigns;

        public InfluencerService(IRepository<IInfluencer> influencers, IRepository<ICampaign> campaigns) 
        {
            this.influencers = influencers;
            this.campaigns = campaigns;
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (this.influencers.FindByName(username) != null)
            {
                throw new ArgumentException($"{username} is already registered in " +
                    $"{this.influencers.GetType().Name}.");
            }

            IInfluencer influencer = typeName switch
            {
                nameof(BloggerInfluencer) => new BloggerInfluencer(username, followers),
                nameof(BusinessInfluencer) => new BusinessInfluencer(username, followers),
                nameof(FashionInfluencer) => new FashionInfluencer(username, followers),
                _ => throw new ArgumentException($"{typeName} has not passed " +
                    $"validation.")
            };

            this.influencers.AddModel(influencer);

            return $"{username} registered successfully to the application.";
        }
        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer? influencer = this.influencers.FindByName(username);
            if (influencer == null)
            {
                this.campaigns.Models.Count();
                return $"{nameof(this.influencers)} " +
                    $"has no {username} registered in the application.";
            }

            ICampaign? campaign = this.campaigns.FindByName(brand);

            if (campaign == null)
            {
                return $"There is no campaign from " +
                    $"{brand} in the application.";
            }

            bool isInfluencerEngaged = campaign.Contributors.Contains(username);
            if (isInfluencerEngaged)
            {
                return $"{username} is already engaged " +
                    $"for the {brand} campaign.";
            }

            if ((campaign is ProductCampaign &&
                influencer is not (BusinessInfluencer or
                FashionInfluencer)) || campaign is ServiceCampaign &&
                    influencer is not (BusinessInfluencer or
                    BloggerInfluencer))
            {
                return $"{username} " +
                    $"is not eligible for the {brand} campaign.";
            }

            double campaignBudget = campaign.Budget;
            int influencerPayment = influencer.CalculateCampaignPrice();

            if (campaignBudget < influencerPayment)
                return $"The budget for " +
                    $"{brand} is insufficient to engage {username}.";

            campaign.Engage(influencer);
            influencer.EarnFee(influencerPayment);
            influencer.EnrollCampaign(brand);

            return $"{username} has been successfully attracted to the " +
                $"{brand} campaign.";
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer? influencer = this.influencers.FindByName(username);
            if (influencer == null)
            {
                return $"{nameof(this.influencers)} " +
                    $"{username} has still not signed a contract.";
            }

            bool isInfluencerHired = influencer.Participations.Any();

            if (isInfluencerHired)
                return $"{username} cannot " +
                     "conclude the contract while enrolled in active campaigns.";

            this.influencers.Remove(influencer);

            return $"{username} concluded their contract.";
        }
    }
}
