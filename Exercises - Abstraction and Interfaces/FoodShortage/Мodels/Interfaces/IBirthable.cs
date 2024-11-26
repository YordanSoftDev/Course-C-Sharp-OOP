namespace FoodShortage.Мodels.Interfaces
{
    public interface IBirthable
    {
        public string Name { get; }
        public DateTime Birthdate { get; }

        public List<DateTime> FindBirthdatesByYears(List<IBirthable> citizens, int yearOfBirth);
    }
}
