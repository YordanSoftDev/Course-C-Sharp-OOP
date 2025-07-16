using InfluencerManagerApp.Models.Contracts;
using System;
using System.Collections.Generic;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign :ICampaign
    {
        private string brand;
        private double budget;
        private readonly List<string> contributors; 

        protected Campaign(string brand, double budget)
        {
            this.Brand = brand;
            this.Budget = budget;
            this.contributors = new List<string>();
        }
        public string Brand
        {
            get => this.brand;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Brand is required.");

                this.brand = value;
            }
        }
        public double Budget
        {
            get => this.budget;
            private set
            {
                this.budget = value;
            }
        }
        public IReadOnlyCollection<string> Contributors { get => this.contributors.AsReadOnly(); }

        public void Gain(double amount)
        {
            this.Budget += amount;
        }

        public void Engage(IInfluencer influencer)
        {
            int influencerFee = influencer.CalculateCampaignPrice();
            this.Budget -= influencerFee;
            this.contributors.Add(influencer.Username);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Brand: {this.Brand}, Budget: {this.Budget}, Contributors: {this.Contributors.Count}";
        }
    }
}
