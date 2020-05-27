


select * from bus.dbo.Rattighetshavare r 
--update bus.dbo.Rattighetshavare set organisation_nr='' 
where  isnumeric(replace(rtrim(organisation_nr),'-',''))=0 and LEN(organisation_nr)>0


select * from bus.dbo.Upphovsman r where  CONVERT(int, substring(r.organisation_nr, 3, 1)) = 1 AND LEN(replace(r.organisation_nr, '-', '')) = 10 
select * from bus.dbo.Upphovsman
--update bus.dbo.Upphovsman set organisation_nr='' 
where Enamn='Lindberg' and Fnamn like 'M%' isnumeric(replace(rtrim(organisation_nr),'-',''))=0 and LEN(organisation_nr)>0

 r.organisation_nr like '802434-1516' AND LEN(replace(r.organisation_nr, '-', '')) = 10
SELECT * FROM BUS.DBO.RattighetsUpphovsman RU WHERE RU.Rattighetshavare_Nr=2479
SELECT * FROM bus.DBO.Upphovsman U WHERE Nr=7379



SELECT * from v_betalning_kontrolluppgift_summering  where År=2016 and Efternamn like '%lindberg%' and organisationsnummer='802434-1516'




SELECT   År, personnummer, OrganisationsNummer, efternamn, förnamn, SUM(calc_Kontrolluppgift) AS calc_SUM_Kontrolluppgift, 
                         SUM(CASE WHEN betalningsmottagare_typ <> 'R' THEN calc_Kontrolluppgift ELSE 0 END) AS calc_SUM_Kontrolluppgift_Royalty, 
                         SUM(CASE WHEN betalningsmottagare_typ = 'R' THEN calc_Kontrolluppgift ELSE 0 END) AS calc_SUM_Kontrolluppgift_Ärvd_Royalty
FROM         dbo.v_betalning_kontrolluppgift
WHERE     (LEN(personnummer) = 12) OR
                         (LEN(REPLACE(OrganisationsNummer, '-', '')) = 12)
						 
GROUP BY År, personnummer, OrganisationsNummer, efternamn, förnamn


alter view v_betalning_kontrolluppgift as
SELECT   DATEPART(yyyy, bt.transaktion_dag) AS År, bp.efternamn, bp.förnamn, REPLACE(RTRIM(bp.personnummer), '-', '') AS personnummer, bp.betalningsmottagare_typ, 
                         bp.betalningsmottagare_id, CASE WHEN bp.betalningsmottagare_typ = 'U' THEN replace(isnull
                             ((SELECT   '16' + u.organisation_nr
                                 FROM         bus.dbo.Upphovsman u
                                 WHERE     u.Nr = bp.betalningsmottagare_id AND LEN(replace(u.organisation_nr, '-', '')) = 10 AND CONVERT(int, substring(u.organisation_nr, 3, 1)) >= 2
								 ), ''), '-', '') 
                         WHEN bp.betalningsmottagare_typ = 'R' THEN replace(isnull
                             ((SELECT   '16' + r.organisation_nr
                                 FROM         bus.dbo.Rattighetshavare r
                                 WHERE     r.Nr = bp.betalningsmottagare_id AND LEN(replace(r.organisation_nr, '-', '')) = 10 AND CONVERT(int, substring(r.organisation_nr, 3, 1)) >= 2
								 ), '') , '-', '') 
                         ELSE '' END AS OrganisationsNummer, CASE WHEN bu.betalning_typ = 'FÖLJERÄTT' THEN bg.belopp * (100.0 + isnull(bg.moms, 0.0)) / 100.0 * (100.0 - isnull(bg.avdrag, 0.0)) 
                         / 100.0 ELSE bg.belopp * (100.0 - isnull(bg.avdrag, 0.0)) / 100.0 END AS calc_Kontrolluppgift, bu.id AS bu_id, bg.id AS bg_id, bp.id AS bp_id
FROM         dbo.betalning_godkänd AS bg INNER JOIN
                         dbo.betalning_post AS bp ON bg.betalning_post_id = bp.id INNER JOIN
                         dbo.betalning_transaktion AS bt ON bp.betalning_transaktion_id = bt.id INNER JOIN
                         dbo.betalning_underlag AS bu ON bu.id = bg.betalning_underlag_id
WHERE     (bt.status = 'Closed') AND (bg.betalningsmottagare_typ IN ('R', 'U', 'O')) 


--and bp.betalningsmottagare_id=21591




select * from bus.dbo.Upphovsman u where replace(u.Pnr,'-','') like '%8112277812%'
select * from v_betalning_kontrolluppgift where 