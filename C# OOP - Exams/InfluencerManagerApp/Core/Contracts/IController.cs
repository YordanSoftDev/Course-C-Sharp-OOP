
namespace InfluencerManagerApp.Core.Contracts
{
    public interface IController
    {
        public string RegisterInfluencer(string typeName, string username, int followers);

        public string AttractInfluencer(string brand, string username);

        public string ConcludeAppContract(string username);

        public string BeginCampaign(string typeName, string brand);

        public string FundCampaign(string brand, double amount);

        public string CloseCampaign(string brand);

        public string ApplicationReport();
    }
}
