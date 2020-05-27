use b2
SELECT * ,  Mottagare_Efternamn+', '+Mottagare_Förnamn+' ('+Mottagare_personnummer+')' Mottagar_grupp from v_betalning_transaktion_post  where  datediff(hh,[utbetalning_transaktion_skapad] , '2018-11-22 00:01')<0 and datediff(hh,[utbetalning_transaktion_skapad] , '2019-02-05 23:59')>0  and ( rtrim(Betalning_typ) like 'IV%')  and  (bp_Konto_typ = 'Plusgiro') and Status='Closed'order by mottagare_efternamn,mottagare_förnamn,bu_upphovsman_efternamn,bu_upphovsman_förnamn,utbetalning_transaktion_skapad 




use b2
SELECT top 100 * from v_betalning_kontrolluppgift_summering where År=2019 order by År,efternamn,förnamn,personnummer,OrganisationsNummer