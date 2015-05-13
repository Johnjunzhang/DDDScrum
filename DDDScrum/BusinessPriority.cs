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

        protected bool Equals(BusinessPriority other)
        {
            return value.Equals(other.value) && risk.Equals(other.risk) && cost.Equals(other.cost);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BusinessPriority) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = value.GetHashCode();
                hashCode = (hashCode*397) ^ risk.GetHashCode();
                hashCode = (hashCode*397) ^ cost.GetHashCode();
                return hashCode;
            }
        }
    }
}