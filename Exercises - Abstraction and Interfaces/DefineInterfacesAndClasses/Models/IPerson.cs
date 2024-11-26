using DefineInterfacesAndClasses.Models.Interfaces;

namespace DefineInterfacesAndClasses.Models
{
    public interface IPerson : IIdentifiable, IBirthable
    {
        public string Name { get; }
        public int Age { get; }
    }
}
