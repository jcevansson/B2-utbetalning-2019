--COLLATE SQL_SwedishStd_Pref_CP1_CI
--drop  view v_betalning_summering_BETALD
CREATE view v_betalning_summering_BETALD
as
SELECT 'BETALD' AS status, bg.betalningsmottagare_typ, bg.fördelning, bg.belopp, bg.moms, bg.avdrag, (bg.belopp * (100.0 - bg.avdrag) / 100.0) * (100.0 + bg.moms) 
                  / 100.0 AS calc_belopp_netto, bg.belopp * bg.avdrag / 100.0 AS calc_avdrag, bg.belopp * (100.0 - bg.avdrag) / 100.0 * bg.moms / 100.0 AS calc_moms, 
                  bu.betalning_typ, bu.upphovsman_id, bu.id Betalning_underlag_id, u.Pnr PErsonnummer, u.fnamn Förnamn, u.enamn Efternamn, 
                  bu.betalningsdatum[Registrerat datum], bu.kommentar Betalnings_underlag_kommentar, bp.betalningsmottagare_typ mottagare_typ, 
                  bp.betalningsmottagare_id mottagare_id, bp.efternamn mottagare_efternamn, bp.förnamn mottagare_förnamn, bp.personnummer mottagare_personnummer, 
                  CASE WHEN bp.konto_typ = 'PostGiro' THEN 'PlusGiro' ELSE bp.konto_typ END AS Konto_typ_kortnamn, bg.id betalning_godkänd_id, bp.id betalning_post_id, 
                  bu.belopp betalning_underlag_belopp, bus.sum_betalt bu_Betalt, bu.belopp - bus.sum_betalt bu_Kvarvarande, 100.0 * (1 - bus.sum_betalt / isnull(bu.belopp, 1)) 
                  bu_Kvarvarande_procent, bg.fördelning bg_procent_av_Orginal, bp.adressrad1 + ' ' + bp.Adressrad2 + ' ' + bp.PostNr + ' ' + bp.PostAdress  AS Adress_kommentar, 
                  CASE WHEN rtrim(bp.[konto_typ]) = 'Bankkonto' AND (bp.konto_nummer <> '' AND bp.clearing_nummer <> '') 
                  THEN 'Clearingnr ' + bp.clearing_nummer + ' Kontonr ' + bp.konto_nummer + ' Bank ' + bp.bank + ' ' WHEN (bp.konto_typ = 'PostGiro' OR
                  bp.konto_typ = 'BankGiro' OR
                  bp.konto_typ = 'PlusGiro') AND bp.konto_nummer <> '' THEN 'Kontonr ' + bp.konto_nummer + '  ' ELSE '' END AS Konto_kommentar, 1 KontoOK, 0 DödsboEjKlart, 
                  0 checkable, bp.efternamn + ', ' + bp.förnamn + ' (' + bp.personnummer + ')' Namn_Personnummer_grupp
FROM     betalning_underlag bu JOIN
                  v_betalning_underlag_sum_betalt bus ON bu.id = bus.id JOIN
                  bus.dbo.Upphovsman u ON bu.upphovsman_id = u.nr JOIN
                  betalning_godkänd bg ON bu.id = bg.betalning_underlag_id JOIN
                  betalning_post bp ON bg.betalning_post_id = bp.id

