using System;

namespace DDDScrum
{
    public class Task : Entity, IAggregateRoot
    {
        public string TaskName { get; private set; }
        public int RemainingHour { get; private set; }
        public Guid BackLogItemId { get; private set; }

        public Task(string taskName, int remainingHour, Guid backLogItemId)
        {
            TaskName = taskName;
            RemainingHour = remainingHour;
            BackLogItemId = backLogItemId;
        }

        internal void EstimateHourRemaining(int remainingHour)
        {
            RemainingHour = remainingHour;
        }
    }
}