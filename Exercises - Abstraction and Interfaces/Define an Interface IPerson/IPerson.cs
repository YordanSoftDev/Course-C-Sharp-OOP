



namespace Define_an_Interface_IPerson
{
    public interface IPerson : IIdentifiable, IBirthable
    {
        public string Name { get; }
        public int Age { get;}
    }
}
