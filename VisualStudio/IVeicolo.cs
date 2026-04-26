using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetSoft
{
    public interface IVeicolo
    {
        public string Targa {  get; set; }
        public int VelocitaAttuale {  get; set; }

        public void Accellera();
        public void Frena();


    }
}
