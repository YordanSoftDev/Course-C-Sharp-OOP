
namespace InfluencerManagerApp.Models.TypesOfCampaigns
{
    public class ServiceCampaign : Campaign
    {
        private const double fixedBudget = 30000;
        public ServiceCampaign(string brand) : base(brand, fixedBudget) 
        {
        }
    }
}
