# 🎯 ESERCIZIO ALBERI: SISTEMA DI GESTIONE FILE

## 📋 Descrizione del Problema

Implementare un **sistema di gestione file**. 
I file sono organizzati in una struttura ad **albero** dove:
- La radice è il disco principale `C:/`
- Ogni cartella può contenere altre cartelle o file
- Ogni file ha un nome e una dimensione in KB

---

## 🌍 Applicazione Pratica nel Mondo Reale

Questo è esattamente come funziona un file system reale:
- **Windows Explorer, Finder (Mac) e Sistemi Unix** usano alberi per gestire file e cartelle

---

## ❓ Perché Serve un Albero?

1. I file sono organizzati **gerarchicamente** (cartelle dentro cartelle)
2. Devo **trovare velocemente** un file cercando solo nella sottocartella giusta
3. Devo **sapere lo spazio occupato** da ogni cartella (inclusi sottocartelle)
4. Devo **navigare** la struttura da qualsiasi cartella
5. Le operazioni di **copia/spostamento/cancellazione** devono rispettare la gerarchia

---

## 📝 CONSEGNA

### PARTE 1 - Struttura Base

Crea una classe **`NodoFileSystem`** con:

- Nome del file/cartella
- Dimensione in KB (0 se è una cartella)
- Lista di figli (altri `NodoFileSystem`)
- Nodo Genitore (`NodoFileSystem`)
- Proprietà per sapere se è una cartella o un file

```csharp
public class NodoFileSystem
{
    // TODO: Implementare la classe base
}
```

---

### PARTE 2 - Operazioni Fondamentali

Implementa questi metodi:

| Metodo | Descrizione |
|--------|-------------|
| `AggiungiFile(nome, dimensione)` | Aggiunge un file a questa cartella |
| `AggiungiCartella(nome)` | Aggiunge una sottocartella |
| `Trova(nome)` | Trova il file/cartella per nome (**usare ricorsione!**) |

---

### PARTE 3 - Statistiche base

Implementa questi metodi (**tutti ricorsivi 🤯**):

| Metodo | Descrizione |
|--------|-------------|
| `DimensioneTotale()` | Calcola la dimensione totale. Per una cartella = somma di tutti i figli |
| `NumeroFile()` | Conta quanti file totali |
| `NumeroCartelle()` | Conta quante cartelle totali |

**💡 Ricorda:** Per calcolare qualcosa sull'intera struttura, somma il risultato dei figli!

---

### PARTE 4 - Visualizzazione

Implementa il metodo **`Stampa()`** che mostra la struttura ad albero con **indentazione progressiva**.

**Esempio di output:**
```
C:/
  Users/
    documento.txt (50 KB)
    Desktop/
      foto.jpg (2000 KB)
    Documenti/
      relazione.docx (500 KB)
  System/
    kernel.sys (1000 KB)
    config.ini (50 KB)
```

---

### PARTE 5 - Caso d'Uso (Main)

Costruisci una struttura simile a quella sopra.

Calcola e stampa:
- ✓ Dimensione totale del disco
- ✓ Numero totale di file
- ✓ Numero totale di cartelle
- ✓ Dimensione della cartella "Users" e suo contenuto
- ✓ Dimostrazione della ricerca di un file

---

## 💡 Suggerimenti per lo Sviluppo

1. **Iniziare** dalla classe `NodoFileSystem`
2. **Implementare** prima i metodi semplici (getter/setter)
3. **Poi** implementare `AggiungiFile()` e `AggiungiCartella()`
4. **Implementare** la ricerca `Trova()`
5. **Implementare** `DimensioneTotale()` ricorsivamente
6. **Per la Stampa**, usare uno spazio che aumenta a ogni livello
7. **Buon lavoro!**
