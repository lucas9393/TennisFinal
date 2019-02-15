using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Controllers
{
    public class ExpenseController : Controller
    {
        ExpensesDataAcessLayer objexpense = new ExpensesDataAcessLayer();

        public IActionResult Index(string searchString)
        {
            List<Prenotation> lstEmployee = new List<Prenotation>();
            lstEmployee = objexpense.GetAllPrenotations().ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                lstEmployee = objexpense.GetSearchFields(searchString).ToList();
            }
            return View(lstEmployee);
        }

        public ActionResult AddEditExpenses(int itemId)
        {
            Prenotation model = new Prenotation();
            if (itemId > 0)
            {
                model = objexpense.GetExpenseData(itemId);
            }
            return PartialView("_expenseForm", model);
        }

        [HttpPost]
        public ActionResult Create(Prenotation prenotation)
        {
            if (ModelState.IsValid)
            {
                if (prenotation.Id_Prenotazione > 0)
                {
                    objexpense.UpdatePrenotation(prenotation);
                }
                else
                {
                    objexpense.AddPrenotation(prenotation);
                }
            }
            return RedirectToAction("Index");
        }

       
    }
}
