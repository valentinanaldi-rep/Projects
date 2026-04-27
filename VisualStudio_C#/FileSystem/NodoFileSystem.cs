using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public class NodoFileSystem
    {
        //Proprietà di un Nodo del FileSystem
        public string Nome { get; set; }
        public int Dimensione { get; set; }
        public List<NodoFileSystem> ListaFigli { get; set; } 
        public NodoFileSystem NodoGenitore { get; set; }

        private bool isCartella { get; set; } = false;


        //Costruttore
        public NodoFileSystem(string nome, int dimensione=0)
        {
            Nome = nome;
            Dimensione = Math.Max(dimensione, 0);  //Se è 0 è una cartella
            ListaFigli = new List<NodoFileSystem>();
            if (dimensione == 0) isCartella = true;
        }


        //METODI
        //Metodo che ritorna se cartella oppure file
        public bool IdDir()
        {
            return isCartella;
        }
        //Metodo per creare un nodo
        public void AggiungiNodo(NodoFileSystem nodo)
        {
            nodo.NodoGenitore = this;
            ListaFigli.Add(nodo);
        }

        //Metodo per aggiungere un file al nodo chiamante
        public void AggiungiFile(string nome, int dimensione)
        {
            var file= new NodoFileSystem(nome, dimensione);
            AggiungiNodo(file);
        }
        //Metodo per aggiungere una cartella al nodo chiamante
        public NodoFileSystem AggiungiCartella(string nome)
        {
            var cartella = new NodoFileSystem(nome);
            AggiungiNodo(cartella);
            return cartella;
        }
                

        //Metodo per cercare un componente per nome  e restituire l'oggetto
        public NodoFileSystem Trova(string nome)
        {            
            if (this.Nome == nome) return this;

            foreach (NodoFileSystem figlio in this.ListaFigli)
            {
                NodoFileSystem risultato = figlio.Trova(nome);

                if (risultato != null) return risultato;
            }

            return null;
            
        }

        //Metodo per calcolare la dimensione totale di tutti i file di una cartella
        public static int Somma(NodoFileSystem componente)
        {
            if (!componente.isCartella ) return componente.Dimensione; //se è un file ne ritorna la dimensiome

            int dimTot = 0;

            foreach (NodoFileSystem figlio in componente.ListaFigli)
            {
                dimTot += Somma(figlio);
            }

            return dimTot;
        }

        //Metodo per contare i file in una cartella
        public static int ContaFile(NodoFileSystem cartella)
        {
            if (cartella == null) return 0;
            int count = 0;
            
            foreach (NodoFileSystem n in cartella.ListaFigli)
            {
                if (!n.isCartella)
                {
                    count++;
                }
                else
                {
                    count += ContaFile(n); // ricorsione sulle sottocartelle
                }
            }

            return count;
        }

        //Metodo per contare le cartelle in una cartella
        public static int ContaCartelle(NodoFileSystem cartella)
        {
            if (cartella == null) return 0;
            int count = 1;
            
            foreach (NodoFileSystem n in cartella.ListaFigli)
            {
                if (n.isCartella)
                {
                    //count++;
                    count += ContaCartelle(n);
                }
                
            }

            return count;
        }
        
        //Metodo per stampare il contenuto di una cartella
        public void Stampa(int livello = 0)
        {
            
            string indent = new string(' ', livello * 2);

            Console.WriteLine($"{indent}{this.Nome}/");

            foreach (NodoFileSystem n in this.ListaFigli)
            {
                if (n.isCartella)
                    n.Stampa(livello + 1);
                else
                    Console.WriteLine($"{indent}  {n.Nome} ({n.Dimensione} KB)");
            }
        }
        //Metodo per stampare il percorso di un elemento
        public static string CostruisciPercorso(NodoFileSystem nodo)
        {
            var percorso=new List<string>();
            var attuale = nodo;
            while (attuale != null)
            {
                percorso.Add(attuale.Nome);
                attuale = attuale.NodoGenitore;
            }
            percorso.Reverse(); //inverte gli elementi della lista
            return string.Join("/", percorso); //ritorna la stringa con gli elementi concatenati con /
        }
    }
}
