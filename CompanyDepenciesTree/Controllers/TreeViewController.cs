using CompanyDepenciesTree.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CompanyDepenciesTree.Controllers
{
    public class TreeViewController : Controller
    {
        // GET: TreeView
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetTree()
        {
            CompaniesTree ctv = null;
            try
            {
                //build companies tree
                ctv = new CompaniesTree(new TreeViewModel());
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
            return View(ctv);
        }
        [HttpGet]
        public ActionResult EditCompany(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            int _id = (int)id;

            TreeViewModel db_cs = new TreeViewModel();
            CompanyEntity company = db_cs.CompaniesTreeViewTable.Find(_id);

            if (company == null)
                return HttpNotFound();

            return View(company);

        }
        [HttpPost]
        public ActionResult EditCompany(
            [Bind(Include = "Id, Name,Earning,ParentId")] CompanyEntity comp)
        {

            if (ModelState.IsValid)
            {
                TreeViewModel db_cs = new TreeViewModel();
                db_cs.Entry(comp).State = EntityState.Modified;
                db_cs.SaveChanges();
            }

            return View(comp);

        }
        [HttpGet]
        public ActionResult CreateCompany(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            int _id = (int)id;
            CompanyEntity company = new CompanyEntity();
            company.ParentId = _id;
            return View(company);
        }
        [HttpPost]
        public ActionResult CreateCompany(
           [Bind(Include = "Id, Name,Earning,ParentId")] CompanyEntity comp)
        {
            if (ModelState.IsValid)
            {
                TreeViewModel db_cs = new TreeViewModel();
                db_cs.CompaniesTreeViewTable.Add(comp);
                db_cs.SaveChanges();

            }
            return View(comp);
        }
        [HttpGet]
        public ActionResult DeleteCompany(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            int _id = (int)id;
            TreeViewModel db_cs = new TreeViewModel();
            CompanyEntity company = db_cs.CompaniesTreeViewTable.Find(_id);
            if (company == null)
                return HttpNotFound();
            return View(company);
        }
        [HttpPost, ActionName("DeleteCompany")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            TreeViewModel db_cs = new TreeViewModel();
            CompanyEntity comp = db_cs.CompaniesTreeViewTable.Find(id);
            if (comp == null)
                return HttpNotFound();

            //get childs for change it's parent
            IQueryable<CompanyEntity> childs = db_cs.CompaniesTreeViewTable.Where(c => c.ParentId == comp.Id);
            if (childs.Count() > 0)
                //move childs to up level in tree
                foreach (CompanyEntity c_c in childs)
                {
                    c_c.ParentId = comp.ParentId;
                    db_cs.Entry(c_c).State = EntityState.Modified;
                }

            db_cs.CompaniesTreeViewTable.Remove(comp);

            db_cs.SaveChanges();
            return RedirectToAction("GetTree");
        }
    }
}