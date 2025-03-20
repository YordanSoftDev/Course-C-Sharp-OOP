using System.Collections.Generic;

namespace RepositoryPattern
{
    public interface IRepository<T> where T : class
    {
        IReadOnlyCollection<T> Models { get; }
        void AddNew(T model);
        T GetByName(string name);
        bool Exists(string name);
        void Update(T model);
        void Remove(string name);
    }
}
