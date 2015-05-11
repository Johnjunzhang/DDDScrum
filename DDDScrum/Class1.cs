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

        public double Cacl(Guid productId)
        {
            var backLogItems = backLogItemRepository.FindByProductId(productId);
            return backLogItems.Sum(item => item.BusinessPriority.Priority);
        }
    }
}