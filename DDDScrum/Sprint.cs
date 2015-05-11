using System;
using System.Collections.Generic;

namespace DDDScrum
{
    public class Sprint : Entity
    {
        private readonly List<BackLogItem> backLogItems = new List<BackLogItem>();

        public string Name { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public List<BackLogItem> BackLogItems
        {
            get { return backLogItems; }
        }

        public Sprint(string name, DateTime startTime, DateTime endTime)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
        }

        public void Commit(BackLogItem backLogItem)
        {
            BackLogItems.Add(backLogItem);
        }
    }
}