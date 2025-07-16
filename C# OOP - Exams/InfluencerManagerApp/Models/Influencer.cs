
using InfluencerManagerApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string username;
        protected int followers;
        private double income;
        private double engagementRate;
        private readonly List<string> participations;

        protected Influencer(string username, int followers,
            double engagementRate)
        {
            this.Username = username;
            this.Followers = followers;
            this.EngagementRate = engagementRate;
            this.participations = new();
        }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username is required.");

                this.username = value;
            }
        }

        public int Followers
        {
            get => this.followers;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Followers count cannot " +
                        "be a negative number.");

                this.followers = value;
            }
        }

        public double EngagementRate
        {
            get => this.engagementRate;
            private set
            {
                this.engagementRate = value;
            }
        }

        public double Income
        {
            get => this.income;
            private set
            {
                this.income = value;
            }
        }
        public IReadOnlyCollection<string> Participations { get => this.participations.AsReadOnly(); }

        public void EarnFee(double amount)
        {
            this.Income += amount;
        }

        public void EnrollCampaign(string brand)
        {
            this.participations.Add(brand);
        }

        public void EndParticipation(string brand)
        {
            this.participations.Remove(brand);
        }

        public abstract int CalculateCampaignPrice();

        public override string ToString()
        {
            return $"{this.Username} - Followers: {this.Followers}, Total Income: {this.Income}";
        }
    }
}
