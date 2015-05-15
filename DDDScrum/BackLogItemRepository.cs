using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDScrum
{
    public class BackLogItemRepository : IRepository<BackLogItem>
    {
        private readonly List<BackLogItem> backLogItems = new List<BackLogItem>();

        public IEnumerable<BackLogItem> FindByProductId(Guid productId)
        {
            return backLogItems.Where(item => item.ProductId == productId).ToList();
        }

        public void Save(BackLogItem backLogItem)
        {
            backLogItems.Add(backLogItem);
        }
    }
}