using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Definizione e Inizializzazione di cartelle e file
            NodoFileSystem Radice = new NodoFileSystem("C:",0);
            

            //Aggiunta di file e cartelle ai nodi genitore            
            var Users= Radice.AggiungiCartella("Users");
            var System= Radice.AggiungiCartella("System");
            Users.AggiungiFile("documento.txt", 50);
            var Desktop= Users.AggiungiCartella("Desktop");
            Desktop.AggiungiFile("foto.jpg", 2000);
            var Documenti= Users.AggiungiCartella("Documenti");
            Documenti.AggiungiFile("relazione.docx",500);
            System.AggiungiFile("kernel.sys", 1000);
            System.AggiungiFile("config.ini", 50);


            //Calcolo Dimensione totale del disco
            Console.WriteLine("==============REPORT==============");
            Console.WriteLine($"Dimensione totale del disco= {NodoFileSystem.Somma(Radice)}");
            Console.WriteLine($"Numero totale di file= {NodoFileSystem.ContaFile(Radice)}");
            Console.WriteLine($"Numero totale di cartelle= {NodoFileSystem.ContaCartelle(Radice)}");
            Console.WriteLine($"Dimensione di Users= {NodoFileSystem.Somma(Users)}");
            Console.WriteLine("----------------------------------");

            //Stampa del contenuto del DISCO
            Console.WriteLine("Stampa del contenuto del DISCO");
            Radice.Stampa();
            Console.WriteLine("----------------------------------");

            //Stampa del contenuto di Users
            Console.WriteLine("Stampa del contenuto di 'Users'");
            Users.Stampa();
            Console.WriteLine("----------------------------------");

            //Stampa del percorso di una cartella
            string percorso_cartella_da_stampare = "Documenti";
            NodoFileSystem ricercaCartella = Radice.Trova(percorso_cartella_da_stampare); //Ricerca una cartella per nome e restituisce il nodo
            Console.WriteLine("Stampa del percorso della cartella 'Documenti'");
            Console.WriteLine($"{NodoFileSystem.CostruisciPercorso(ricercaCartella)}");
            Console.WriteLine();

            //Ricerca della cartella di un file per Nome           
            string File_da_cercare = "foto.jpg";
            Console.WriteLine($"Ricerca file: {File_da_cercare}");
            NodoFileSystem ricercaFile = Radice.Trova(File_da_cercare); //Ricerca un file per nome e restituisce il nodo
            if (ricercaFile != null)
            {
                Console.WriteLine($"File trovato nella cartella: {ricercaFile.NodoGenitore.Nome}/");
                Console.WriteLine($"Percorso completo: {NodoFileSystem.CostruisciPercorso(ricercaFile.NodoGenitore)}/{File_da_cercare}");               
            }
            else
                Console.WriteLine($"File non trovato");
            
        }
    }
}
