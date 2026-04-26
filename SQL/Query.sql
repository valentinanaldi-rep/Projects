use Progetto_finale;

--1) Durata media di un corso
select avg(durata) as DurataMediaCorsiMin from corsi;

--2) Costo medio di un corso;
select avg(Costo) as CostoMedioCorsi from Corsi;

--3)Durata del corso più venduto
select TOP 1 with ties IdCorsoAcquistato, durata,  count(*) as ConteggioNumeroAcquisti
from CarrelliAcquisti as ca
INNER JOIN CORSI as c
ON ca.IdCorsoAcquistato=c.IDCorso
group by IdCorsoAcquistato, durata
order by ConteggioNumeroAcquisti desc

--4)tipo di corso che costa di più
select c.Titolo as NomeCorso, tc.Nome as NomeTipologia, c.costo
from Corsi as c, TipologieCorsi as tc
where c.IdTipologia= tc.IDTipologia
and c.costo in (select Max(costo) as CostoMax
				from Corsi )


--5)tipo del corso che costa di meno
select c.Titolo as NomeCorso, tc.Nome as NomeTipologia, c.costo
from Corsi as c, TipologieCorsi as tc
where c.IdTipologia= tc.IDTipologia
and c.costo in (select Min(costo) as CostoMax
				from Corsi )

--6)quanti corsi sono di tipo “informatica”
select tc.Nome, count(c.IDCorso) as NumeroCorsi
from Corsi as c, TipologieCorsi as tc
where c.IdTipologia= tc.IDTipologia and tc.Nome='informatica'
group by tc.Nome;

--7) quanti acquisti ha fatto “mario rossi” a febbraio
select * from Acquisti;

select u.Username, u.strPassword,  count(a.IdAcquisto) as NumeroAcquisti
from Acquisti as a
inner join Utenti as u
on a.IdUtenteAcquisto=u.IDUtente
where u.Username='Mario' and u.strPassword='Rossi'
group by u.Username, u.strPassword;

--8)quanti corsi ha venduto michele gialli a marzo 2022
select count(ca.IdCorsoAcquistato) as numeroCorsiAcquistatiUtente
from carrelliacquisti as ca
inner join acquisti as a
on ca.IdAcquisto=a.IdAcquisto
inner join corsi as c
on ca.IdCorsoAcquistato=c.IDCorso
inner join insegnanti as i
on c.IdInsegnante=i.IDInsegnante
where i.Username='Michele' and i.strPassword='Gialli' and YEAR(a.Data)=2022 and Month(a.Data)=3;

select * from carrelliacquisti;
select * from acquisti;
select * from corsi;
select * from insegnanti;

--9)Il corso con il voto di recensioni più alto
select TOP 1 WITH TIES c.Titolo, max(Voto) as MaxVoto 
from RecensioniCorsi as r, corsi as c
where r.IdCorso=c.IDCorso
group by c.Titolo
order by MaxVoto desc;

--10)la media dei voti per tutti i corsi in base alle recensioni registrate
select avg(voto) as VotoMedioRecensioni
from RecensioniCorsi;

--11)quanto ha guadagnato giuseppe gialli fino ad oggi
select * from PagamentiInsegnantiCorsi;
select * from insegnanti;

select sum(Importo) as Guadagno
from PagamentiInsegnantiCorsi as pic
inner join insegnanti as i
on pic.IdInsegnantePagato=i.IDInsegnante
where i.Username='Giuseppe' and i.strPassword='Gialli';

--12) quanto ha guadagnato giuseppe gialli fino a febbraio
select sum(Importo) as Guadagno
from PagamentiInsegnantiCorsi as pic
inner join insegnanti as i
on pic.IdInsegnantePagato=i.IDInsegnante
where i.Username='Giuseppe' and i.strPassword='Gialli' and YEAR(pic.Data)<=2022 and MONTH(pic.Data)<=2;

--13)il totale da pagare a Febbraio considerando una fee da trattenere del 10%
select sum(Importo)*0.90 as Guadagno
from PagamentiInsegnantiCorsi 
where YEAR(Data)=2022 and MONTH(Data)=2;

--14)il valore medio degli extra pagati dagli utenti per ogni corso
select c.Titolo, avg(a.Extra) as mediaExtra_corso
from Acquisti as a
inner join CarrelliAcquisti as ca
on a.IdAcquisto=ca.IdAcquisto
inner join corsi as c
on c.IDCorso=ca.IdCorsoAcquistato
group by c.Titolo


