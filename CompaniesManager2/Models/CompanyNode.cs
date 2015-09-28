using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompaniesManager2.Models
{
    public class CompanyNode
    {
        private CompanyNode parent;
        public List<CompanyNode> childs;
        private CompaniesTreeViewTable company;

        private int totallEarning;

        public int TotallEarning
        {
            get
            {
                return totallEarning;
            }
        }
        public string Name
        {
            get
            {
                return company.Name;
            }
        }
        public int Earning
        {
            get
            {
                return (int)company.AnnualEarning;
            }
        }
        public int Id
        {
            get
            {
                return company.Id;
            }
        }

        public CompanyNode(CompanyNode parent, CompaniesTreeViewTable company, TreeViewModel db)
        {
            this.parent = parent;
            this.company = company;
            if (this.company.AnnualEarning == null)
                totallEarning = 0;
            else
                totallEarning = (int)this.company.AnnualEarning;

            List<CompaniesTreeViewTable> childCompanies = db.CompaniesTreeViewTable.Where(c => c.ParentId == company.Id).OrderBy(c => c.Name).ToList();
            foreach (CompaniesTreeViewTable c in childCompanies)
                AddChild(new CompanyNode(this, c, db));
        }
        private void AddChild(CompanyNode child)
        {
            if (childs == null)
                childs = new List<CompanyNode>();
            childs.Add(child);
            if (child.company.AnnualEarning != null)
                AddValueToEarning((int)child.company.AnnualEarning);
        }
        private void AddValueToEarning(int value)
        {
            totallEarning += value;
            if (parent != null)
                parent.AddValueToEarning(value);
        }
    }
}