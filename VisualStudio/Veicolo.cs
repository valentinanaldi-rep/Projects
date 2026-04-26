using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FleetSoft
{
    public abstract class Veicolo:IVeicolo 
    {
        private string _targa;
        private int _velocita;
        public string Marca { get; private set; }
        public string Modello { get; private set; }
        

        public string Targa
        {
            get { return _targa; }
            set{ _targa = value; }
        }
        public int VelocitaAttuale
        {
            get { return _velocita; }
            set { _velocita = value; }
        }
        
        public Veicolo(string marca, string modello, string targa, int velocita)
        {
            Marca = marca;
            Modello = modello;
            Targa = targa;
            VelocitaAttuale = velocita;;
            
        }
        public void Accellera()
        {
            Console.WriteLine($"Accellero! velocità attuale {VelocitaAttuale}");

        }
        public void Frena()
        {
            Console.WriteLine($"Freno! velocità attuale {VelocitaAttuale}");

        }
        public string RestituisciTarga()
        {
            return Targa;
        }
        

        
    }

}
