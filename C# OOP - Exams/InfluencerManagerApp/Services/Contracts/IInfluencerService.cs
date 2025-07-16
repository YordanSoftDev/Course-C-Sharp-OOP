
namespace InfluencerManagerApp.Services.Contracts
{
    public interface IInfluencerService
    {
        public string RegisterInfluencer(string typeName,
            string username, int followers);

        public string AttractInfluencer(string brand, string username); 

        public string ConcludeAppContract(string username);
    }
}
