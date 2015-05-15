using System;
using System.Collections.Generic;
using System.Linq;
using DDDCommon;

namespace DDDScrum
{
    public class BackLogItem : Entity, IAggregateRoot
    {
        private readonly List<Task> tasks = new List<Task>();
        public Guid ProductId { get; private set; }
        public Guid SprintId { get; private set; }
        public string Name { get; private set; }
        public BackLogItemStatus BackLogItemStatus { get; private set; }
        public BusinessPriority BusinessPriority { get; private set; }

        public List<Task> Tasks
        {
            get { return tasks; }
        }

        public BackLogItem(string name, Entity product)
        {
            ProductId = product.Id;
            Name = name;
            BackLogItemStatus = BackLogItemStatus.Planned;
        }

        public void CommitTo(Sprint sprint)
        {
            SprintId = sprint.Id;
            BackLogItemStatus = BackLogItemStatus.Commited;

            DomainEventPublisher.Instance.Publish(new BackLogCommitedEvent(Name, sprint.Name, DateTime.UtcNow));
        }

        public Task DefineTask(string taskName, int remainingHour)
        {
            var definedTask = new Task(taskName, remainingHour, Id);
            Tasks.Add(definedTask);
            return definedTask;
        }

        public void EstimateTaskHourRemaining(Guid taskId, int remainingHour)
        {
            var foundTask = tasks.First(task => task.Id == taskId);
            foundTask.EstimateHourRemaining(remainingHour);

            if (IsTasksAllDone())
                BackLogItemStatus = BackLogItemStatus.Done;
        }

        private bool IsTasksAllDone()
        {
            return tasks.All(task => task.RemainingHour == 0);
        }

        public void Assign(BusinessPriority businessPriority)
        {
            BusinessPriority = businessPriority;
        }
    }
}