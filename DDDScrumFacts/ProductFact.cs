using DDDScrum;
using Xunit;

namespace DDDScrumFacts
{
    public class ProductFact
    {
        [Fact]
        public void should_plan_a_back_log_item_to_a_product()
        {
            var product = new Product("ScrumDDD");
            product.Rename("NewScrumDDD");

            Assert.Equal(product.Name, "NewScrumDDD");
        }
    }
}
