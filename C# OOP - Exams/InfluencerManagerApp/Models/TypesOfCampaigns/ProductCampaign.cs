namespace InfluencerManagerApp.Models.TypesOfCampaigns
{
    public class ProductCampaign : Campaign
    {
        private const double fixedBudget = 60000;
        public ProductCampaign(string brand) : base(brand, fixedBudget)
        {
        }             
    }
}
