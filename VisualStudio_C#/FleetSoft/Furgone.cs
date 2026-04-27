using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FleetSoft
{
    public class Furgone : Veicolo, INoleggiabile
    {
        private double _portata;
        private const decimal _tariffa= 150.0m;
        private bool _isDisponibile = true;
        

        public double Portata
        {
            get { return _portata; }
            private set { _portata = Math.Max(0, value); }
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
        public Furgone(string marca, string modello, string targa, int velocita, double portata) : base(marca, modello,targa, velocita)
        {
            this.Portata = portata;

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
            return $"Furgone | {Targa} | {Marca} | {Modello} | {Portata} t |";
        }

        protected double RestituisciPortata()
        {
            return Portata;
        }
    }
}

