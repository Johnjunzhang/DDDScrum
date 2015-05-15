using System.Linq;
using System.Runtime.InteropServices;

namespace DDDScrum
{
    public class ProductTotalPriorityCalcService
    {
        private readonly IRepository<BackLogItem> backLogItemRepository;

        public ProductTotalPriorityCalcService(IRepository<BackLogItem> backLogItemRepository)
        {
            this.backLogItemRepository = backLogItemRepository;
        }

        public double Calc(Product product)
        {
            var backLogItems = backLogItemRepository.FindByProductId(product.Id);
            var committedBackLogs = backLogItems.Where(IsCommited);
            return committedBackLogs.Sum(item => item.BusinessPriority.Priority);
        }

        private static bool IsCommited(BackLogItem item)
        {
            return item.BackLogItemStatus == BackLogItemStatus.Commited;
        }
    }
}