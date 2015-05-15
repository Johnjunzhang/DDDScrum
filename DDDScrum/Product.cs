using System;

namespace DDDScrum
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public Product(string name)
        {
            Name = name;
        }

        public void Rename(String newName)
        {
            Name = newName;
        }

        public BackLogItem Plan(string storyName)
        {
            var backLogItem = new BackLogItem(storyName, this);
            return backLogItem;
        }

        public Sprint Schedule(string sprintName, DateTime startTime, DateTime endTime)
        {
            var sprint = new Sprint(sprintName, startTime, endTime, this);
            return sprint;
        }
    }
}