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
    }
}
