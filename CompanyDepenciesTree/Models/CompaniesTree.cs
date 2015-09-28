﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyDepenciesTree.Models
{
    public class CompaniesTree
    {
        public List<CompanyNode> headNodes;
        public int ChildCount
        {
            get
            {
                if (headNodes == null) return 0;
                return headNodes.Count;
            }
        }
        public CompaniesTree()
        {
            headNodes = new List<CompanyNode>();
        }
        //Load from data base
        public CompaniesTree(TreeViewModel db)
        {
            headNodes = new List<CompanyNode>();

         List < CompanyEntity> cps=   db.CompaniesTreeViewTable.Where(s => s.ParentId == 0).ToList();
                // find company without parent company
                foreach (CompanyEntity c in cps)
                {
                    //if (db.CompaniesTreeViewTable.Find(c.ParentId) == null)
                        headNodes.Add(new CompanyNode(null, c, db));
                }
           
        }
    }
}