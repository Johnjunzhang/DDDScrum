using System;

namespace DDDScrum
{
    public class BusinessPriority
    {
        private readonly double value;
        private readonly double risk;
        private readonly double cost;

        public BusinessPriority(double value, double risk, double cost)
        {
            this.value = value;
            this.risk = risk;
            this.cost = cost;
        }

        public double Priority
        {
            get { return Math.Round((value * 3 + risk * 2) / (cost * 3), 2); }
        }
    }
}