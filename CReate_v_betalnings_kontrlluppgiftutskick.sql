
select * from v_betalning_kontrolluppgift_summering kus
where kus.personnummer='193809163946' and kus.�r='2010'
order by ku.efternamn,ku.f�rnamn,ku.personnummer,ku.betalningsmottagare_typ desc,t.namn Ers�ttningstyp

select * from v_betalning_kontrolluppgift_summering kus
where kus.calc_SUM_Kontrolluppgift_Royalty>0 and kus.calc_SUM_Kontrolluppgift_�rvd_Royalty>0


v_Betalning_kontrolluppgift_Utskick

alter 
--create 
view v_Betalning_kontrolluppgift_Utskick
as
select ku.�r,ku.Efternamn,ku.f�rnamn,ku.personnummer,ku.OrganisationsNummer,Sum(calc_Kontrolluppgift) calc_Kontrolluppgift,ku.betalningsmottagare_typ, case when betalningsmottagare_typ='R' then '�rvd royalty av'  else 'Royalty' END �rvd,u.Enamn U_Efternamn,u.Fnamn U_F�rnamn,u.Pnr U_Personnummer
,t.namn Ers�ttningstyp
from v_betalning_kontrolluppgift ku
join betalning_underlag bu on ku.bu_id=bu.id
join betalning_typ t on bu.betalning_typ=t.kort_namn
join bus.dbo.Upphovsman u on bu.upphovsman_id=u.nr
--where ku.personnummer='193809163946' and ku.�r='2010'
--order by ku.efternamn,ku.f�rnamn,ku.personnummer,ku.betalningsmottagare_typ desc,t.namn 
group by ku.�r,t.namn,ku.Efternamn,ku.f�rnamn,ku.personnummer,ku.OrganisationsNummer,ku.betalningsmottagare_typ, case when betalningsmottagare_typ='R' then '�rvd royalty av'  else 'Royalty' END ,u.Enamn,u.Fnamn,u.Pnr 


