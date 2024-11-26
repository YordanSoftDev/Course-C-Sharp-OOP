namespace BirthdayCelebrations.Мodels.Interfaces
{
    public interface IIdentifiable
    {
        public double Id { get; }
        public IReadOnlyCollection<double> FakeIdentities { get; }
        public List<double> ValidateId(List<IIdentifiable> ids, string fakeId);
    }
}
