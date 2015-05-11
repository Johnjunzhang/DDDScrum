using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDScrum
{
    public class BackLogItemRepository : IBackLogItemRepository
    {
        private readonly List<BackLogItem> backLogItems = new List<BackLogItem>();

        public List<BackLogItem> FindByProductId(Guid productId)
        {
            return backLogItems.Where(item => item.ProductId == productId).ToList();
        }

        public void Save(BackLogItem backLogItem)
        {
            backLogItems.Add(backLogItem);
        }
    }
}