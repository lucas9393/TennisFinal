using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisFinal.Models
{
    interface DataAcessLayer
    {
        IEnumerable<Prenotation> GetAllPrenotations();
        IEnumerable<Prenotation> GetSearchFields(string searchField);
        void AddPrenotation(Prenotation prenotation);
        int UpdatePrenotation(Prenotation prenotation);
        Prenotation GetPrenotationData(int id);
    }
}
