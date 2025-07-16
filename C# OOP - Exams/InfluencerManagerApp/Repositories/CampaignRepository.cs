using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository : IRepository<ICampaign>
    {
        private readonly List<ICampaign> campaigns;

        public CampaignRepository()
        {
            this.campaigns = new List<ICampaign>();
        }

        public ReadOnlyCollection<ICampaign> Models => this.campaigns.AsReadOnly();

        public void AddModel(ICampaign model)
        {
            if(model == null)
                return;
            this.campaigns.Add(model);
        }

        public bool Remove(ICampaign model)
        {
            return this.campaigns.Remove(model);
        }

        public ICampaign? FindByName(string brand)
        {
            return this.campaigns
                .FirstOrDefault(c => c.Brand == brand);
        }
    }
}
