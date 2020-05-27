alter view v_betalning_summering_OBETALD as
SELECT   status, betalningsmottagare_typ, fördelning, belopp, moms, Avdrag, (belopp * (100.0 - Avdrag) / 100.0) * (100.0 + moms) / 100.0 AS calc_belopp_netto, 
                         belopp * Avdrag / 100.0 AS calc_avdrag, belopp * (100.0 - Avdrag) / 100.0 * moms / 100.0 AS calc_moms, betalning_typ, upphovsman_id, Betalning_underlag_ID, Personnummer, 
                         Förnamn, Efternamn, [Registrerat datum], BEtalnings_underlag_kommentar, mottagare_typ, mottagare_id, MOTTAGARE_EFTERNAMN, o.MOTTAGARE_Förnamn, 
                         o.mottagare_personnummer, Konto_typ_kortnamn COLLATE Finnish_Swedish_CI_AS as Konto_typ_kortnamn, betalning_godkänd_id, Betalning_post_id, betalning_underlag_belopp, bu_Betalt, 
                         bu_Kvarvarande, bu_Kvarvarande_procent, bg_procent_av_Orginal, Adress_kommentar, Konto_kommentar COLLATE Finnish_Swedish_CI_AS as Konto_kommentar, KontoOK, DödsboEjKlart, 
                         CASE WHEN o.KONTOok = 1 AND o.DödsboEjKlart = 0 AND o.status = 'OBETALD' THEN 1 ELSE 0 END AS checkable, 
                         MOTTAGARE_EFTERNAMN + ', ' + o.MOTTAGARE_Förnamn + ' (' + o.mottagare_personnummer + ')' AS Namn_Personnummer_grupp
