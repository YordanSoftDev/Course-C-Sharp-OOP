
using InfluencerManagerApp.Models.Contracts;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace InfluencerManagerApp.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        public ReadOnlyCollection<T> Models { get; } 

        public void AddModel(T model);

        public bool Remove(T model);

        public T? FindByName(string name);
    }
}
