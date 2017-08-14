using System;
using System.IO;
using Microsoft.SharePoint;

namespace SharePoint.Libraries.Entity
{
    public abstract class SPRepositoryBase
    {
        protected abstract String ListUrl { get; }
        private Object folderLock = new Object();

        private SPList _list;
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

        public SPRepositoryBase(SPWeb web)
        {
            this.Web = web;
        }

        public SPListItem GetItemById(int id)
        {
            return List.GetItemById(id);
        }

        public SPListItemCollection GetItems(SPQuery query)
        {
            return List.GetItems(query);
        }

        public SPListItem AddDocument(string folderUrl, string filePath, string fileName)
        {
            return AddDocument(folderUrl, filePath, fileName, false);
        }

        /// <param name="folderUrl">Empty or null for root folder!</param>
        /// <returns>Added list item</returns>
        public SPListItem AddDocument(string folderUrl, string filePath, string fileName, bool overwrite)
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

                    if (string.IsNullOrEmpty(fileName))
                    {
                        fileName = fileInfo.Name;
                    }

                    string fileNameOnly = Path.GetFileNameWithoutExtension(fileName).Replace('~', '-');
                    string importFileName = string.Format("{0}{1}", fileNameOnly, fileInfo.Extension);

                    uploadedFile = folder.Files.Add(string.Format("{0}/{1}", folder.Url, importFileName), content, overwrite);

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

        public SPListItem AddDocument(Stream sourceStream, string fileName, SPFolder targetFolder)
        {
            SPFile uploadedFile = null;
            using (sourceStream)
            {
                byte[] content = new byte[sourceStream.Length];
                sourceStream.Read(content, 0, (int)sourceStream.Length);

                string importFileName = fileName.Replace('~', '-');
                uploadedFile = targetFolder.Files.Add(string.Format("{0}/{1}", targetFolder.Url, importFileName), content, true);

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

        public SPListItem AddItem(string title)
        {
            SPListItem newItem = List.AddItem();
            newItem[Constants.FieldNames.General.TITLE] = title;
            Save(newItem);
            return newItem;
        }

        public SPFolder GetFolder(string folderUrl)
        {
            lock (folderLock)
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
        }

        private SPFolder GetSubFolder(SPFolder rootFolder, string partitialUrl)
        {
            SPFolder folder = null;
            try
            {
                folder = rootFolder.SubFolders[partitialUrl];
            }
            catch { }
            return folder;
        }

        public void Save(SPListItem item)
        {
            item.Web.AllowUnsafeUpdates = true;
            item.Update();
        }
    }
}