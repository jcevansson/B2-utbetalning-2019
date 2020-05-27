--Defaultv�rden 100 belopp

drop table #t
SELECT * into #s from v_betalning_summering  
select * into #t from #s where datediff(hh,[Registrerat datum] , '2010-05-01 00:01')<0 and datediff(hh,[Registrerat datum] , '2013-08-21 23:59')>0 
and kontoOK=1 and D�dsBoEjKlart=0  
and  (Efternamn > 'A' or Efternamn like 'A%') 
and  (Efternamn < '�' or Efternamn like '�%') 
and Efternamn like '%'  and F�rnamn like '%'  --44
and  (MOttagare_Efternamn > 'A' or mottagare_Efternamn = 'A') 
and (Mottagare_Efternamn < '�' or Mottagare_Efternamn like '�%') --47
and Mottagare_Efternamn like '%'  and Mottagare_F�rnamn like '%'  --48
and (mottagare_typ = 'U' or mottagare_typ = 'R' or mottagare_typ = 'O')  
and  (Konto_typ_kortnamn = 'AVI' OR Konto_typ_kortnamn = 'Bankgiro' OR Konto_typ_kortnamn = 'Bankkonto' OR Konto_typ_kortnamn = 'Plusgiro') ; 
--7502 1:46
--

select (select sum(t2.CALC_Belopp_NETTO) 
from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] ) T_Belopp, 
(select sum(t2.Belopp) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp]  ) T_Belopp_Brutto,* 
from #t t where (select sum(t2.Belopp) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] )> 100 
order by efternamn,f�rnamn,[registrerat datum]; drop table #t; drop table #s



select top 10 * from v_betalning_summering





select count(*) from #t 
where  (Efternamn > 'A' or Efternamn like 'A%') 
and  (Efternamn < '�' or Efternamn like '�%') 
and Efternamn like '%'  and F�rnamn like '%'  
and  (MOttagare_Efternamn > 'A' or mottagare_Efternamn = 'A') 
and (Mottagare_Efternamn < '�' or Mottagare_Efternamn like '�%') 
and Mottagare_Efternamn like '%'  and Mottagare_F�rnamn like '%'  
and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  
and  (RTrim(Konto_typ_kortnamn) like 'A%' OR RTrim(Konto_typ_kortnamn) like 'Bankg%' OR RTrim(Konto_typ_kortnamn) like 'Bankk%' OR RTrim(Konto_typ_kortnamn) like 'P%') ; 

select count(*) from #s
where  (Efternamn > 'A' or Efternamn like 'A%') 
and  (Efternamn < '�' or Efternamn like '�%') 
and Efternamn like '%'  and F�rnamn like '%'  
--and  (MOttagare_Efternamn > 'A' or mottagare_Efternamn = 'A') 
--and (Mottagare_Efternamn < '�' or Mottagare_Efternamn like '�%') 
and Mottagare_Efternamn like '%'  and Mottagare_F�rnamn like '%'  
and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  
and  (RTrim(Konto_typ_kortnamn) like 'A%' OR RTrim(Konto_typ_kortnamn) like 'Bankg%' OR RTrim(Konto_typ_kortnamn) like 'Bankk%' OR RTrim(Konto_typ_kortnamn) like 'P%') ; 

select * from #t 
join #s on #t.Betalning_underlag_id=#s.Betalning_underlag_id and #t.mottagare_id=#s.mottagare_id and #t.mottagare_typ=#s.mottagare_typ
where #s.betalning_underlag_id is null