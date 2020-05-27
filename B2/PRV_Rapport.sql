/*
Jag har b�rjat titta p� vilka rapporter jag skulle beh�va f�r att kunna redovisa till PRV enligt det nya CRM direktivet. Det kommer s�kert fler men just nu har jag 3 rapporter som jag skulle beh�va.
-	All ers�ttning som har f�rdelats p� upphovspersoner men inte utbetalats, en totalsumma 
-	Totalt utbetalat belopp innan v�ra avdrag och per ers�ttningsslag
-	Allt som �r inbetalat men �nnu ej utbetalat per �r och ers�ttningsslag
Vi kan prata om dessa imorgon n�r du kommer JC om du har fr�gor och sen vore det toppen om jag kunde f� ett kostnadsf�rslag p� det.

Vi pratade om hur m�nga �r tillbaka vi m�ste kunna g�, 2017 �r utg�ngs�ret vi beh�ver inte g� l�ngre tillbaka och det vill vi kunna n� alla �r fram�ver.
Vi utg�r fr�n datumen i B2 n�r det g�ller TV och KR dvs f�rdelningsdatumet.
*/
use b2
select top 100 * -- BEtalning_typ,Betalning_underlag_ID, betalning_underlag_belopp,bu_betalt,bu_Kvarvarande,[Registrerat datum] 
from v_betalning_underlag_sum_betalt where belopp=Sum_betalt

create 
--alter 
procedure sp_PRV_rapport @Per int as
SELECT 'Innest�ende i �r' RUBRIK,@per �R,'ALLA' betalning_typ, sum(bu.belopp- ISNULL(bgs.Betalt, 0)) AS Belopp
FROM  dbo.betalning_underlag AS bu 
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godk�nd AS bg 
			where datepart(yyyy,bg.skapad)<=@per
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
where datepart(yyyy,bu.betalningsdatum)<=@per
union
SELECT 'Innest�ende per �r' RUBRIK,datepart(yyyy,bu.betalningsdatum) �R, bt.namn betalning_typ, sum(bu.belopp- ISNULL(bgs.Betalt, 0)) AS sum_ej_betalt
FROM  dbo.betalning_underlag AS bu 
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godk�nd AS bg 
			where datepart(yyyy,bg.skapad)<=@per
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
join  (select kort_namn,case 
	when t.kort_namn like 'IV%' then  'Individuell Visningsers�ttning' 
	when t.kort_namn like 'TVCOPY%' then  'Copyswede' 
	when t.kort_namn like 'TV%' then  'Television' 
	when t.kort_namn like 'IR%' then  'Individuell Reprografiers�ttning' 
	when t.kort_namn like 'PRESKRIBERAT' then  'Preskriberade medel' 
	when t.kort_namn like 'F�LJER�T%' then  'F�ljer�tt' 
	else 'Reproduktion av Verk'  end namn
 from betalning_typ t
) bt on bu.betalning_typ=bt.kort_namn
where datepart(yyyy,bu.betalningsdatum)<=@per
GROUP BY datepart(yyyy,bu.betalningsdatum),bt.namn


union
SELECT 'Utbetalt i �r' RUBRIK,@per,bt.namn, sum(ISNULL(bgs.Betalt, 0)) AS Betalt
FROM  dbo.betalning_underlag AS bu 
join (select kort_namn,case 
	when t.kort_namn like 'IV%' then  'Individuell Visningsers�ttning' 
	when t.kort_namn like 'TVCOPY%' then  'Copyswede' 
	when t.kort_namn like 'TV%' then  'Television' 
	when t.kort_namn like 'IR%' then  'Individuell Reprografiers�ttning' 
	when t.kort_namn like 'PRESKRIBERAT' then  'Preskriberade medel' 
	when t.kort_namn like 'F�LJER�T%' then  'F�ljer�tt' 
	else 'Reproduktion av Verk'  end namn
 from betalning_typ t
) bt on bu.betalning_typ=bt.kort_namn
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godk�nd AS bg 
			where datepart(yyyy,bg.skapad)=@per
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
where datepart(yyyy,bu.betalningsdatum)<=@per
group by bt.namn


order by RUBRIK,�R desc,betalning_typ

GO
sp_PRV_Rapport 2017


select * from betalning_typ


SELECT datepart(yyyy,bu.betalningsdatum) �R, betalning_typ, sum(ISNULL(bgs.Betalt, 0)) AS sum_betalt
FROM  dbo.betalning_underlag AS bu 
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godk�nd AS bg
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
where datepart(yyyy,bu.betalningsdatum)>=2015
GROUP BY datepart(yyyy,bg.),bu.betalning_typ
order by datepart(yyyy,bu.betalningsdatum) 
,betalning_typ



go









 SELECT 'Innest�ende per �r' RUBRIK,datepart(yyyy,bu.betalningsdatum) �R, bt.namn betalning_typ, sum(bu.belopp- ISNULL(bgs.Betalt, 0)) AS sum_ej_betalt
FROM  dbo.betalning_underlag AS bu 
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godk�nd AS bg 
			where datepart(yyyy,bg.skapad)<=2017
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
join (select kort_namn,case 
	when t.kort_namn like 'IV%' then  'Individuell Visningsers�ttning' 
	when t.kort_namn like 'TVCOPY%' then  'Copyswede' 
	when t.kort_namn like 'TV%' then  'Television' 
	when t.kort_namn like 'IR%' then  'Individuell Reprografiers�ttning' 
	when t.kort_namn like 'PRESKRIBERAT' then  'Preskriberade medel' 
	when t.kort_namn like 'F�LJER�T%' then  'F�ljer�tt' 
	else 'Reproduktion av Verk'  end namn
 from betalning_typ t
) bt on bu.betalning_typ=bt.kort_namn
where datepart(yyyy,bu.betalningsdatum)<=2017
GROUP BY datepart(yyyy,bu.betalningsdatum),bt.namn



select * from betalning_typ


--TVCOPY -> Copy Swede
--IR*- Individuell Reprografiers�ttning
--KR*,ST*,Repro -> Repro
--TV*-> Televisioon
--IV*-> IV
--F�ljer�tt -> F�ljer�'tt



select *--,'Utbetalt i �r' RUBRIK,2017,'UTBETALT',SUM(bp.brutto) belopp 
from  betalning_post bp join  betalning_transaktion bt on bp.betalning_transaktion_id=bt.id

where datepart(yyyy,bt.transaktion_dag)=2017 and bt.status='CLOSED'
--Utbetalt i �r	2017	UTBETALT	77309515,0581

SELECT 'BEtalt i �r' RUBRIK,2017 �R,bt.namn, sum(ISNULL(bgs.Betalt, 0)) AS Betalt
FROM  dbo.betalning_underlag AS bu 
join (select kort_namn,case 
	when t.kort_namn like 'IV%' then  'Individuell Visningsers�ttning' 
	when t.kort_namn like 'TVCOPY%' then  'Copyswede' 
	when t.kort_namn like 'TV%' then  'Television' 
	when t.kort_namn like 'IR%' then  'Individuell Reprografiers�ttning' 
	when t.kort_namn like 'PRESKRIBERAT' then  'Preskriberade medel' 
	when t.kort_namn like 'F�LJER�T%' then  'F�ljer�tt' 
	else 'Reproduktion av Verk'  end namn
 from betalning_typ t
) bt on bu.betalning_typ=bt.kort_namn
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godk�nd AS bg 
			where datepart(yyyy,bg.skapad)=2017
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
where datepart(yyyy,bu.betalningsdatum)<=2017
group by bt.namn