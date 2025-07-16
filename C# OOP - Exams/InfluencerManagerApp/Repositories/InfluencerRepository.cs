using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository : IRepository<IInfluencer>
    {
        private readonly List<IInfluencer> influencers; 
        public InfluencerRepository()
        {
            this.influencers = new();
        }

        public ReadOnlyCollection<IInfluencer> Models => this.influencers.AsReadOnly();

        public void AddModel(IInfluencer model)
        {
            if (model == null)
            {
                return;
            }
            this.influencers.Add(model);
        }

        public bool Remove(IInfluencer model)
        {
            return this.influencers.Remove(model);
        }

        public IInfluencer? FindByName(string username)
        {
            return this.influencers
                .FirstOrDefault(i => i.Username == username);
        }
    }
}