--15)il corso con l’extra più pagato
select TOP 1 with ties c.Titolo, a.Extra
from Acquisti as a
inner join CarrelliAcquisti as ca
on a.IdAcquisto=ca.IdAcquisto
inner join corsi as c
on c.IDCorso=ca.IdCorsoAcquistato
order by a.extra desc;

--16)quanti corsi di tipo tutorial ha inserito giuseppe gialli
select count(*) as NumeroCorsi
from corsi as c
inner join TipologieCorsi as TC
on tc.IDTipologia=c.IdTipologia
inner join insegnanti as i
on i.IDInsegnante=c.IdInsegnante
where i.Username='Giuseppe' and i.strPassword='Gialli';

--17)i nomi degli insegnanti che hanno di cognome “gialli”
select Username 
from insegnanti
where strPassword='Gialli';

--18)i nomi dei corsi che hanno una tipologia con una parola chiave “attrezzi”
select c.Titolo, tc.Nome, tc.ParoleChiave
from corsi as c
inner join tipologieCorsi as tc
on c.IdTipologia=tc.IDTipologia
where tc.ParoleChiave like '%attrezzi%';

--19 calcola la media dei voti ricevuti per i corsi di ciascun insegnante, ordinati
--in modo decrescente per la media dei voti e includendo solo gli insegnanti
--con una media dei voti superiore a 6
select i.Username, avg(rc.voto) as mediaVotiInsegnante
from recensionicorsi as rc
inner join corsi as c
on rc.IdCorso=c.IDCorso
inner join insegnanti as i
on c.IdInsegnante=i.IDInsegnante
group by i.Username
having avg(rc.voto)>6
order by mediaVotiInsegnante desc;

--20)le tipologie di corsi con almeno 3 corsi disponibili nel database, ordinati per numero di corsi in modo decrescente.
select tc.Nome, count(c.Titolo) as NumeroCorsiTipologia
from tipologieCorsi as tc
inner join corsi as c
on tc.IDTipologia=c.IdTipologia
group by tc.Nome
having count(c.Titolo)>=3
order by NumeroCorsiTipologia desc;

--21)gli utenti che hanno acquistato almeno 4 corsi, ordinati per totale speso in modo decrescente.
select u.Username, count(ca.idCorsoAcquistato) as NumeroCorsi, sum(a.PagamentoTotale) as TotalePagato
from utenti as u
inner join acquisti as a
on u.IDUtente=a.IdUtenteAcquisto
inner join CarrelliAcquisti as ca
on ca.IdAcquisto=a.IdAcquisto
group by u.Username
having count(ca.idCorsoAcquistato)>=4
order by TotalePagato desc

--BONUS A:
--I pagamenti rimanenti da fare a Febbraio rispetto a quanto è stato venduto per gli insegnanti
select * from PagamentiInsegnantiCorsi;
select * from acquisti;

with CTE AS (select c.IdInsegnante, sum(c.Costo)*0.90 as GuadagnoInsegnante
			from acquisti as a
			inner join CarrelliAcquisti as ca
			on ca.IdAcquisto=a.IdAcquisto
			inner join corsi as c
			on c.IDCorso=ca.IdCorsoAcquistato
			where a.Data<'2022-03-01'
			group by c.IdInsegnante)
select i.Username, (c.GuadagnoInsegnante-COALESCE(p.Importo,0)) as Rimanente
from CTE as c
left join PagamentiInsegnantiCorsi as p
on p.IdInsegnantePagato=c.IdInsegnante
inner join insegnanti as I
on i.IDInsegnante=c.IdInsegnante;


--BONUS B: Cancellare l’acquisto id = 1, che succede?
delete acquisti 
where IdAcquisto=1;
--il Default è NO ACTION on delete pertanto la cancellazione non viene esguita perchè viola l'integrità referenziale con la tabella CarrelliAcquisti

--BONUS C: calcolare il totale delle durate dei corsi acquistati a Febbraio da Mario Rossi
select SUM(c.Durata) as TotaleDurataCorsi 
from acquisti as a
inner join CarrelliAcquisti as ca
on ca.IdAcquisto=a.IdAcquisto
inner join corsi as c
on c.IDCorso=ca.IdCorsoAcquistato
inner join utenti as u
on u.IDUtente=a.IdUtenteAcquisto
where u.Username='Mario' and  u.strPassword='Rossi' and MONTH(a.Data)=2

--d) titoli dei corsi che non sono mai stati acquistati da nessuno
select c.Titolo
from corsi as c
left join CarrelliAcquisti as ca
on c.IDCorso=ca.IdCorsoAcquistato
where ca.IdAcquisto IS NULL;
