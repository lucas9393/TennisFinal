using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace TennisFinal.Controllers
{
    public class ExpenseController : Controller
    {
        PrenotationsDataAcessLayer objPrenotation = new PrenotationsDataAcessLayer();

        public IActionResult Index(string searchString)
        {
            List<Prenotation> lstPrenotations = new List<Prenotation>();
            lstPrenotations = objPrenotation.GetAllPrenotations().ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                lstPrenotations = objPrenotation.GetSearchFields(searchString).ToList();
            }
            return View(lstPrenotations);
        }

        public ActionResult AddEditPrenotations(int itemId)
        {
            Prenotation model = new Prenotation();
            if (itemId > 0)
            {
                model = objPrenotation.GetPrenotationData(itemId);
            }
            return PartialView("_prenotationForm", model);
        }

        [HttpPost]
        public ActionResult Create(Prenotation prenotation)
        {
            if (ModelState.IsValid)
            {
                if (prenotation.Id_Prenotazione > 0)
                {
                    objPrenotation.UpdatePrenotation(prenotation);
                }
                else
                {
                    objPrenotation.AddPrenotation(prenotation);
                }
            }
            return RedirectToAction("Index");
        }

       
    }
}
