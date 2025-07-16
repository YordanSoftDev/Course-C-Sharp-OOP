using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Services.Contracts;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private readonly ICampaignService campaignService;
        private readonly IInfluencerService influencerService; 
        private readonly IReportService reportService;

        public Controller(ICampaignService campaignService, 
            IInfluencerService influencerService, 
            IReportService reportService)
        {
            this.campaignService = campaignService;
            this.influencerService = influencerService;
            this.reportService = reportService;
        }

        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            return this.influencerService.RegisterInfluencer(typeName, username, followers);
        }

        public string AttractInfluencer(string brand, string username)
        {
            return this.influencerService.AttractInfluencer(brand, username);
        }

        public string ConcludeAppContract(string username)
        {
            return this.influencerService.ConcludeAppContract(username);
        }

        public string FundCampaign(string brand, double amount)
        {
             return this.campaignService.FundCampaign(brand, amount);
        }

        public string CloseCampaign(string brand)
        {
             return this.campaignService.CloseCampaign(brand);
        }

        public string BeginCampaign(string typeName, string brand)
        {
             return this.campaignService.BeginCampaign(typeName, brand);
        }

        public string ApplicationReport()
        {
            return this.reportService.ApplicationReport();
        }
    }
}
