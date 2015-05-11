using System;
using DDDCommon;

namespace DDDScrum
{
    public class BackLogCommitedEvent : IDomainEvent
    {
        private readonly string backLogItemName;
        private readonly string sprintName;

        public BackLogCommitedEvent(string backLogItemName, string sprintName, DateTime createdTime)
        {
            this.backLogItemName = backLogItemName;
            this.sprintName = sprintName;
            CreatedTime = createdTime;
        }

        public DateTime CreatedTime { get; set; }

        public string BackLogItemName
        {
            get { return backLogItemName; }
        }

        public string SprintName
        {
            get { return sprintName; }
        }
    }
}