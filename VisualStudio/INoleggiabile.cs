using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetSoft
{
    public interface INoleggiabile
    {
        public bool IsDisponibile {  get; set; }
        decimal Noleggia(int giorni);
        void Restituisci();

    }
}
