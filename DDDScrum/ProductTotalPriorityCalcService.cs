using System;
using System.Linq;

namespace DDDScrum
{
    public class ProductTotalPriorityCalcService
    {
        private readonly IBackLogItemRepository backLogItemRepository;

        public ProductTotalPriorityCalcService(IBackLogItemRepository backLogItemRepository)
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