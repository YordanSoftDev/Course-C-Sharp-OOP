namespace BorderControl.Мodels.Interfaces
{
    public class Robot : IIdentifiable
    {
        private string model;

        public double id;

        private List<double> fakeIdentities;

        public Robot(string model, double id)
        {
            this.Id = id;
            this.Model = model;
            this.fakeIdentities = new();
        }
        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public double Id
        {
            get => this.id;
            set => this.id = value;
        }
        public IReadOnlyCollection<double> FakeIdentities => fakeIdentities.AsReadOnly();

        public List<double> ValidateId(List<IIdentifiable> ids, string fakeId)
        {
            foreach (Robot robot in ids)
            {
                string idToString = robot.Id.ToString();

                if (idToString.EndsWith(fakeId))
                    fakeIdentities.Add(robot.Id);
            }

            return fakeIdentities;
        }
    }
}
