using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.IO;

namespace SharePoint.Libraries.Entity
{
    public abstract class RepositoryBase<T> : IRepository<IEntity>, IDisposable where T : IEntity
    {
        protected abstract String ListUrl { get; }

        private IViewFieldsBuilder fieldsBuilder;
        private EntityConverter<T> entityConverter;
        private SPList _list;
        SPListItemCollectionPosition itemPosition;
        public SPList List
        {
            get
            {
                if (_list == null)
                {
                    _list = Web.GetList(String.Format("{0}/{1}", Web.Url.TrimEnd("/".ToCharArray()), this.ListUrl.TrimStart("/".ToCharArray())));
                }
                return _list;
            }
        }
        private SPWeb Web { get; set; }

        public RepositoryBase(SPWeb web)
        {
            Web = web;
            entityConverter = new EntityConverter<T>(Web);
            fieldsBuilder = ViewFieldsFactory.GetBuilder(typeof(T));
        }

        public T GetItemById(int id)
        {
            SPListItem item = List.GetItemById(id);
            return entityConverter.ConvertToEntity(item);
        }
        public IList<T> GetItems()
        {
            return GetItems(null);
        }
        public IList<T> GetItems(SPQuery query)
        {
            if (query == null)
            {
                query = new SPQuery();
            }

            if (string.IsNullOrEmpty(query.ViewFields))
            {
                query.ViewFields = fieldsBuilder.GetViewFields();
                entityConverter.ViewFields = fieldsBuilder.Fields;
            }
            else
            {
                entityConverter.ViewFields = fieldsBuilder.GetFields(query.ViewXml);
            }

            entityConverter.UseViewFields = query.ViewFieldsOnly = true;

            SPListItemCollection items = List.GetItems(query);
            itemPosition = items.ListItemCollectionPosition;

            List<T> retVal = new List<T>();

            if (items != null)
            {
                foreach (SPListItem item in items)
                {
                    retVal.Add(entityConverter.ConvertToEntity(item));
                }
            }
            return retVal;
        }
        protected IList<T> GetItemsByPermission(SPQuery query, SPUser user, SPBasePermissions permissionMask)
        {
            if (query == null)
            {
                query = new SPQuery();
            }

            SetViewFields(query);

            SPListItemCollection items = List.GetItems(query);

            List<T> retVal = new List<T>();

            if (items != null)
            {
                foreach (SPListItem item in items)
                {
                    if (item.DoesUserHavePermissions(user, permissionMask))
                        retVal.Add(entityConverter.ConvertToEntity(item));
                }
            }
            return retVal;
        }
        public IList<IEntity> GetAllItems()
        {
            return ConvertToIEntity(this.GetItems());
        }
        public IList<IEntity> GetItemsByQuery(SPQuery spQuery)
        {
            return ConvertToIEntity(this.GetItems(spQuery));
        }
        public IList<IEntity> GetItemsAndPosition(SPQuery spQuery, out SPListItemCollectionPosition position)
        {
            List<IEntity> result = ConvertToIEntity(this.GetItems(spQuery));
            position = this.itemPosition;
            return result;
        }
        public T ConvertToEntity(SPListItem item)
        {
            return entityConverter.ConvertToEntity(item);
        }
        private void SetViewFields(SPQuery query)
        {
            if (string.IsNullOrEmpty(query.ViewFields))
            {
                query.ViewFields = fieldsBuilder.GetViewFields();
                entityConverter.ViewFields = fieldsBuilder.Fields;
            }
            else
            {
                entityConverter.ViewFields = fieldsBuilder.GetFields(query.ViewXml);
            }

            entityConverter.UseViewFields = query.ViewFieldsOnly = true;
        }
        public int AddUpdateItem(T entity)
        {
            Web.AllowUnsafeUpdates = true;

            SPListItem item = null;

            if (entity.Id > 0) { item = List.GetItemById(entity.Id); }
            else { item = List.AddItem(); }

            entityConverter.ConvertToListItem(item, entity);

            item.Update();

            Web.AllowUnsafeUpdates = false;

            return item.ID;
        }
        public int SystemUpdateItem(T entity, bool incrementListItemVersion)
        {
            Web.AllowUnsafeUpdates = true;
            if (entity.Id.Equals(0)) { throw new InvalidDataException("Entity id could not be Zero when doing System Update"); }

            SPListItem item = List.GetItemById(entity.Id);
            entityConverter.ConvertToListItem(item, entity);
            item.SystemUpdate(incrementListItemVersion);
            Web.AllowUnsafeUpdates = false;

            return item.ID;
        }
        /// <param name="folderUrl">Empty or null for root folder!</param>
        /// <returns>Added list item</returns>
        public SPListItem AddDocument(string folderUrl, string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);


            if (fileInfo.Exists)
            {
                SPFolder folder = null;

                if (string.IsNullOrEmpty(folderUrl))
                {
                    folder = List.RootFolder;
                }
                else
                {
                    folder = GetFolder(folderUrl);
                }

                SPFile uploadedFile = null;
                using (FileStream stream = File.OpenRead(filePath))
                {
                    byte[] content = new byte[stream.Length];
                    stream.Read(content, 0, (int)stream.Length);

                    uploadedFile = folder.Files.Add(string.Format("{0}/{1}", folder.Url, fileInfo.Name), content);

                    if (uploadedFile == null)
                    {
                        throw new ArgumentNullException("Upload error file is null");
                    }
                    else
                    {
                        return uploadedFile.Item;
                    }
                }
            }
            else
            {
                throw new FileNotFoundException(filePath);
            }
        }
        public SPFolder GetFolder(string folderUrl)
        {
            folderUrl = folderUrl.TrimStart('/');

            string[] folderPaths = folderUrl.Split('/');

            SPFolder rootFolder = List.RootFolder;

            foreach (string partitialUrl in folderPaths)
            {
                try
                {
                    rootFolder = rootFolder.SubFolders[partitialUrl];

                    if (rootFolder == null)
                    {
                        throw new ArgumentNullException(partitialUrl);
                    }
                }
                catch
                {
                    rootFolder.SubFolders.Add(partitialUrl);
                    rootFolder = rootFolder.SubFolders[partitialUrl];
                }
            }
            return rootFolder;
        }
        public void DeleteItem(int Id)
        {
            Web.AllowUnsafeUpdates = true;
            SPListItem item = List.GetItemById(Id);
            item.Delete();
            Web.AllowUnsafeUpdates = false;
        }
        public void Dispose()
        {
            if (Web != null)
            {
                Web.Dispose();
                Web = null;
            }
        }
        private List<IEntity> ConvertToIEntity(IList<T> result)
        {
            var enuma = result.GetEnumerator();

            List<IEntity> entities = new List<IEntity>();

            while (enuma.MoveNext())
            {
                entities.Add(enuma.Current);
            }

            return entities;
        }
    }
}