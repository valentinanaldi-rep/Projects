using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetSoft
{
    public class Auto : Veicolo, INoleggiabile
    {
        private int _numPorte;
        private const decimal _tariffa = 125.0m;
        private bool _isDisponibile =true;

        public int NumeroPorte
        {
            get { return _numPorte; }
            private set { _numPorte = Math.Max(0, value); }
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
        public Auto(string marca, string modello, string targa, int velocita, int numeroPorte) : base(marca, modello, targa, velocita)
        {
            this.NumeroPorte = numeroPorte;          

        }
        public decimal Noleggia(int giorni)
        {            
            IsDisponibile = false;
            return giorni*Tariffa;
        }
        public void Restituisci()
        {
            IsDisponibile = true;
        }
        public override string ToString()
        {
            return $"AUTO | {Targa} | {Marca}  | {Modello} | {NumeroPorte} porte | ";
        }
        
        public event EventHandler<Auto>? NoleggiataHandler;
        protected virtual void OnAllarmeScattato(Auto a)
        {
            NoleggiataHandler?.Invoke(this, a);
        }
        

    }
}


