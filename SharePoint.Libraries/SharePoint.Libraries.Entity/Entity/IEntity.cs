using Microsoft.SharePoint;
using System;
using System.Collections.Generic;

namespace SharePoint.Libraries.Entity
{
    public interface IEntity
    {
        int Id { get; set; }
        string Title { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
        SPFieldUserValue ModifiedBy { get; set; }
        SPFieldUserValue CreatedBy { get; set; }
        List<IAttachmentEntity> Attachments { get; set; }
    }
}