--drop  view v_betalning_summering_OBETALD
create view v_betalning_summering_OBETALD
as
SELECT o.status, o.betalningsmottagare_typ, o.fördelning, o.belopp, o.moms, o.Avdrag, (o.belopp * (100.0 - o.avdrag) / 100.0) * (100.0 + o.moms) 
                  / 100.0 AS calc_belopp_netto, o.belopp * o.avdrag / 100.0 AS calc_avdrag, o.belopp * (100.0 - o.avdrag) / 100.0 * o.moms / 100.0 AS calc_moms, 
                  o.betalning_typ, o.upphovsman_id, o.Betalning_underlag_ID, o.Personnummer, o.Förnamn, o.Efternamn, o.[Registrerat datum], 
                  o.BEtalnings_underlag_kommentar, o.mottagare_typ, o.mottagare_id, o.mottagare_efternamn  mottagare_efternamn, 
                  o.mottagare_förnamn  mottagare_förnamn, o.mottagare_personnummer  mottagare_personnummer, 
                  o.Konto_typ_kortnamn  Konto_typ_kortnamn, o.betalning_godkänd_id, o.Betalning_post_id, o.betalning_underlag_belopp, o.bu_Betalt, 
                  o.bu_Kvarvarande, o.bu_Kvarvarande_procent, o.bg_procent_av_Orginal, o.Adress_kommentar  Adress_kommentar, 
                  o.Konto_kommentar  Konto_kommentar, o.KontoOK, o.DödsboEjKlart, CASE WHEN o.KONTOok = 1 AND o.DödsboEjKlart = 0 AND 
                  o.status = 'OBETALD' THEN 1 ELSE 0 END checkable, 
                  o.Mottagare_Efternamn  + ', ' + o.Mottagare_Förnamn  + ' (' + o.Mottagare_personnummer
                    + ')' COLLATE Finnish_Swedish_CI_AS Namn_Personnummer_grupp
