use b2

SET STATISTICS XML ON 
SELECT * ,  Mottagare_Efternamn+', '+Mottagare_Förnamn+' ('+Mottagare_personnummer+')' Mottagar_grupp 
from v_betalning_transaktion_post  
where  datediff(hh,[utbetalning_transaktion_skapad] , '2014-05-10 00:01')<0 
and datediff(hh,[utbetalning_transaktion_skapad] , '2017-05-24 23:59')>0 
and BU_Upphovsman_Efternamn like 'N%'  and BU_Upphovsman_Förnamn like 'Tor%'  
and Status='Closed'order by mottagare_efternamn,mottagare_förnamn,bu_upphovsman_efternamn,bu_upphovsman_förnamn,utbetalning_transaktion_skapad 


--select * from bus.dbo.Upphovsman where enamn like 'N%'  and fnamn like 'Tore%' 
/*
USE BUS;
GO
IF EXISTS (SELECT name FROM sys.indexes
           WHERE name = N'IX_Upphovsman_enamn_fnamn')
     DROP INDEX IX_Upphovsman_enamn_fnamn ON Upphovman;
GO
CREATE NONCLUSTERED INDEX IX_Upphovsman_enamn_fnamn
     ON Upphovsman (Enamn,Fnamn)
     INCLUDE (PNR, NR);
GO
USE BUS;
GO
IF EXISTS (SELECT name FROM sys.indexes
           WHERE name = N'IX_Upphovsman_fnamn')
     DROP INDEX IX_Upphovsman_fnamn ON Upphovman;
GO
CREATE NONCLUSTERED INDEX IX_Upphovsman_fnamn
     ON Upphovsman (Fnamn)
     INCLUDE (PNR, NR);
GO




*/

alter view v_betalning_transaktion_post as
SELECT        bt.id AS bt_id, bp.id AS bp_id, bg.id AS bg_id, bu.id AS bu_id, bt.status, bt.fil_löpnummer AS bt_fil_löpnummer, bts.brutto_calc AS bt_brutto_calc, bts.netto_calc AS bt_netto_calc, bts.moms_calc AS bt_moms_calc, 
                         bts.avdrag_calc AS bt_avdrag_calc, bts.Öresavrundning_calc AS bt_Öresavrundning_calc, bt.transaktion_dag, bt.transaktion_typ, bt.fil_namn, bt.skapad AS utbetalning_transaktion_skapad, bp.brutto AS bp_brutto, 
                         bp.netto AS bp_netto, bp.avdrag AS bp_avdrag, bp.moms AS bp_moms, bp.konto_typ AS bp_konto_typ, bp.efternamn AS mottagare_efternamn, bp.förnamn AS mottagare_förnamn, bp.personnummer AS mottagare_personnummer,
                          bp.betalningsmottagare_typ AS mottagare_typ, 
                         CASE WHEN bp.konto_typ LIKE 'A%' THEN '' WHEN bp.konto_typ LIKE 'P%' THEN bp.konto_nummer WHEN bp.konto_typ = 'BankG%' THEN bp.konto_nummer + '  ' + bp.bank WHEN bp.konto_typ = 'Bankk%' THEN bp.clearing_nummer
                          + '- ' + bp.konto_nummer + '  ' + bp.bank ELSE bp.clearing_nummer + '- ' + bp.konto_nummer + '  ' + bp.bank END AS Konto_kommentar, ISNULL(bp.adressrad1 + ' ' + bp.adressrad2 + ' ' + bp.postnr + ' ' + bp.postadress, N'') 
                         AS Adress_kommentar, bg.fördelning AS bg_fördelning, bg.belopp AS bg_belopp, bg.moms AS bg_moms, bg.avdrag AS bg_avdrag, (bg.belopp * (100.0 + ISNULL(bg.moms, 0.0)) / 100.0) * (100.0 - ISNULL(bg.avdrag, 0.0)) 
                         / 100.0 AS bg_netto_calc, (bg.belopp * ISNULL(bg.moms, 0.0) / 100.0) * (100.0 - ISNULL(bg.avdrag, 0.0)) / 100.0 AS bg_moms_calc, bg.belopp * ISNULL(bg.avdrag, 0.0) / 100.0 AS bg_avdrag_calc, bu.betalning_typ, 
                         bu.kommentar AS betalning_underlag_kommentar, bu.Personnummer AS BU_Upphovsman_personnummer, bu.efternamn AS BU_upphovsman_efternamn, bu.förnamn AS BU_upphovsman_förnamn, bu.belopp AS BU_Belopp, 
                         bp.clearing_nummer, bp.konto_nummer, bp.bank, bp.adressrad1, bp.adressrad2, bp.postnr, bp.postadress, bp.betalningsmottagare_typ, bp.Öresavrundning
FROM            dbo.betalning_transaktion AS bt INNER JOIN
                         dbo.betalning_post AS bp ON bp.betalning_transaktion_id = bt.id left JOIN
                         dbo.v_betalning_transaktion_summor AS bts ON bt.id = bts.id INNER JOIN
                         dbo.betalning_godkänd AS bg ON bg.betalning_post_id = bp.id INNER JOIN
                         dbo.v_betalning_underlag AS bu ON bu.id = bg.betalning_underlag_id





SELECT * into #s  from v_betalning_summering_obetald; 
select * into #t from #s 
where( datediff(hh,[Registrerat datum] , '2014-05-10 00:01')<0 and datediff(hh,[Registrerat datum] , '2017-05-24 23:59')>0 
and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  
and Efternamn like 'N%'  and Förnamn like 'Tore%'  
and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%') );
 select (select sum(t2.CALC_Belopp_NETTO) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] ) T_Belopp, 
 (select sum(t2.Belopp) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp]  ) T_Belopp_Brutto,
 * 
from #t t 
where (select sum(t2.CALC_Belopp_NETTO) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] )> 100 
order by efternamn,förnamn,[registrerat datum]; drop table #t; drop table #s

