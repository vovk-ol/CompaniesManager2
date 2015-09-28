using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyDepenciesTree.Models
{
    public class CompanyNode
    {
        private CompanyNode parent;
        public List<CompanyNode> childs;
        private CompanyEntity company;

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
                return (int)company.Earning;
            }
        }
        public int Id
        {
            get
            {
                return company.Id;
            }
        }

        public CompanyNode(CompanyNode parent, CompanyEntity company, TreeViewModel db)
        {
            this.parent = parent;
            this.company = company;
            if (this.company.Earning == null)
                totallEarning = 0;
            else
                totallEarning = (int)this.company.Earning;

            List<CompanyEntity> childCompanies = db.CompaniesTreeViewTable.Where(c => c.ParentId == company.Id).OrderBy(c => c.Name).ToList();
            foreach (CompanyEntity c in childCompanies)
                AddChild(new CompanyNode(this, c, db));
        }
        private void AddChild(CompanyNode child)
        {
            if (childs == null)
                childs = new List<CompanyNode>();
            childs.Add(child);
            if (child.company.Earning != null)
                AddValueToEarning((int)child.company.Earning);
        }
        private void AddValueToEarning(int value)
        {
            totallEarning += value;
            if (parent != null)
                parent.AddValueToEarning(value);
        }
    }
}