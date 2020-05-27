/*
Jag har börjat titta på vilka rapporter jag skulle behöva för att kunna redovisa till PRV enligt det nya CRM direktivet. Det kommer säkert fler men just nu har jag 3 rapporter som jag skulle behöva.
-	All ersättning som har fördelats på upphovspersoner men inte utbetalats, en totalsumma 
-	Totalt utbetalat belopp innan våra avdrag och per ersättningsslag
-	Allt som är inbetalat men ännu ej utbetalat per år och ersättningsslag
Vi kan prata om dessa imorgon när du kommer JC om du har frågor och sen vore det toppen om jag kunde få ett kostnadsförslag på det.

Vi pratade om hur många år tillbaka vi måste kunna gå, 2017 är utgångsåret vi behöver inte gå längre tillbaka och det vill vi kunna nå alla år framöver.
Vi utgår från datumen i B2 när det gäller TV och KR dvs fördelningsdatumet.
*/
use b2
select top 100 * -- BEtalning_typ,Betalning_underlag_ID, betalning_underlag_belopp,bu_betalt,bu_Kvarvarande,[Registrerat datum] 
from v_betalning_underlag_sum_betalt where belopp=Sum_betalt

create 
--alter 
procedure sp_PRV_rapport @Per int as
SELECT 'Innestående i år' RUBRIK,@per ÅR,'ALLA' betalning_typ, sum(bu.belopp- ISNULL(bgs.Betalt, 0)) AS Belopp
FROM  dbo.betalning_underlag AS bu 
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godkänd AS bg 
			where datepart(yyyy,bg.skapad)<=@per
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
where datepart(yyyy,bu.betalningsdatum)<=@per
union
SELECT 'Innestående per år' RUBRIK,datepart(yyyy,bu.betalningsdatum) ÅR, bt.namn betalning_typ, sum(bu.belopp- ISNULL(bgs.Betalt, 0)) AS sum_ej_betalt
FROM  dbo.betalning_underlag AS bu 
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godkänd AS bg 
			where datepart(yyyy,bg.skapad)<=@per
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
join  (select kort_namn,case 
	when t.kort_namn like 'IV%' then  'Individuell Visningsersättning' 
	when t.kort_namn like 'TVCOPY%' then  'Copyswede' 
	when t.kort_namn like 'TV%' then  'Television' 
	when t.kort_namn like 'IR%' then  'Individuell Reprografiersättning' 
	when t.kort_namn like 'PRESKRIBERAT' then  'Preskriberade medel' 
	when t.kort_namn like 'FÖLJERÄT%' then  'Följerätt' 
	else 'Reproduktion av Verk'  end namn
 from betalning_typ t
) bt on bu.betalning_typ=bt.kort_namn
where datepart(yyyy,bu.betalningsdatum)<=@per
GROUP BY datepart(yyyy,bu.betalningsdatum),bt.namn


union
SELECT 'Utbetalt i år' RUBRIK,@per,bt.namn, sum(ISNULL(bgs.Betalt, 0)) AS Betalt
FROM  dbo.betalning_underlag AS bu 
join (select kort_namn,case 
	when t.kort_namn like 'IV%' then  'Individuell Visningsersättning' 
	when t.kort_namn like 'TVCOPY%' then  'Copyswede' 
	when t.kort_namn like 'TV%' then  'Television' 
	when t.kort_namn like 'IR%' then  'Individuell Reprografiersättning' 
	when t.kort_namn like 'PRESKRIBERAT' then  'Preskriberade medel' 
	when t.kort_namn like 'FÖLJERÄT%' then  'Följerätt' 
	else 'Reproduktion av Verk'  end namn
 from betalning_typ t
) bt on bu.betalning_typ=bt.kort_namn
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godkänd AS bg 
			where datepart(yyyy,bg.skapad)=@per
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
where datepart(yyyy,bu.betalningsdatum)<=@per
group by bt.namn


order by RUBRIK,ÅR desc,betalning_typ

GO
sp_PRV_Rapport 2017


select * from betalning_typ


SELECT datepart(yyyy,bu.betalningsdatum) ÅR, betalning_typ, sum(ISNULL(bgs.Betalt, 0)) AS sum_betalt
FROM  dbo.betalning_underlag AS bu 
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godkänd AS bg
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
where datepart(yyyy,bu.betalningsdatum)>=2015
GROUP BY datepart(yyyy,bg.),bu.betalning_typ
order by datepart(yyyy,bu.betalningsdatum) 
,betalning_typ



go









 SELECT 'Innestående per år' RUBRIK,datepart(yyyy,bu.betalningsdatum) ÅR, bt.namn betalning_typ, sum(bu.belopp- ISNULL(bgs.Betalt, 0)) AS sum_ej_betalt
FROM  dbo.betalning_underlag AS bu 
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godkänd AS bg 
			where datepart(yyyy,bg.skapad)<=2017
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
join (select kort_namn,case 
	when t.kort_namn like 'IV%' then  'Individuell Visningsersättning' 
	when t.kort_namn like 'TVCOPY%' then  'Copyswede' 
	when t.kort_namn like 'TV%' then  'Television' 
	when t.kort_namn like 'IR%' then  'Individuell Reprografiersättning' 
	when t.kort_namn like 'PRESKRIBERAT' then  'Preskriberade medel' 
	when t.kort_namn like 'FÖLJERÄT%' then  'Följerätt' 
	else 'Reproduktion av Verk'  end namn
 from betalning_typ t
) bt on bu.betalning_typ=bt.kort_namn
where datepart(yyyy,bu.betalningsdatum)<=2017
GROUP BY datepart(yyyy,bu.betalningsdatum),bt.namn



select * from betalning_typ


--TVCOPY -> Copy Swede
--IR*- Individuell Reprografiersättning
--KR*,ST*,Repro -> Repro
--TV*-> Televisioon
--IV*-> IV
--Följerätt -> Fäljerä'tt



select *--,'Utbetalt i år' RUBRIK,2017,'UTBETALT',SUM(bp.brutto) belopp 
from  betalning_post bp join  betalning_transaktion bt on bp.betalning_transaktion_id=bt.id

where datepart(yyyy,bt.transaktion_dag)=2017 and bt.status='CLOSED'
--Utbetalt i år	2017	UTBETALT	77309515,0581

SELECT 'BEtalt i år' RUBRIK,2017 ÅR,bt.namn, sum(ISNULL(bgs.Betalt, 0)) AS Betalt
FROM  dbo.betalning_underlag AS bu 
join (select kort_namn,case 
	when t.kort_namn like 'IV%' then  'Individuell Visningsersättning' 
	when t.kort_namn like 'TVCOPY%' then  'Copyswede' 
	when t.kort_namn like 'TV%' then  'Television' 
	when t.kort_namn like 'IR%' then  'Individuell Reprografiersättning' 
	when t.kort_namn like 'PRESKRIBERAT' then  'Preskriberade medel' 
	when t.kort_namn like 'FÖLJERÄT%' then  'Följerätt' 
	else 'Reproduktion av Verk'  end namn
 from betalning_typ t
) bt on bu.betalning_typ=bt.kort_namn
LEFT  JOIN (select bg.BEtalning_underlag_id,SUM(ISNULL(bg.belopp, 0)) Betalt 
			from dbo.betalning_godkänd AS bg 
			where datepart(yyyy,bg.skapad)=2017
			group by BEtalning_underlag_id ) bgs ON bu.id = bgs.betalning_underlag_id
where datepart(yyyy,bu.betalningsdatum)<=2017
group by bt.namn