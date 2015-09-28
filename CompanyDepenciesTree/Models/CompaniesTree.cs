using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyDepenciesTree.Models
{
    public class CompaniesTree
    {
        public List<CompanyNode> rootNodes;
        public int ChildCount
        {
            get
            {
                if (rootNodes == null) return 0;
                return rootNodes.Count;
            }
        }
        public CompaniesTree()
        {
            rootNodes = new List<CompanyNode>();
        }
        //Load from data base
        public CompaniesTree(TreeViewModel db)
        {
            //find all companies for tree root
            rootNodes = new List<CompanyNode>();
            List<CompanyEntity> cps = db.CompaniesTreeViewTable.Where(s => s.ParentId == 0).ToList();
            foreach (CompanyEntity c in cps)
                rootNodes.Add(new CompanyNode(null, c, db));
        }
    }
}