namespace DDDScrum
{
    public class BackLogItem : Entity
    {
        public string Name { get; private set; }

        public BackLogItem(string name)
        {
            Name = name;
        }
    }
}