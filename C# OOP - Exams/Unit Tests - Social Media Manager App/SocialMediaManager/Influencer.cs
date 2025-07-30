namespace SocialMediaManager
{
    public class Influencer
    {
        public Influencer(string username, int followers)
        {
            this.Username = username;
            this.Followers = followers;
        }

        public string Username{ get; }

        public int Followers { get; }
    }
}
