create database Progetto_Finale;
use Progetto_Finale;

--Creazione tabella utente
CREATE TABLE Utenti		(IDUtente INT PRIMARY KEY, 
						Username NVARCHAR(100) NOT NULL UNIQUE ,
						strPassword NVARCHAR(100) NOT NULL,
						DataNascita DATE);

--Creazione tabella Insegnanti
CREATE TABLE Insegnanti (IDInsegnante INT PRIMARY KEY, 
						Username NVARCHAR(100) NOT NULL UNIQUE ,
						strPassword NVARCHAR(100),
						DataNascita DATE);
--Creazione tabella TipologieCorsi
CREATE TABLE TipologieCorsi(IDTipologia INT PRIMARY KEY, 
							Nome NVARCHAR(100) NOT NULL,
							ParoleChiave NVARCHAR(250));

--Creazione tabella Corsi
CREATE TABLE Corsi(	IDCorso INT PRIMARY KEY, 
					Titolo NVARCHAR(100) NOT NULL,
					IdInsegnante INT,
					Costo DECIMAL (18,2),
					Durata INT ,
					DataCaricamento Date,
					IdTipologia INT NOT NULL,
					Foreign key (IDInsegnante) references Insegnanti (IdInsegnante),
					Foreign key (IdTipologia) references TipologieCorsi (IdTipologia)
					);

--Creazione tabella Acquisti
CREATE TABLE Acquisti(	IdAcquisto INT PRIMARY KEY, 
						IdUtenteAcquisto INT NOT NULL,
						PagamentoTotale decimal (18,2) NOT NULL,
						Extra decimal (18,2),
						Data Date NOT NULL,
						Foreign key (IdUtenteAcquisto) references Utenti (IdUtente),
						);


--Creazione tabella CarrelliAcquisti
CREATE TABLE CarrelliAcquisti(	IdCarrello INT PRIMARY KEY, 
								IdAcquisto INT NOT NULL,
								IdCorsoAcquistato INT NOT NULL,
								Foreign key (IdAcquisto) references Acquisti (IdAcquisto),
								Foreign key (IdCorsoAcquistato) references Corsi (IdCorso),
								UNIQUE (IdAcquisto, IdCorsoAcquistato)
								);


--Creazione tabella RecensioniCorsi
CREATE TABLE RecensioniCorsi(	IdRecensione INT PRIMARY KEY, 
								IdCorso INT NOT NULL,
								IdAcquisto INT NOT NULL,
								Voto INT NOT NULL,
								DataRecensione Date NOT NULL,
								Foreign key (IdCorso) references Corsi (IdCorso),
								Foreign key (IdAcquisto) references Acquisti (IdAcquisto)								
								);

--Creazione tabella di quanto pagare ad ogni insegnante per ogni carrello acquistato 
CREATE TABLE PagamentiInsegnantiCorsi (IdPagamentoInsegnante INT PRIMARY KEY, 
									IdInsegnantePagato INT NOT NULL,
									IdCarrelloAcquisti INT NOT NULL,									
									Importo Decimal(18,2) NOT NULL,								
									Data Date NOT NULL,
									Foreign key (IdInsegnantePagato) references Insegnanti (IdInsegnante),
									Foreign key (IdCarrelloAcquisti) references CarrelliAcquisti (IdCarrello)								
								);

--Creazione tabella del totale pagato periodico
CREATE TABLE PagamentiInsegnanti (	IdTotalePeriodico INT PRIMARY KEY, 
									IdInsegnante INT NOT NULL,									
									Totale Decimal(18,2) NOT NULL,								
									DataDal Date NOT NULL,
									DataAl Date NOT NULL,
									Foreign key (IdInsegnante) references Insegnanti (IdInsegnante),
									);


