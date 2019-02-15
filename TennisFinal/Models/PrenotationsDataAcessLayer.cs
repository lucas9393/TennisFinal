using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisFinal.Models
{
    public class ExpensesDataAcessLayer
    {
        MatchDBContext db = new MatchDBContext();

        public IEnumerable<Prenotation> GetAllPrenotations()
        {
            try
            {
                return db.Prenotations.ToList();
            }
            catch
            {
                throw;
            }
        }

        //Filtra per campo
        public IEnumerable<Prenotation> GetSearchFields(string searchField)
        {
            List<Prenotation> exp = new List<Prenotation>();
            try
            {
                exp = GetAllPrenotations().ToList();
                return exp.Where(x => x.Campo.IndexOf(searchField, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }

        //Aggiungi nuova prenotazione     
        public void AddPrenotation(Prenotation prenotation)
        {
            try
            {
                db.Prenotations.Add(prenotation);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Aggiorna una prenotazione 
        public int UpdatePrenotation(Prenotation prenotation)
        {
            try
            {
                db.Entry(prenotation).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the data for a particular expense  
        public Prenotation GetExpenseData(int id)
        {
            try
            {
                Prenotation expense = db.Prenotations.Find(id);
                return expense;
            }
            catch
            {
                throw;
            }
        }

     
    }
}