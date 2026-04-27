using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetSoft
{
    public class Moto : Veicolo, INoleggiabile
    {
        private int _cilindrata;
        private const decimal _tariffa = 100.0m;
        private bool _isDisponibile = true;

        public int Cilindrata
        {
            get { return _cilindrata; }
            private set { _cilindrata = value; }
        }
        public decimal Tariffa
        {
            get { return _tariffa; }            
        }
        public bool IsDisponibile
        {
            get { return _isDisponibile; }
            set { _isDisponibile = value; }
        }

        public Moto(string marca, string modello, string targa, int velocita, int cilindrata) : base(marca, modello, targa, velocita)
        {
            Cilindrata = cilindrata;

        }
        public decimal Noleggia(int giorni)
        {
           
            IsDisponibile = false;
            return giorni * Tariffa;
        }
        public void Restituisci()
        {
            IsDisponibile = true;
        }
        public override string ToString()
        {
            return $"Moto | {Targa} | {Marca} | {Modello} | {Cilindrata} cc |";
        }
        public int RestituisciCilindrata()
        {
            return Cilindrata;
        }

    }

}

