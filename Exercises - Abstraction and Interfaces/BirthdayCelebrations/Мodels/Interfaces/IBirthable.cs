namespace BirthdayCelebrations.Мodels.Interfaces
{
    public interface IBirthable
    {
        public DateTime Birthdate { get; }

        public List<DateTime> FindBirthdatesByYears(List<IBirthable> citizens, int yearOfBirth);

    }
}
