namespace FleetSoft
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auto auto1 = new Auto("Fiat", "Panda", "AB123CD", 100, 4);
            Moto moto1= new Moto("Honda", "CB500", "CF345ET", 180, 500 );
            Furgone fur1 = new Furgone("Fiat", "Ducato", "DE768GH", 120, 1.5d);

            Flotta flotta = new();
            flotta.VeicoloNoleggiato += flotta.Stampa;
            flotta.AggiungiVeicolo(auto1);
            flotta.AggiungiVeicolo(moto1);
            flotta.AggiungiVeicolo(fur1);

            flotta.StampaFlotta();

            flotta.EseguiNoleggio(auto1, 3);
            flotta.EseguiNoleggio(moto1, 2);
            flotta.VeicoliDisponibili();


            flotta.ChiudiNoleggio(auto1, 3);
            flotta.ChiudiNoleggio(moto1, 5);
            flotta.StampaFlotta();
            
        }
    }
}