FROM         (SELECT   'OBETALD' AS status, bm.mottagare_typ AS betalningsmottagare_typ, bm.fördelning, (bu.belopp - bus.sum_betalt) * bm.fördelning /
                                                        (SELECT   SUM(fördelning) AS Expr1
                                                           FROM         dbo.v_betalningsmottagare AS bm2
                                                           WHERE     (upphovsman_nr = bu.upphovsman_id) AND (NOT EXISTS
                                                                                        (SELECT   id
                                                                                           FROM         dbo.betalning_godkänd AS bg3
                                                                                           WHERE     (betalning_underlag_id = bu.id) AND (betalningsmottagare_typ = bm2.mottagare_typ) AND (betalningsmottagare_id = bm2.mottagare_id)))) 
                                                    AS belopp, CASE WHEN bm.mottagare_typ = 'S' OR
                                                    isnull(bu.BetaltFrånSysterOrg, 0) = 1 OR
                                                    isnull(bm.U_BosattSE, 0) = 0 OR
                                                    isnull(l.EU, 0) = 0 OR
                                                    (bu.betalning_typ != 'Följerätt' AND bm.Hobby != 0) THEN 0.0 ELSE bt.moms END AS moms, 
                                                    CASE WHEN bm.mottagare_typ = 'S' THEN CASE WHEN bu.betalning_typ LIKE 'FÖLJERÄTT' THEN
                                                        (SELECT   TOP 1 avdragdds
                                                           FROM         BUS.DBO.AVDRAG A JOIN
                                                                                    BUS.DBO.SYSTERORGANISATION S ON S.AVDRAG_NR = A.NR
                                                           WHERE     S.NR = bm.mottagare_id) WHEN (bu.betalning_typ LIKE 'REPRO' OR
                                                    bu.betalning_typ LIKE 'KR%' OR
                                                    bu.betalning_typ LIKE 'ST' OR
                                                    bu.betalning_typ LIKE 'TV%') THEN
                                                        (SELECT   TOP 1 avdragrepro
                                                           FROM         BUS.DBO.AVDRAG A JOIN
                                                                                    BUS.DBO.SYSTERORGANISATION S ON S.AVDRAG_NR = A.NR
                                                           WHERE     S.NR = bm.mottagare_id) ELSE 0.0 END ELSE CASE WHEN isnull(bu.BEtaltFrånSysterOrg, 0) = 0 THEN bt.avdrag WHEN isnull(bu.BEtaltFrånSysterOrg, 
                                                    0) = 1 AND (bu.betalning_typ LIKE 'REPRO' OR
                                                    bu.betalning_typ LIKE 'FÖLJERÄTT') THEN 10.0 ELSE 0.0 END END AS Avdrag, bu.betalning_typ, bu.upphovsman_id, bu.id AS Betalning_underlag_ID, 
                                                    bm.upphovsman_personnummer AS Personnummer, bm.upphovsman_förnamn AS Förnamn, bm.upphovsman_efternamn AS Efternamn, 
                                                    bu.betalningsdatum AS [Registrerat datum], bu.kommentar AS BEtalnings_underlag_kommentar, bm.mottagare_typ, bm.mottagare_id, 
                                                    bm.mottagare_efternamn		COLLATE Finnish_Swedish_CI_AS AS MOTTAGARE_EFTERNAMN, 
													bm.mottagare_förnamn		COLLATE Finnish_Swedish_CI_AS AS mottagare_förnamn, 
                                                    bm.mottagare_personnummer	COLLATE Finnish_Swedish_CI_AS AS mottagare_personnummer, 
                                                    CASE WHEN b_kt.Kontotyp = 'PostGiro' THEN 'PlusGiro' ELSE b_kt.Kontotyp END COLLATE Finnish_Swedish_CI_AS  AS Konto_typ_kortnamn,
                                                     NULL AS betalning_godkänd_id, NULL AS Betalning_post_id, bu.belopp AS betalning_underlag_belopp, bus.sum_betalt AS bu_Betalt, 
                                                    bu.belopp - bus.sum_betalt AS bu_Kvarvarande, 100.0 * (1.0 - bus.sum_betalt / bu.belopp) AS bu_Kvarvarande_procent, 100.0 * ((bu.belopp - bus.sum_betalt) 
                                                    * bm.fördelning /
                                                        (SELECT   SUM(fördelning) AS Expr1
                                                           FROM         dbo.v_betalningsmottagare AS bm2
                                                           WHERE     (upphovsman_nr = bu.upphovsman_id) AND (NOT EXISTS
                                                                                        (SELECT   id
                                                                                           FROM         dbo.betalning_godkänd AS bg3
                                                                                           WHERE     (betalning_underlag_id = bu.id) AND (betalningsmottagare_typ = bm2.mottagare_typ) AND (betalningsmottagare_id = bm2.mottagare_id))))) 
                                                    / bu.belopp AS bg_procent_av_Orginal, 
                                                    a.Adressrad1 + ' ' + a.Adressrad2 + ' ' + a.PostNr + ' ' + a.PostAdress + ' ' + a.CareOf COLLATE Finnish_Swedish_CI_AS AS Adress_kommentar, 
                                                    CASE WHEN rtrim(b_kt.[Kontotyp]) = 'Bankkonto' AND (bs.[kontonr] <> '' AND bs.ClearingsNr <> '') 
                                                    THEN 'Clearingnr ' + bs.ClearingsNr + ' Kontonr ' + bs.KontoNr + ' Bank ' + bs.Banknamn + ' ' WHEN (b_kt.[Kontotyp] = 'PostGiro' OR
                                                    b_kt.[Kontotyp] = 'BankGiro') AND 
                                                    bs.kontonr <> '' THEN 'Kontonr ' + bs.KontoNr + '  ' ELSE '' END COLLATE Finnish_Swedish_CI_AS AS Konto_kommentar, 
                                                    CASE WHEN rtrim(b_kt.[Kontotyp]) = 'Bankkonto' AND (bs.[kontonr] <> '' AND bs.ClearingsNr <> '') THEN 1 WHEN b_kt.[Kontotyp] = 'Avi' AND (a.Adressrad1 <> '' OR
                                                    a.Adressrad2 <> '') AND (a.PostNr <> '' AND a.PostAdress <> '') THEN 1 WHEN (b_kt.[Kontotyp] = 'PostGiro' OR
                                                    b_kt.[Kontotyp] = 'BankGiro') AND bs.kontonr <> '' THEN 1 ELSE 0 END AS KontoOK, CASE WHEN bm.mottagare_typ = 'U' AND EXISTS
                                                        (SELECT   UK.Upphovsman_Nr
                                                           FROM         bus.dbo.UpphovsmanKategori uk
                                                           WHERE     uk.Kategori_Nr = 7 AND UK.Upphovsman_Nr = bm.mottagare_id) THEN 1 WHEN bm.mottagare_typ = 'R' AND EXISTS
                                                        (SELECT   nr
                                                           FROM         bus.dbo.Rattighetshavare
                                                           WHERE     isnull(avlidendatum, '1900-01-01') > '1901-01-01' AND nr = bm.mottagare_id) THEN 1 ELSE 0 END AS DödsboEjKlart
                           FROM         dbo.v_betalning_underlag_sum_betalt AS bus INNER JOIN
                                                    dbo.betalning_underlag AS bu ON bu.id = bus.id INNER JOIN
                                                    dbo.v_betalningsmottagare AS bm ON bu.upphovsman_id = bm.upphovsman_nr LEFT OUTER JOIN
                                                    dbo.betalning_typ AS bt ON bu.betalning_typ = bt.kort_namn LEFT OUTER JOIN
                                                    BUS.dbo.Adress AS a ON a.Nr = bm.Adress_Nr LEFT OUTER JOIN
                                                    BUS.dbo.Betalningssatt AS bs ON bm.Betalningssatt_Nr = bs.Nr LEFT OUTER JOIN
                                                    BUS.dbo.Kontotyp AS b_kt ON bs.Kontotyp_Nr = b_kt.Nr INNER JOIN
                                                    BUS.dbo.Lander AS l ON l.Nr = a.Land_Nr
                           WHERE     (NOT EXISTS
                                                        (SELECT   id
                                                           FROM         dbo.betalning_godkänd AS bg3
                                                           WHERE     (betalning_underlag_id = bu.id) AND (betalningsmottagare_typ = bm.mottagare_typ) AND (betalningsmottagare_id = bm.mottagare_id))) AND 
                                                    (bm.fördelning > 0)
													) AS o



				
				
				
				--select * from v_betalning_summering where betalning_typ like 'KR%'					and betalningsmottagare_typ='S'		