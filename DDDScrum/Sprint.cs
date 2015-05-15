using System;
using System.Collections.Generic;

namespace DDDScrum
{
    public class Sprint : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }

        public Guid ProductId { get; private set; }

        public Sprint(string name, DateTime startTime, DateTime endTime, Product product)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            ProductId = product.Id;
        }
    }
}