FROM     (SELECT 'OBETALD' AS status, bm.mottagare_typ betalningsmottagare_typ, bm.fördelning, ((bu.belopp - bus.sum_betalt) * bm.fördelning /
                                        ((SELECT SUM(bm2.fördelning)
                                          FROM      v_betalningsmottagare bm2
                                          WHERE   bm2.upphovsman_nr = bu.upphovsman_id AND NOT EXISTS
                                                                (SELECT id
                                                                 FROM      betalning_godkänd bg3
                                                                 WHERE   bg3.betalning_underlag_id = bu.id AND bg3.betalningsmottagare_typ = bm2.mottagare_typ AND 
                                                                                   bg3.betalningsmottagare_id = bm2.mottagare_id)))) belopp, CASE WHEN bm.mottagare_typ = 'S' OR
                                    isnull(bu.BetaltFrånSysterOrg,0) = 1 OR
                                    isnull(bm.U_BosattSE,0) = 0 OR
                                    isnull(l.EU,0) = 0 OR
                                    (bu.betalning_typ != 'Följerätt' AND bm.Hobby != 0) THEN 0.0 ELSE bt.moms END moms, 
                                    CASE WHEN bm.mottagare_typ = 'S' THEN CASE WHEN bu.betalning_typ LIKE 'FÖLJERÄTT' THEN
                                        (SELECT TOP 1 avdragdds
                                         FROM      BUS.DBO.AVDRAG A JOIN
                                                           BUS.DBO.SYSTERORGANISATION S ON S.AVDRAG_NR = A.NR
                                         WHERE   S.NR = bm.mottagare_id) WHEN (bu.betalning_typ LIKE 'REPRO' OR
                                    bu.betalning_typ LIKE 'KR' OR
                                    bu.betalning_typ LIKE 'ST' OR
                                    bu.betalning_typ LIKE 'TV%') THEN
                                        (SELECT TOP 1 avdragrepro
                                         FROM      BUS.DBO.AVDRAG A JOIN
                                                           BUS.DBO.SYSTERORGANISATION S ON S.AVDRAG_NR = A.NR
                                         WHERE   S.NR = bm.mottagare_id) 
                                    ELSE 0.0 END ELSE CASE WHEN isnull(bu.BEtaltFrånSysterOrg,0) = 0 THEN bt.avdrag 
									WHEN isnull(bu.BEtaltFrånSysterOrg,0) = 1 AND 
                                    (bu.betalning_typ LIKE 'REPRO' OR
                                    bu.betalning_typ LIKE 'FÖLJERÄTT') THEN 10.0 ELSE 0.0 END END Avdrag, /*calc*/ bu.betalning_typ, bu.upphovsman_id, bu.id Betalning_underlag_ID, 
                                    bm.upphovsman_personnummer  Personnummer, bm.upphovsman_förnamn  Förnamn, bm.upphovsman_efternamn  Efternamn, 
                                    bu.betalningsdatum[Registrerat datum], bu.kommentar BEtalnings_underlag_kommentar, bm.mottagare_typ, bm.mottagare_id, 
                                    bm.mottagare_efternamn COLLATE Finnish_Swedish_CI_AS MOTTAGARE_EFTERNAMN, bm.mottagare_förnamn COLLATE Finnish_Swedish_CI_AS mottagare_förnamn, bm.mottagare_personnummer COLLATE Finnish_Swedish_CI_AS mottagare_personnummer, 
                                    CASE WHEN b_kt.Kontotyp = 'PostGiro' THEN 'PlusGiro' ELSE b_kt.Kontotyp END COLLATE Finnish_Swedish_CI_AS AS Konto_typ_kortnamn, NULL betalning_godkänd_id, NULL 
                                    Betalning_post_id, bu.belopp betalning_underlag_belopp, bus.sum_betalt bu_Betalt, bu.belopp - bus.sum_betalt bu_Kvarvarande, 
                                    100.0 * (1.0 - bus.sum_betalt / bu.belopp) bu_Kvarvarande_procent, 100.0 * ((bu.belopp - bus.sum_betalt) * bm.fördelning /
                                        ((SELECT SUM(bm2.fördelning)
                                          FROM      v_betalningsmottagare bm2
                                          WHERE   bm2.upphovsman_nr = bu.upphovsman_id AND NOT EXISTS
                                                                (SELECT id
                                                                 FROM      betalning_godkänd bg3
                                                                 WHERE   bg3.betalning_underlag_id = bu.id AND bg3.betalningsmottagare_typ = bm2.mottagare_typ AND 
                                                                                   bg3.betalningsmottagare_id = bm2.mottagare_id)))) / bu.belopp bg_procent_av_Orginal, 
                                    a.Adressrad1 + ' ' + a.Adressrad2 + ' ' + a.PostNr + ' ' + a.PostAdress + ' ' + a.CareOf COLLATE Finnish_Swedish_CI_AS AS Adress_kommentar, CASE WHEN rtrim(b_kt.[Kontotyp]) 
                                    = 'Bankkonto' AND (bs.[kontonr] <> '' AND bs.ClearingsNr <> '') 
                                    THEN 'Clearingnr ' + bs.ClearingsNr + ' Kontonr ' + bs.KontoNr + ' Bank ' + bs.Banknamn + ' ' WHEN (b_kt.[Kontotyp] = 'PostGiro' OR
                                    b_kt.[Kontotyp] = 'BankGiro') AND bs.kontonr <> '' THEN 'Kontonr ' + bs.KontoNr + '  ' ELSE '' END COLLATE Finnish_Swedish_CI_AS AS Konto_kommentar, 
                                    CASE WHEN rtrim(b_kt.[Kontotyp]) = 'Bankkonto' AND (bs.[kontonr] <> '' AND bs.ClearingsNr <> '') THEN 1 WHEN b_kt.[Kontotyp] = 'Avi' AND 
                                    (a.Adressrad1 <> '' OR
                                    a.Adressrad2 <> '') AND (a.PostNr <> '' AND a.PostAdress <> '') THEN 1 WHEN (b_kt.[Kontotyp] = 'PostGiro' OR
                                    b_kt.[Kontotyp] = 'BankGiro') AND bs.kontonr <> '' THEN 1 ELSE 0 END AS KontoOK, CASE WHEN bm.mottagare_typ = 'U' AND EXISTS
                                        (SELECT UK.Upphovsman_Nr
                                         FROM      bus.dbo.UpphovsmanKategori uk
                                         WHERE   uk.Kategori_Nr = 7 AND UK.Upphovsman_Nr = bm.mottagare_id) THEN 1 WHEN bm.mottagare_typ = 'R' AND EXISTS
                                        (SELECT nr
                                         FROM      bus.dbo.Rattighetshavare
                                         WHERE   isnull(avlidendatum, '1900-01-01') > '1901-01-01' AND nr = bm.mottagare_id) THEN 1 ELSE 0 END AS DödsboEjKlart
                  FROM      v_betalning_underlag_sum_betalt bus JOIN
                                    betalning_underlag bu ON bu.id = bus.id JOIN
                                    v_betalningsmottagare bm ON bu.upphovsman_id = bm.upphovsman_nr LEFT JOIN
                                    betalning_typ bt ON bu.betalning_typ = bt.kort_namn LEFT JOIN
                                    bus.dbo.Adress a ON a.Nr = bm.Adress_Nr LEFT OUTER JOIN
                                    BUS.dbo.Betalningssatt AS bs ON bm.Betalningssatt_Nr = bs.Nr LEFT OUTER JOIN
                                    BUS.dbo.Kontotyp  AS b_kt ON bs.Kontotyp_Nr = b_kt.Nr JOIN
                                    bus.dbo.Lander l ON l.nr = a.land_nr
                  WHERE   NOT EXISTS
                                        (SELECT id
                                         FROM      betalning_godkänd bg3
                                         WHERE   bg3.betalning_underlag_id = bu.id AND bg3.betalningsmottagare_typ = bm.mottagare_typ AND 
                                                           bg3.betalningsmottagare_id = bm.mottagare_id) AND bm.fördelning > 0) o
