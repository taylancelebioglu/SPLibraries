using Microsoft.SharePoint;
using System.Collections.Generic;

namespace SharePoint.Libraries.Entity
{
    public interface IRepository<T> where T : IEntity
    {
        IList<T> GetAllItems();
        IList<T> GetItemsByQuery(SPQuery spQuery);
        IList<T> GetItemsAndPosition(SPQuery spQuery, out SPListItemCollectionPosition position);
    }
}
