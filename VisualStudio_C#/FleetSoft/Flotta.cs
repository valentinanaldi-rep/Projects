namespace FleetSoft
{
    public class Flotta
    {

        private List<INoleggiabile> _veicoli = new();
        private char _operazione = 'c';
        private static int numeroTotaleVeicoli = 0;
        public event EventHandler<VeicoloEventArgs>? VeicoloNoleggiato;

        //Metodo per aggiungere alla flotta un veicolo
        public void AggiungiVeicolo(INoleggiabile v)
        {
            _veicoli.Add(v);
            numeroTotaleVeicoli++;
        }
        //Metodo per togliere dalla flotta un veicolo
        public void RimuoviVeicolo(INoleggiabile v)
        {
            _veicoli.Remove(v);
            numeroTotaleVeicoli--;
        }

        //Metodo per avviare un'operazione di noleggio
        public void EseguiNoleggio(INoleggiabile v, int giorni)
        {
            if (!v.IsDisponibile)
                Console.WriteLine($"{v.ToString()} già noleggato");
            else
            {
                _operazione = 'n';
                Console.WriteLine($"\nNoleggio veicolo per {giorni} giorni...");
                decimal costo = v.Noleggia(giorni);
                var args = new VeicoloEventArgs(v.ToString(), costo, _operazione);
                AvvisoNoleggio(args);
                v.IsDisponibile = false;
            }
        }
        //Metodo per chiudere un'operazione di noleggio
        public void ChiudiNoleggio(INoleggiabile v, int giorni)
        {
            if (v.IsDisponibile)
                Console.WriteLine($"{v.ToString()} già disponibile");
            else
            {
                _operazione = 'c';
                Console.WriteLine($"\nVeicolo rientrato dopo {giorni} giorni...");
                decimal costo = v.Noleggia(giorni);
                var args = new VeicoloEventArgs(v.ToString(), costo, _operazione);
                AvvisoNoleggio(args);
                v.IsDisponibile = true;
            }
        }

        //Metodo per stampare tutta la flotta
        public void StampaFlotta()
        {
            Console.WriteLine("\nVeicoli registrati nella flotta");
            foreach (INoleggiabile v in _veicoli)
            {
                string stringa = v.IsDisponibile ? "Disponibile" : "Noleggiato";
                Console.WriteLine(v.ToString() + stringa);
            }
            Console.WriteLine($"Totale veicoli: {GetNumeroTotaleVeicoli()}");
        }
        //Metodo per stampare solo i veicoli disponibili
        public void VeicoliDisponibili()
        {
            Console.WriteLine("Veicoli attualmente disponibili");
            foreach (INoleggiabile v in _veicoli)
            {
                if (v.IsDisponibile) Console.WriteLine(v.ToString());
            }

        }

        //Evento noleggio
        protected virtual void AvvisoNoleggio(VeicoloEventArgs args)
        {
            VeicoloNoleggiato?.Invoke(this, args);
        }
        //netodo per ritornare il numero totale di veicoli in flotta
        public static int GetNumeroTotaleVeicoli()
        {
            return numeroTotaleVeicoli;
        }

        public void Stampa(object? sender, VeicoloEventArgs e)
        {
            if (e.TipoOperazione == 'n')
                Console.WriteLine($"Noleggio avviato per veicolo: {e.TipoVeicolo} - Costo: {e.Costo:F1} EUR");
            else if (e.TipoOperazione == 'c')
                Console.WriteLine($"Noleggio concluso per veicolo: {e.TipoVeicolo} - Costo: {e.Costo:F1} EUR");
        }
    }
}
