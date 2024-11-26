namespace BorderControl.Мodels.Interfaces
{
    public interface IIdentifiable
    {
        double Id { get; set; }
        public IReadOnlyCollection<double> FakeIdentities { get; }
        public List<double> ValidateId(List<IIdentifiable> ids, string fakeId);
    }
}
