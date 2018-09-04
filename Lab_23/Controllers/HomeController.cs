using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_23.Models;

namespace Lab_23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Lab23DB ORM = new Lab23DB();
            ViewBag.Items = ORM.Items.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult NewItem()
        {
            return View();
        }
        public ActionResult SaveNewItem(Item newItem)
        {
            Lab23DB ORM = new Lab23DB();


            ORM.Items.Add(newItem);

            ORM.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult SearchItemByName(string Name)
        {
            Lab23DB ORM = new Lab23DB();

            ViewBag.Items = ORM.Items.Where(x => x.Name.ToLower().Contains(Name.ToLower())).ToList();

            return View("Index");
        }
        public ActionResult DeleteItem(string ID)
        {
            Lab23DB ORM = new Lab23DB();

            Item ItemToDelete = ORM.Items.Find(ID);

            ORM.Items.Remove(ItemToDelete);

            ORM.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult ItemDetails(string ID)
        {
            Lab23DB ORM = new Lab23DB();

            Item ItemToEdit = ORM.Items.Find(ID);

            if (ItemToEdit == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.ItemToEdit = ItemToEdit;

            return View();
        }
        public ActionResult SaveChanges(Item UpdatedItem)
        {
            Lab23DB ORM = new Lab23DB();

            Item OldRecord = ORM.Items.Find(UpdatedItem.ID);

            //Check for Null
            if (OldRecord == null)
            {
                return RedirectToAction("Index");
            }

            OldRecord.Name = UpdatedItem.Name;
            OldRecord.Description = UpdatedItem.Description;
            OldRecord.Quantity = UpdatedItem.Quantity;
            OldRecord.Price = UpdatedItem.Price;

            //Modifies record (original vs current)
            ORM.Entry(OldRecord).State = System.Data.Entity.EntityState.Modified;

            ORM.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}