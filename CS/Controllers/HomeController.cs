using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using DevExpress.Web.Mvc;
using DevExpress.Xpo;
using Xpo = DevExpress.Xpo;

namespace Example.Controllers {
    public class HomeController : Controller, IXpoController {
        public Session XpoSession { get; private set; }

        public HomeController() {
            XpoSession = XpoHelper.GetNewSession();
        }

        public ActionResult Index() {
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";
            ViewBag.combobox = GetComboBoxTable();

            return View(GetTable());
        }

        public ActionResult GridViewPartial() {
            ViewBag.combobox = GetComboBoxTable();

            return PartialView(GetTable());
        }

        [HttpPost]
        public ActionResult InsertPartial(Article article) {
            Int32 categoryKey = Convert.ToInt32(Request.Params["categoryId"]);
            article.Category = XpoSession.GetObjectByKey<Category>(categoryKey);

            article.Save();

            ViewBag.combobox = GetComboBoxTable();
            return PartialView("GridViewPartial", GetTable());
        }

        [HttpPost]
        public ActionResult UpdatePartial(Article article) {
            Int32 categoryKey = Convert.ToInt32(Request.Params["categoryId"]);
            article.Category = XpoSession.GetObjectByKey<Category>(categoryKey);

            article.Save();

            ViewBag.combobox = GetComboBoxTable();
            return PartialView("GridViewPartial", GetTable());
        }

        [HttpPost]
        public ActionResult DeletePartial(Int32 Oid) {
            Article article = XpoSession.GetObjectByKey<Article>(Oid);
            article.Delete();

            article.Save();

            ViewBag.combobox = GetComboBoxTable();
            return PartialView("GridViewPartial", GetTable());
        }

        protected XPCollection<Article> GetTable() {
            XPCollection<Article> collection = new XPCollection<Article>(XpoSession);
            collection.Sorting.Add(new SortProperty("Oid", Xpo.DB.SortingDirection.Ascending));

            return collection;
        }

        protected XPCollection<Category> GetComboBoxTable() {
            XPCollection<Category> collection = new XPCollection<Category>(XpoSession);
            collection.Sorting.Add(new SortProperty("Oid", Xpo.DB.SortingDirection.Ascending));

            return collection;
        }
    }
}
