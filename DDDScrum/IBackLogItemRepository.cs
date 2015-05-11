using System;
using System.Collections.Generic;

namespace DDDScrum
{
    public interface IBackLogItemRepository
    {
        List<BackLogItem> FindByProductId(Guid productId);
        void Save(BackLogItem backLogItem);
    }
}