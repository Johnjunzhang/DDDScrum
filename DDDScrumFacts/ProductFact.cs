using System;
using DDDScrum;
using Xunit;

namespace DDDScrumFacts
{
    public class ProductFact
    {
        [Fact]
        public void should_rename_a_product()
        {
            var product = new Product("ScrumDDD");
            product.Rename("NewScrumDDD");

            Assert.Equal(product.Name, "NewScrumDDD");
        }

        [Fact]
        public void should_plan_a_back_log_item_to_a_product()
        {
            var product = new Product("ScrumDDD");
            var backLogItem = product.Plan("this is a story");

            Assert.Equal(backLogItem.Name, "this is a story");
        }

        [Fact]
        public void should_schedule_a_sprint_to_a_product()
        {
            var product = new Product("ScrumDDD");
            var sprint = product.Schedule("Sprint1", new DateTime(2015, 1, 1), new DateTime(2015, 1, 15));

            Assert.Equal("Sprint1", sprint.Name);
            Assert.Equal(new DateTime(2015, 1, 1), sprint.StartTime);
            Assert.Equal(new DateTime(2015, 1, 15), sprint.EndTime);
        }
    }
}
