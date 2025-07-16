using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.IO;
using InfluencerManagerApp.IO.Contracts;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Services;
using InfluencerManagerApp.Services.Contracts;
using System;

namespace InfluencerManagerApp.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IController controller;

        public Engine()
        {
            IRepository<IInfluencer> influencerRepo = new InfluencerRepository();
            IRepository<ICampaign> campaignRepo = new CampaignRepository();

            ICampaignService campaignService = new CampaignService(influencerRepo, campaignRepo);
            IInfluencerService influencerService = new InfluencerService(influencerRepo, campaignRepo);
            IReportService reportService = new ReportService(influencerRepo, campaignRepo);
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller(campaignService,
            influencerService, reportService);
        }

        public void Run()
        {
            while (true)
            {
                string[] input = this.reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = string.Empty;

                    if (input[0] == "RegisterInfluencer")
                    {
                        string typeName = input[1];
                        string userName = input[2];
                        int followers = int.Parse(input[3]);

                        result = this.controller.RegisterInfluencer(typeName, userName, followers);
                    }
                    else if (input[0] == "BeginCampaign")
                    {
                        string typeName = input[1];
                        string brand = input[2];

                        result = this.controller.BeginCampaign(typeName, brand);
                    }
                    else if (input[0] == "AttractInfluencer")
                    {
                        string brand = input[1];
                        string userName = input[2];

                        result = this.controller.AttractInfluencer(brand, userName);
                    }
                    else if (input[0] == "FundCampaign")
                    {
                        string brand = input[1];
                        double amount = double.Parse(input[2]);

                        result = this.controller.FundCampaign(brand, amount);
                    }
                    else if (input[0] == "CloseCampaign")
                    {
                        string brand = input[1];

                        result = this.controller.CloseCampaign(brand);
                    }
                    else if (input[0] == "ConcludeAppContract")
                    {
                        string userName = input[1];

                        result = this.controller.ConcludeAppContract(userName);
                    }
                    else if (input[0] == "ApplicationReport")
                    {
                        result = this.controller.ApplicationReport();
                    }
                    this.writer.WriteLine(result);
                    this.writer.WriteText(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                    this.writer.WriteText(ex.Message);
                }
            }

        }
    }
}
