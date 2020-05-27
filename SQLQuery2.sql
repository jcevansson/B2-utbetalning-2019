SELECT COUNT(*)
                  FROM      dbo.v_betalning_underlag_sum_betalt AS bus 
				  INNER JOIN
                                    dbo.betalning_underlag AS bu ON bu.id = bus.id 
				INNER JOIN
                                    dbo.v_betalningsmottagare AS bm ON bu.upphovsman_id = bm.upphovsman_nr 
				LEFT OUTER JOIN
                                    dbo.betalning_typ AS bt ON bu.betalning_typ = bt.kort_namn 
				LEFT OUTER JOIN
                                    BUS.dbo.Adress AS a ON a.Nr = bm.Adress_Nr 
				LEFT OUTER JOIN
                                    BUS.dbo.Betalningssatt AS bs ON bm.Betalningssatt_Nr = bs.Nr 
									
				LEFT OUTER JOIN
                                    BUS.dbo.Kontotyp AS b_kt ON bs.Kontotyp_Nr = b_kt.Nr 
				INNER JOIN
                                    BUS.dbo.Lander AS l ON l.Nr = a.Land_Nr
                  WHERE   (NOT EXISTS
                                        (SELECT id
                                         FROM      dbo.betalning_godkänd AS bg3
                                         WHERE   (betalning_underlag_id = bu.id) AND (betalningsmottagare_typ = bm.mottagare_typ) AND (betalningsmottagare_id = bm.mottagare_id))) AND 
                                   (bm.fördelning > 0)
							
							
alter view v_betalning_underlag_sum_betalt as							
SELECT bu.id AS id, bu.belopp, SUM(isnull(bg.belopp,0)) AS sum_betalt
FROM     dbo.betalning_underlag AS bu left join dbo.betalning_godkänd AS bg
                   ON bu.id = bg.betalning_underlag_id
GROUP BY bu.id, bu.belopp
HAVING (SUM(isnull(bg.belopp,0)) < bu.belopp - 1.0)								    
