using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetSoft
{
    //Classe per evento
    public class VeicoloEventArgs: EventArgs
    {
        public string TipoVeicolo { get; }
        public decimal Costo { get; }
        public char TipoOperazione { get; }

        public VeicoloEventArgs(string tipoveicolo, decimal costo, char operazione)
        {
            TipoVeicolo = tipoveicolo;
            Costo = costo;
            TipoOperazione = operazione;
        }
    }
}

