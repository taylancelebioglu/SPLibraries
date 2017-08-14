using Microsoft.SharePoint;
using System;
using System.Collections.Generic;

namespace SharePoint.Libraries.Entity
{
    public class EntityBase : IEntity
    {
        public EntityBase()
        {
            Attachments = new List<IAttachmentEntity>();
        }

        [SPFieldFlag(Name = Constants.FieldNames.General.ID, RestrictUpdate = true)]
        public int Id { get; set; }
        [SPFieldFlag(Name = Constants.FieldNames.General.TITLE)]
        public String Title { get; set; }
        [SPFieldFlag]
        public DateTime Created { get; set; }
        [SPFieldFlag]
        public DateTime Modified { get; set; }
        [SPFieldFlag(Name = Constants.FieldNames.General.MODIFIEDBY)]
        public SPFieldUserValue ModifiedBy { get; set; }
        [SPFieldFlag(Name = Constants.FieldNames.General.CREATEDBY)]
        public SPFieldUserValue CreatedBy { get; set; }
        [SPFieldFlag]
        public List<IAttachmentEntity> Attachments { get; set; }
    }
}