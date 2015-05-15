using System;
using System.Collections.Generic;

namespace DDDScrum
{
    public class Product : Entity, IAggregateRoot
    {
        private readonly List<BackLogItem> backLogItems = new List<BackLogItem>();
        private readonly List<Sprint> sprints = new List<Sprint>();
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
            backLogItems.Add(backLogItem);
            return backLogItem;
        }

        public Sprint Schedule(string sprintName, DateTime startTime, DateTime endTime)
        {
            var sprint = new Sprint(sprintName, startTime, endTime, this);
            sprints.Add(sprint);
            return sprint;
        }
    }
}