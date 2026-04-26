USE Progetto_finale;

INSERT INTO Utenti (IDUtente, Username,strPassword,DataNascita)
VALUES	(1, 'Mario', 'Rossi', '1980-01-01'), 
		(2, 'Luigi', 'Russi', '1965-03-22');

INSERT INTO Insegnanti (IdInsegnante, Username,strPassword,DataNascita)
VALUES	(1, 'Giuseppe', 'Gialli', '1980-01-01'), 
		(2, 'Franco', 'Neri', '1965-03-22'),
		(3,'Michele','Gialli','1990-09-30');

INSERT INTO TipologieCorsi (IDTipologia, Nome,ParoleChiave)
VALUES	(1,'Domestici','casa, bambini, pulizia'),
		(2, 'informatica','Tecologia, sql, programmazione, matematica'),
		(3,'fai da te','attrezzi, risultati, casa'),
		(4,'Tutorial', 'tecnologia, casa, attrezzi');



INSERT INTO Corsi (IDCorso, Titolo,IdInsegnante,Costo ,Durata,DataCaricamento,IdTipologia)
VALUES		(1, 'Corso di cucito', 1, 5, 100, '2021-03-23', 1),
			(2, 'C++', 2, 10, 50, '2021-04-03', 2),
			(3, 'Giardinaggio', 1, 10, 100, '2021-08-15', 3),
			(4, 'Corso di pattinaggio', 3, 10, 200, '2021-03-05', 4),
			(5, 'Corso sui corsi online', 1, 50, 500, '2021-06-25', 4),
			(6, 'Corso su basi di dati', 2, 150, 1000, '2021-01-01', 2),
			(7, 'Corso di sopravvivenza', 1, 20, 500, '2021-01-01', 4),
			(8, 'Corso di buone maniere', 3, 10, 200, '2021-01-01', 4);

INSERT INTO Acquisti(IdAcquisto ,IdUtenteAcquisto,PagamentoTotale ,Extra ,Data)
VALUES	(1,1,65,0,'2022-01-15'),
		(2,2,150,10,'2022-01-26'),
		(3,1,20,2,'2022-02-26'),
		(4,2,20,1,'2022-03-01'),
		(5,2,20,0,'2022-03-02');

INSERT INTO CarrelliAcquisti(	IdCarrello, IdAcquisto ,IdCorsoAcquistato)
VALUES (1,1,1), (2,1,5), (3,1,8), (4,2,6),(5,3,7),(6,4,8),(7,5,7);



INSERT INTO RecensioniCorsi(IdRecensione, IdCorso,IdAcquisto, Voto,DataRecensione)
VALUES	(1,1,1,5,'2022-01-17'),
		(2,5,1,7, '2022-02-20'),
		(3,6,2,7,'2022-02-27'),
		(4,8,1,9,'2022-03-05'),
		(5,7,3,3,'2022-03-07');

INSERT INTO PagamentiInsegnantiCorsi (	IdPagamentoInsegnante, IdInsegnantePagato,IdCarrelloAcquisti,Importo,Data)
VALUES	(1,1,1,50,'2022-02-02'),
		(2,3,1,9, '2022-02-02');

INSERT INTO PagamentiInsegnanti (IdTotalePeriodico, IdInsegnante,Totale,DataDal,DataAl)
VALUES	(1,1,50,'2022-01-15','2022-02-26'),
		(2,3,9, '2022-01-26', '2022-03-02');