--drop  view v_betalning_summering_SAKNAS
create view v_betalning_summering_SAKNAS
as

SELECT 'SAKNAS' AS status, 'R' betalningsmottagare_typ, 0 fördelning, bu.belopp - bus.sum_betalt belopp, 0 moms, 0 Avdrag, bu.belopp - bus.sum_betalt AS calc_belopp_netto, 0 
                  AS calc_avdrag, 0 AS calc_moms, bu.betalning_typ, bu.upphovsman_id, bu.id Betalning_underlag_ID, u.pnr Personnummer, u.fnamn Förnamn, 
                  u.enamn Efternamn, bu.betalningsdatum[Registrerat datum], bu.kommentar BEtalnings_underlag_kommentar, 'R' mottagare_typ, NULL mottagare_id, 'Saknas' 
                  mottagare_efternamn, 'Mottagare' mottagare_förnamn, '' mottagare_personnummer, '' Konto_typ_kortnamn, NULL betalning_godkänd_id, NULL 
                  Betalning_post_id, bu.belopp betalning_underlag_belopp, bus.sum_betalt, bu.belopp - bus.sum_betalt bu_Kvarvarande, 
                  100.0 * (1 - bus.sum_betalt / isnull(bu.belopp, 1)) bu_Kvarvarande_procent, 100.0 * (1 - bus.sum_betalt / isnull(bu.belopp, 1)) bg_procent_av_Orginal, 'Saknas adress' 
                  Adress_kommentar, 'Saknas konto' Konto_kommentar, 0 KontoOK, 0 DödsboEjKlart, 0 checkable, 'SAKNAS_MOTTAGARE' Namn_Personnummer_grupp
FROM     betalning_underlag bu JOIN
                  bus.dbo.Upphovsman u ON bu.upphovsman_id = u.nr JOIN
                  v_betalning_underlag_sum_betalt bus ON bu.id = bus.id
WHERE  NOT EXISTS
                      (SELECT *
                       FROM      v_betalningsmottagare bm
                       WHERE   bm.mottagare_id NOT IN
                                             (SELECT bg2.betalningsmottagare_id
                                              FROM      betalning_godkänd bg2
                                              WHERE   bg2.betalning_underlag_id = bu.id AND bg2.fördelning > 0) AND bm.upphovsman_nr = bu.Upphovsman_id AND bm.fördelning > 0)



