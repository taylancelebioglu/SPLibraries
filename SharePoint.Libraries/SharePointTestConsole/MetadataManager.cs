using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharePointTestConsole
{
    public class MetadataManager
    {
        private readonly SPSite site;
        private readonly TaxonomySession session;
        private string GroupName;

        public MetadataManager(SPSite site)
        {
            this.site = site;
            this.session = new TaxonomySession(site);
            GroupName = "Innova Portal";
        }
        public MetadataManager(SPSite site, string groupName)
        {
            this.site = site;
            this.session = new TaxonomySession(site);
            GroupName = groupName;
        }
        #region Properties
        public TermStoreCollection TermStores
        {
            get { return session.TermStores; }
        }
        public TermStore TermStore
        {
            get { return session.DefaultSiteCollectionTermStore; }
        }
        public GroupCollection TermStoreGroups
        {
            get { return TermStore.Groups; }
        }
        public Group TermStoreGroup
        {
            get
            {
                if (String.IsNullOrEmpty(GroupName))
                {
                    throw new Exception("Term store group name is null");
                }
                return TermStoreGroups[GroupName];
            }
        }
        #endregion

        public bool HasTermStoregroup()
        {
            return TermStoreGroups.OfType<Group>().Where(s => s.Name == GroupName).Any();
        }
        public Group CreateGroup(string groupName)
        {
            var group = TermStore.Groups.FirstOrDefault(g => g.Name.Equals(groupName, StringComparison.InvariantCultureIgnoreCase));
            if (group == null)
            {
                group = TermStore.CreateGroup(groupName);
                TermStore.CommitAll();
            }
            return group;
        }
        public Term AddTerm(TermSet termSet, string termName)
        {
            return AddTerm(termSet, termName, TermStore.DefaultLanguage);
        }
        public Term AddTerm(TermSet termSet, string termName, int lcId)
        {
            termName = termName.Trim().Replace(((char)31).ToString(), "");
            //termName = ReplaceIllegalTermCharacters(termName);
            Term newTerm = this.CheckTerm(termSet, termName);

            if (newTerm == null)
            {
                Exception termAddExc = new Exception();
                int i = 0;
                do
                {
                    i++;
                    try
                    {
                        newTerm = termSet.CreateTerm(termName, Convert.ToInt32(lcId));
                        this.TermStore.CommitAll();
                    }
                    catch (Exception exc)
                    {
                        termAddExc = new Exception(exc.Message, termAddExc);
                    }

                    newTerm = this.CheckTerm(termSet, termName);

                    if (newTerm != null)
                    {
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                }
                while (i < 5);

                if (newTerm == null)
                {
                    throw termAddExc;
                }

                //LogHandler.LogWarning(string.Format("New Term: {0} has been created. TermSet name: {1}", termName, termSet.Name));
            }
            return newTerm;
        }
        public Term AddTerm(Term parentTerm, string termName)
        {
            return AddTerm(parentTerm, termName, TermStore.DefaultLanguage);
        }
        public Term AddTerm(Term parentTerm, string termName, int lcId)
        {
            var isAdded = this.CheckTerm(parentTerm, termName);
            Term term = null;
            if (!isAdded)
            {
                term = parentTerm.CreateTerm(termName, lcId);
                TermStore.CommitAll();
            }
            return term;
        }
        private bool CheckTerm(Term parentTerm, string termName)
        {
            if (parentTerm == null)
                throw new Exception("Parent Term can not be null");
            if (parentTerm.Terms != null && parentTerm.Terms.Count > 0)
                return parentTerm.Terms.Where(s => s.Name == termName).Count() > 0 ? true : false;
            else
                return false;
        }
        private Term CheckTerm(TermSet termSet, string termName)
        {
            TermCollection terms = termSet.GetTerms(termName, true);

            if (terms != null && terms.Count > 0)
                return terms[0];
            else
                return null;
        }
        public Term GetTerm(Guid termSetId, string termName)
        {
            TermSet termSet = TermStore.GetTermSet(termSetId);
            return GetTerm(termSet, termName);
        }
        public Term GetTerm(string termSetName, string termName)
        {
            TermSet termSet = this.GetTermSet(termSetName);
            return GetTerm(termSet, termName);
        }
        public Term GetTerm(TermSet termSet, string termName)
        {
            Term retVal = null;
            TermCollection terms = termSet.GetTerms(termName, false);

            foreach (Term current in terms)
            {
                if (current.GetDefaultLabel(TermStore.DefaultLanguage).Equals(termName))
                {
                    retVal = current;
                    break;
                }
            }
            return retVal;
        }
        public Term GetTermByTermSetName(string termSetListName, string termName)
        {
            TermSet termSet = TermStoreGroup.TermSets[termSetListName];
            return GetTerm(termSet, termName);
        }
        public Term CreateLabel(Term term, string label, bool setAsDefault = false, int lcId = 0)
        {
            var current = term.Labels.FirstOrDefault(l => l.Value.Equals(label, StringComparison.InvariantCultureIgnoreCase));

            if (current == null)
            {
                if (lcId == 0)
                {
                    lcId = TermStore.DefaultLanguage;
                }
                
                term.CreateLabel(label, lcId, setAsDefault);
                TermStore.CommitAll();
            }
            else
            {
                
            }
            return term;
        }
        public Term UpdateDefaultLabel(string termsetList, string termName, string newLabel)
        {
            Term term = GetTermByTermSetName(termsetList, termName);
            if (term != null)
            {
                term.CreateLabel(newLabel, 1033, true);
                TermStore.CommitAll();
                RemoveTermLabel(term, termName);
            }
            return term;
        }
        public Term UpdateDefaultLabel(TermSet ts, string sapId, string newLabel)
        {
            Term t = GetTermViaLabel(ts.Terms, sapId);
            if (t != null)
            {
                string defValue = t.GetDefaultLabel(TermStore.DefaultLanguage);
                t.CreateLabel(newLabel, TermStore.DefaultLanguage, true);
                TermStore.CommitAll();
                RemoveTermLabel(t, defValue);
            }
            return t;
        }
        public TermSet GetTermSet(string termSetName)
        {
            return TermStoreGroup.TermSets.OfType<TermSet>().FirstOrDefault(s => s.Name == termSetName);
        }
        public TermSet GetTermSet(Guid termSetGuid)
        {
            return TermStoreGroup.TermSets.OfType<TermSet>().FirstOrDefault(s => s.Id == termSetGuid);
        }
        public TermSet AddTermSet(string termSetName)
        {
            TermSet termSet = this.GetTermSet(termSetName);

            if (termSet == null)
            {
                termSet = TermStoreGroup.CreateTermSet(termSetName);
                termSet.IsOpenForTermCreation = true;
                TermStore.CommitAll();
            }
            else
            {
                string message = string.Format("{0} term set already exists", termSetName);
                
            }
            return termSet;
        }
        public bool MergeTerm(string termsetList, string termName, string destionationTerm)
        {
            bool result = false;
            Term newTerm = GetTermByTermSetName(termsetList, destionationTerm);
            Term oldTerm = GetTermByTermSetName(termsetList, termName);

            if (newTerm != null && oldTerm != null)
            {
                oldTerm.Merge(newTerm);
                TermStore.CommitAll();
                result = true;
            }
            else
            {
                if (newTerm == null)
                {
                    //LogHandler.LogWarning(string.Format("new term {0} is null", destionationTerm));
                }

                if (oldTerm == null)
                {
                    //LogHandler.LogWarning(string.Format("old term {0} is null", termName));
                }
            }
            return result;
        }
        private bool IsTermAvailable(string keyword, string phrase, string[] characters)
        {
            bool result = true;
            if (string.IsNullOrEmpty(keyword))
            {
                if (CheckStartsWith(phrase, characters))
                {
                    result = false;
                }
            }
            return result;
        }
        private bool CheckStartsWith(string p, string[] filterCharacters)
        {
            bool result = false;

            foreach (string s in filterCharacters)
            {
                if (p.StartsWith(s, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        public void CreateTermLabel(string termSet, string term, string label, int lcId, bool isDefault)
        {
            TermSet set = GetTermSet(termSet);
            Term currentTerm = GetTerm(set, term);
            currentTerm.CreateLabel(label, lcId, isDefault);
            TermStore.CommitAll();
        }
        public void RemoveTermLabel(string termSet, string term, string label)
        {
            Microsoft.SharePoint.Taxonomy.TermSet set = GetTermSet(termSet);
            Microsoft.SharePoint.Taxonomy.Term currentTerm = GetTerm(set, term);
            Label termLabel = currentTerm.Labels[label];
            termLabel.Delete();
            TermStore.CommitAll();
        }
        public void RemoveTermLabel(Microsoft.SharePoint.Taxonomy.Term term, string label)
        {
            Label termLabel = term.Labels[label];
            termLabel.Delete();
            TermStore.CommitAll();
        }
        public Term GetTermViaLabel(TermCollection termCol, string label)
        {
            Term t = null;
            foreach (var item in termCol)
            {
                bool isfound = item.Labels.Where(s => s.Value == label).Any();
                if (isfound)
                {
                    t = item;
                    break;
                }
                else
                {
                    t = GetTermViaLabel(item.Terms, label);
                    if (t != null)
                    {
                        return t;
                    }
                }
            }
            return t;
        }
        public void MapTaxonomyField(TaxonomyField field, TermSet termSet)
        {
            field.SspId = termSet.TermStore.Id;
            field.TermSetId = termSet.Id;
            field.Group = termSet.Group.Name;
            field.TargetTemplate = string.Empty;
            field.AnchorId = Guid.Empty;
            field.Update();
        }
        public void MapTaxonomyField(TaxonomyField field, string termSetName)
        {
            TermSet termSet = this.GetTermSet(termSetName);
            field.SspId = termSet.TermStore.Id;
            field.TermSetId = termSet.Id;
            field.TargetTemplate = string.Empty;
            field.AnchorId = Guid.Empty;
            field.Update();
        }
        public string GetMatchingTermSetName(FieldInfo[] metadataFields, string fieldName, bool isRecursive)
        {
            string termSetName = string.Empty;
            IEnumerable<FieldInfo> termSetInfo = metadataFields.Where(x => x.Name == fieldName);
            if (termSetInfo != null && termSetInfo.Count() > 0)
                termSetName = termSetInfo.First().Name;
            else
            {
                if (!isRecursive)
                    termSetName = GetMatchingTermSetName(metadataFields, fieldName + "s", true);
            }
            return termSetName;
        }
        public String ExctractTermName(string termValue)
        {
            if (!string.IsNullOrEmpty(termValue))
            {
                string[] seperated = termValue.Split(TaxonomyField.TaxonomyGuidLabelDelimiter);

                return seperated[0];
            }
            else
            {
                throw new Exception("termValue is null");
            }
        }
        public string GetTaxonomyFieldValue(string termSetList, string value)
        {
            string fieldValue = string.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                if (IsTermValue(value))
                    fieldValue = value;
                else
                {
                    Term term = GetTerm(termSetList, value);
                    string termId = (term != null) ? term.Id.ToString() : "22222222-2222-2222-2222-222222222222";
                    fieldValue = value + TaxonomyField.TaxonomyGuidLabelDelimiter + termId;
                }
            }
            return fieldValue;
        }
        public bool IsTermValue(string value)
        {
            if (value.Contains(TaxonomyField.TaxonomyGuidLabelDelimiter))
            {
                try
                {
                    Guid id = new Guid(value.Substring(value.IndexOf(TaxonomyField.TaxonomyGuidLabelDelimiter) + 1));
                    return true;
                }
                catch { return false; }
            }
            return false;
        }
        public bool HasValue(object fieldValue)
        {
            string value = Convert.ToString(fieldValue);

            if (value.Contains(TaxonomyField.TaxonomyGuidLabelDelimiter))
            {
                if (value.Contains("22222222-2222-2222-2222-222222222222"))
                {
                    return false;
                }
                else
                {
                    try
                    {
                        Guid id = new Guid(value.Substring(value.IndexOf(TaxonomyField.TaxonomyGuidLabelDelimiter) + 1));
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        public static string GetTermValue(TaxonomyFieldValueCollection taxonomyFieldValues)
        {
            StringBuilder fieldValue = new StringBuilder();
            foreach (TaxonomyFieldValue taxonomyFieldValue in taxonomyFieldValues)
            {
                fieldValue.Append(String.Format("{0}{1}{2}{3}",
                    taxonomyFieldValue.Label,
                    TaxonomyField.TaxonomyGuidLabelDelimiter,
                    taxonomyFieldValue.TermGuid,
                    SPFieldMultiColumnValue.Delimiter));
            }

            return fieldValue.ToString().TrimEnd(SPFieldMultiColumnValue.Delimiter.ToCharArray());
        }
        public static string ReplaceIllegalTermCharacters(string termName)
        {
            string invalidChars = "\t;\"<>|&" + ((char)31).ToString();
            return System.Text.RegularExpressions.Regex.Replace(termName, invalidChars, "");
        }
    }
}
