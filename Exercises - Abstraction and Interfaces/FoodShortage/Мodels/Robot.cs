namespace FoodShortage.Мodels.Interfaces
{
    public class Robot : IIdentifiable
    {
        private string resident;
        private string model;

        public double id;

        private List<double> fakeIdentities;

        public Robot(string resident, string model, double id)
        {
            this.Resident = resident;
            this.Id = id;
            this.Model = model;
            this.fakeIdentities = new();
        }
        public string Model
        {
            get => this.model;
            private set => this.model = value;
        }

        public double Id
        {
            get => this.id;
            private set => this.id = value;
        }

        public string Resident
        {
            get => resident;
            private set
            {
                if (value != "Robot")
                    throw new ArgumentException("Wrong type of resident.");

                resident = value;
            }
        }
        public IReadOnlyCollection<double> FakeIdentities => fakeIdentities.AsReadOnly();

        public List<double> ValidateId(List<IIdentifiable> ids, string fakeId)
        {
            foreach (IIdentifiable robot in ids)
            {
                string idToString = robot.Id.ToString();

                if (idToString.EndsWith(fakeId))
                    fakeIdentities.Add(robot.Id);
            }

            return fakeIdentities;
        }
    }
}
