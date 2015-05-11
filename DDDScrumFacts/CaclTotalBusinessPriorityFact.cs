using System;
using DDDScrum;
using Xunit;

namespace DDDScrumFacts
{
    public class CaclTotalBusinessPriorityFact
    {
        [Fact]
        public void should_calc_total_priority_for_all_back_log_item_in_product()
        {
            var product = new Product("ScrumDDD");
            var sprint = product.Schedule("Sprint1", new DateTime(2015, 1, 1), new DateTime(2015, 1, 15));

            var backLogItem = product.Plan("this is a story");
            var businessPriority = new BusinessPriority(3, 2, 4);
            backLogItem.Assign(businessPriority);

            var backLogItem2 = product.Plan("this is another story");
            var businessPriority2 = new BusinessPriority(3, 4, 4);
            backLogItem2.Assign(businessPriority2);

            backLogItem2.CommitTo(sprint);
            var backLogItemRepository = new BackLogItemRepository();
            backLogItemRepository.Save(backLogItem);
            backLogItemRepository.Save(backLogItem2);

            var productTotalPriorityCalcService = new ProductTotalPriorityCalcService(backLogItemRepository);
            Assert.Equal(2.5, productTotalPriorityCalcService.Cacl(product.Id));
        } 
    }
}