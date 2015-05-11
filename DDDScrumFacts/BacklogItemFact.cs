using System;
using DDDScrum;
using Xunit;

namespace DDDScrumFacts
{
    public class BacklogItemFact
    {
        [Fact]
        public void should_commit_a_product_back_log_item_to_a_sprint()
        {
            var product = new Product("ScrumDDD");
            var sprint = product.Schedule("Sprint1", new DateTime(2015, 1, 1), new DateTime(2015, 1, 15));

            var backLogItem = product.Plan("this is a story");

            backLogItem.CommitTo(sprint);
            Assert.Equal(backLogItem.Sprint.Id, sprint.Id);
        }

        [Fact]
        public void should_calc_back_log_item_priority()
        {
            var product = new Product("ScrumDDD");
            var backLogItem = product.Plan("this is a story");
            var businessPriority = new BusinessPriority(3, 2, 2);

            backLogItem.Assign(businessPriority);

            Assert.Equal(2.17, backLogItem.BusinessPriority.Priority);
        }
    }
}
