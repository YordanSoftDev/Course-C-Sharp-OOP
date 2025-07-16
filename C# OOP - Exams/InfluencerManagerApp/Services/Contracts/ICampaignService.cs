namespace InfluencerManagerApp.Services.Contracts
{
    public interface ICampaignService
    {
        public string BeginCampaign(string typeName, string brand);
        public string FundCampaign(string brand, double amount);
        public string CloseCampaign(string brand);
    }
}
