namespace BorderControl
{
    public class Robot : IIdentifiable
    {
        public string Name { get; private set; }

        public string Id { get; private set; }

        public Robot(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}