drop view v_betalning_summering
create view v_betalning_summering
as 

select * from v_betalning_summering_OBETALD u
union 
select * from v_betalning_summering_BETALD b
union 
select * from v_betalning_summering_SAKNAS s


SELECT * from v_betalning_summering 
where( datediff(hh,[Registrerat datum] , '2000-08-13 00:01')<0 and datediff(hh,[Registrerat datum] , '2013-08-27 23:59')>0 and Efternamn like 'Osslund' ); 
SELECT * into #t from v_betalning_summering 
where( datediff(hh,[Registrerat datum] , '2000-08-13 00:01')<0 and datediff(hh,[Registrerat datum] , '2013-08-27 23:59')>0  ); 
select (select sum(t2.CALC_Belopp_NETTO) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] ) T_Belopp,
 (select sum(t2.Belopp) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp]  ) T_Belopp_Brutto,* from #t t 
 where (select sum(t2.Belopp) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] )> 0 order by efternamn,förnamn,[registrerat datum]; drop table #t;

select * from v_betalning_summering where status='SAKNAS'

SELECT * into #s  from v_betalning_summering; select * into #t from #s where( datediff(hh,[Registrerat datum] , '2000-08-13 00:01')<0 and datediff(hh,[Registrerat datum] , '2013-08-27 23:59')>0); select (select sum(t2.CALC_Belopp_NETTO) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] ) T_Belopp, (select sum(t2.Belopp) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp]  ) T_Belopp_Brutto,* from #t t where (select sum(t2.Belopp) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] )> 100 order by efternamn,förnamn,[registrerat datum]; drop table #t; drop table #s



SELECT * into #s  from v_betalning_summering_obetald; select * into #t from #s where( datediff(hh,[Registrerat datum] , '2000-08-13 00:01')<0 and datediff(hh,[Registrerat datum] , '2013-08-27 23:59')>0 and STATUS !='BETALD'  and Efternamn like 'Osslund' ); select (select sum(t2.CALC_Belopp_NETTO) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] ) T_Belopp, (select sum(t2.Belopp) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp]  ) T_Belopp_Brutto,* from #t t where (select sum(t2.Belopp) from #t t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] )> 100 order by efternamn,förnamn,[registrerat datum]; drop table #t; drop table #s





begin transaction
exec sp_betalning_transaktion_summera 378
exec sp_betalning_transaktion_godkänd_add @betalning_underlag_id=468150,  @betalningsmottagare_id=2338,  @betalningmottagare_typ=R,  @fördelning_av_orginalsumma=70,  @fördelat_belopp=140,  @avdrag=20,  @moms=-6.25, @betalning_transaktion_id=378
exec sp_betalning_transaktion_godkänd_add @betalning_underlag_id=469079,  @betalningsmottagare_id=2338,  @betalningmottagare_typ=R,  @fördelning_av_orginalsumma=70,  @fördelat_belopp=87.5,  @avdrag=20,  @moms=-6.25, @betalning_transaktion_id=378
exec sp_betalning_transaktion_godkänd_add @betalning_underlag_id=469555,  @betalningsmottagare_id=2338,  @betalningmottagare_typ=R,  @fördelning_av_orginalsumma=70,  @fördelat_belopp=105,  @avdrag=20,  @moms=-6.25, @betalning_transaktion_id=378
exec sp_betalning_transaktion_summera 378
commit transaction
rollback
select * from betalning_post where betalning_transaktion_id=378


select * from v_betalningsmottagare_konto_adress bm where bm.mottagare_id=884 and bm.mottagare_typ='R'
select * from v_betalning_summering s where s.betalningsmottagare_typ='R' and s.mottagare_id=884

select * from v_betalning_summering s where s.Betalning_underlag_ID=473519
select * from v_betalning_underlag bu join betalning_godkänd bg on bu.id=bg.betalning_underlag_id
where bu.id=468150

