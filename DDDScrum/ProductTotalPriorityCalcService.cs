using System.Linq;

namespace DDDScrum
{
    public class ProductTotalPriorityCalcService
    {
        private readonly IRepository<BackLogItem> backLogItemRepository;

        public ProductTotalPriorityCalcService(IRepository<BackLogItem> backLogItemRepository)
        {
            this.backLogItemRepository = backLogItemRepository;
        }

        public double Cacl(Product product)
        {
            var backLogItems = backLogItemRepository.FindByProductId(product.Id);
            return backLogItems.Sum(item => item.BusinessPriority.Priority);
        }
    }
}