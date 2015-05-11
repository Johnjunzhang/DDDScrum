namespace DDDScrum
{
    public class BackLogItem : Entity
    {
        public Product Product { get; private set; }
        public Sprint Sprint { get; private set; }
        public string Name { get; private set; }
        public BusinessPriority BusinessPriority { get; private set; }

        public BackLogItem(string name, Product product)
        {
            Product = product;
            Name = name;
        }

        public void CommitTo(Sprint sprint)
        {
            Sprint = sprint;
        }

        public void Assign(BusinessPriority businessPriority)
        {
            BusinessPriority = businessPriority;
        }
    }
}