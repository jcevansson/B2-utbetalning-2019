select ts.T_Belopp, ts.T_Belopp_Brutto, t.* from (SELECT [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar, convert(varchar,count(*)) + ' st. underlag '  betalnings_underlag_Kommentar,KontoOK,min([Registrerat datum]) [Registrerat datum] ,sum(Belopp)/sum(betalning_underlag_belopp) Fördelning,sum(betalning_underlag_belopp) betalning_underlag_belopp,sum(CALC_Belopp_NETTO) CALC_Belopp_NETTO,sum(calc_moms) calc_moms,sum(calc_moms)/SUM(belopp) moms,sum(calc_avdrag) calc_avdrag,sum(calc_avdrag)/SUM(belopp) avdrag,sum(Belopp) Belopp,max(checkable) checkable,min(dödsboejklart) dödsboejklart,max(status) status, COUNT(*) antal_underlag ,min(betalning_Underlag_id) betalning_Underlag_id,0 bg_procent_av_orginal from v_betalning_summering  where( datediff(hh,[Registrerat datum] , '1999-05-31 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-06-14 23:59')>0 and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')													) group by [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar,KontoOK ) t   join (select [Namn_Personnummer_grupp],sum(isnull(CALC_Belopp_NETTO,0.0)) T_Belopp,sum(isnull(Belopp,0.0)) T_Belopp_Brutto from v_betalning_summering  where(   datediff(hh,[Registrerat datum] , '1999-05-31 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-06-14 23:59')>0 and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')										  ) group by  [Namn_Personnummer_grupp]  having(sum(CALC_Belopp_NETTO) > 100) )  ts on ts.Namn_Personnummer_grupp =t.[Namn_Personnummer_grupp]  order by efternamn,förnamn,[registrerat datum]; 

use b2

drop table #t
select * from v_betalning_summering  where Betalning_typ like 'Följerätt%'
select * from v_betalning_summering_obetald  where Betalning_typ like 'Följerätt%'
select * from v_betalning_summering_betald  where Betalning_typ like 'Följerätt%'
select * from v_betalning_summering_saknas  where Betalning_typ like 'Följerätt%'

	where( 
			datediff(hh,[Registrerat datum] , '1999-05-31 00:01')<0 
			and datediff(hh,[Registrerat datum] , '2018-06-14 23:59')>0 
			and kontoOK=1 
			and DödsBoEjKlart=0  
			and STATUS !='BETALD'  
			and (mottagare_typ like 'U%' or mottagare_typ like 'R%' or mottagare_typ like 'O%')   
		   and (Betalning_typ like 'Följerätt%')			
		) 
	



select ts.T_Belopp, ts.T_Belopp_Brutto, t.* 
from (
		SELECT [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar, convert(varchar,count(*)) + ' st. underlag '  betalnings_underlag_Kommentar,KontoOK,min([Registrerat datum]) [Registrerat datum] ,sum(Belopp)/sum(betalning_underlag_belopp) Fördelning,sum(betalning_underlag_belopp) betalning_underlag_belopp,sum(CALC_Belopp_NETTO) CALC_Belopp_NETTO,sum(calc_moms) calc_moms,sum(calc_moms)/SUM(belopp) moms,sum(calc_avdrag) calc_avdrag,sum(calc_avdrag)/SUM(belopp) avdrag,sum(Belopp) Belopp,max(checkable) checkable,min(dödsboejklart) dödsboejklart,max(status) status, COUNT(*) antal_underlag ,min(betalning_Underlag_id) betalning_Underlag_id,0 bg_procent_av_orginal 
 from #t
		--where( 
		--	datediff(hh,[Registrerat datum] , '1999-05-31 00:01')<0 
		--	and datediff(hh,[Registrerat datum] , '2018-06-14 23:59')>0 
		--	and kontoOK=1 
		--	and DödsBoEjKlart=0  
		--	and STATUS !='BETALD'  
		--	and (mottagare_typ like 'U%' or mottagare_typ like 'R%' or mottagare_typ like 'O%')   
		--	and
		--	 (Betalning_typ like 'Följerätt%')			
		--) 
		group by [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar,KontoOK 
		
		) t   
join (
		select [Namn_Personnummer_grupp],sum(isnull(CALC_Belopp_NETTO,0.0)) T_Belopp,sum(isnull(Belopp,0.0)) T_Belopp_Brutto 
		from #t  
		--where(   datediff(hh,[Registrerat datum] , '1999-05-31 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-06-14 23:59')>0 and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')   and ( Betalning_typ like 'Följerätt%') ) 
		group by  [Namn_Personnummer_grupp]  having(sum(CALC_Belopp_NETTO) > 100)
		)  ts 
on ts.Namn_Personnummer_grupp =t.[Namn_Personnummer_grupp]  
order by efternamn,förnamn,[registrerat datum]; 



select distinct betalningsmottagare_typ from betalning_godkänd order by betalningsmottagare_typ




--Felsökning

select ts.T_Belopp, ts.T_Belopp_Brutto, t.* 
from (
		SELECT [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar, 
		convert(varchar,count(*)) + ' st. underlag '  betalnings_underlag_Kommentar,KontoOK,min([Registrerat datum]) [Registrerat datum] ,sum(Belopp)/sum(betalning_underlag_belopp) Fördelning,
		sum(betalning_underlag_belopp) betalning_underlag_belopp,sum(CALC_Belopp_NETTO) CALC_Belopp_NETTO,sum(calc_moms) calc_moms,sum(calc_moms)/SUM(belopp) moms,sum(calc_avdrag) calc_avdrag,sum(calc_avdrag)/SUM(belopp) avdrag,sum(Belopp) Belopp,max(checkable) checkable,min(dödsboejklart) dödsboejklart,max(status) status, COUNT(*) antal_underlag ,min(betalning_Underlag_id) betalning_Underlag_id,0 bg_procent_av_orginal 
		from v_betalning_summering  
		where( 
		datediff(hh,[Registrerat datum] , '2018-09-11 00:01')<0 
		and datediff(hh,[Registrerat datum] , '2018-09-25 23:59')>0 
		and kontoOK=1 and DödsBoEjKlart=0  
		and STATUS !='BETALD'  
		and (mottagare_typ like 'U%' or mottagare_typ like 'R%' or mottagare_typ like 'O%') 
		and ( Betalning_typ like 'TVC%' OR  Betalning_typ like 'TVCopy-F%')
		   ) 
		group by [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar,KontoOK 
		) t   
		join (
		select [Namn_Personnummer_grupp],sum(isnull(CALC_Belopp_NETTO,0.0)) T_Belopp,
		sum(isnull(Belopp,0.0)) T_Belopp_Brutto 
		from v_betalning_summering  
		where(   datediff(hh,[Registrerat datum] , '2018-09-11 00:01')<0 
				and datediff(hh,[Registrerat datum] , '2018-09-25 23:59')>0
				 and kontoOK=1 and DödsBoEjKlart=0  
				 and STATUS !='BETALD'  
				 and (mottagare_typ like 'U%' or mottagare_typ like 'R%' or mottagare_typ like 'O%')   
				 and ( Betalning_typ like 'TVC%' OR  Betalning_typ like 'TVCopy-F%') 
				 ) 
		group by  [Namn_Personnummer_grupp]  
		having(sum(CALC_Belopp_NETTO) > 100) 
		)  ts on ts.Namn_Personnummer_grupp =t.[Namn_Personnummer_grupp] 
		order by efternamn,förnamn,[registrerat datum]; 




		--Felsökning kommentartsök
		select ts.T_Belopp, ts.T_Belopp_Brutto, t.* 
		from (SELECT [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar, convert(varchar,count(*)) + ' st. underlag '  betalnings_underlag_Kommentar,KontoOK,min([Registrerat datum]) [Registrerat datum] ,sum(Belopp)/sum(betalning_underlag_belopp) Fördelning,sum(betalning_underlag_belopp) betalning_underlag_belopp,sum(CALC_Belopp_NETTO) CALC_Belopp_NETTO,sum(calc_moms) calc_moms,sum(calc_moms)/SUM(belopp) moms,sum(calc_avdrag) calc_avdrag,sum(calc_avdrag)/SUM(belopp) avdrag,sum(Belopp) Belopp,max(checkable) checkable,min(dödsboejklart) dödsboejklart,max(status) status, COUNT(*) antal_underlag ,min(betalning_Underlag_id) betalning_Underlag_id,0 bg_procent_av_orginal 
		from v_betalning_summering  
		where(	datediff(hh,[Registrerat datum] , '2018-09-27 00:01')<0 
				and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 
				and kontoOK=1 and DödsBoEjKlart=0  
				and STATUS !='BETALD'  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  
				--and betalnings_underlag_kommentar like 'Fakt%'
				 ) 
				group by [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar,KontoOK ) t   join (select [Namn_Personnummer_grupp],sum(isnull(CALC_Belopp_NETTO,0.0)) T_Belopp,sum(isnull(Belopp,0.0)) T_Belopp_Brutto from v_betalning_summering  where(   datediff(hh,[Registrerat datum] , '2018-09-27 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  and betalnings_underlag_kommentar like '%180430%' ) group by  [Namn_Personnummer_grupp]  having(sum(CALC_Belopp_NETTO) > 100) )  ts on ts.Namn_Personnummer_grupp =t.[Namn_Personnummer_grupp]  order by efternamn,förnamn,[registrerat datum]; 




select ts.T_Belopp, ts.T_Belopp_Brutto, t.* 
from 
(SELECT [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar, convert(varchar,count(*)) + ' st. underlag '  betalnings_underlag_Kommentar,KontoOK,min([Registrerat datum]) [Registrerat datum] ,sum(Belopp)/sum(betalning_underlag_belopp) Fördelning,sum(betalning_underlag_belopp) betalning_underlag_belopp,sum(CALC_Belopp_NETTO) CALC_Belopp_NETTO,sum(calc_moms) calc_moms,sum(calc_moms)/SUM(belopp) moms,sum(calc_avdrag) calc_avdrag,sum(calc_avdrag)/SUM(belopp) avdrag,sum(Belopp) Belopp,max(checkable) checkable,min(dödsboejklart) dödsboejklart,max(status) status, COUNT(*) antal_underlag ,min(betalning_Underlag_id) betalning_Underlag_id,0 bg_procent_av_orginal from v_betalning_summering  where( datediff(hh,[Registrerat datum] , '2018-09-27 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  and betalnings_underlag_kommentar like 'Fakt.180%'   and ( Betalning_typ like 'Repro%') ) group by [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar,KontoOK ) t  
 join (select [Namn_Personnummer_grupp],sum(isnull(CALC_Belopp_NETTO,0.0)) T_Belopp,sum(isnull(Belopp,0.0)) T_Belopp_Brutto 
 from v_betalning_summering_OBETALD
 where(   datediff(hh,[Registrerat datum] , '2018-09-27 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  
and betalnings_underlag_kommentar like '%180%'   
and ( Betalning_typ like 'Repro%') ) 
group by  [Namn_Personnummer_grupp]  having(sum(CALC_Belopp_NETTO) > 100) )  ts on ts.Namn_Personnummer_grupp =t.[Namn_Personnummer_grupp]
  order by efternamn,förnamn,[registrerat datum]; 




  select ts.T_Belopp, ts.T_Belopp_Brutto, t.* from (SELECT [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar, convert(varchar,count(*)) + ' st. underlag '  betalnings_underlag_Kommentar,KontoOK,min([Registrerat datum]) [Registrerat datum] ,sum(Belopp)/sum(betalning_underlag_belopp) Fördelning,sum(betalning_underlag_belopp) betalning_underlag_belopp,sum(CALC_Belopp_NETTO) CALC_Belopp_NETTO,sum(calc_moms) calc_moms,sum(calc_moms)/SUM(belopp) moms,sum(calc_avdrag) calc_avdrag,sum(calc_avdrag)/SUM(belopp) avdrag,sum(Belopp) Belopp,max(checkable) checkable,min(dödsboejklart) dödsboejklart,max(status) status, COUNT(*) antal_underlag ,min(betalning_Underlag_id) betalning_Underlag_id,0 bg_procent_av_orginal from 
  v_betalning_summering  where( datediff(hh,[Registrerat datum] , '2018-09-27 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 and kontoOK=1 and DödsBoEjKlart=0  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  and betalnings_underlag_kommentar like '%834704%' ) group by [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar,KontoOK ) t   join (select [Namn_Personnummer_grupp],sum(isnull(CALC_Belopp_NETTO,0.0)) T_Belopp,sum(isnull(Belopp,0.0)) T_Belopp_Brutto 
  from v_betalning_summering  where(   datediff(hh,[Registrerat datum] , '2018-09-27 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 and kontoOK=1 and DödsBoEjKlart=0  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  and betalnings_underlag_kommentar like '%834704%' ) group by  [Namn_Personnummer_grupp]  having(sum(CALC_Belopp_NETTO) > 100) )  ts on ts.Namn_Personnummer_grupp =t.[Namn_Personnummer_grupp]  order by efternamn,förnamn,[registrerat datum]; 



  select ts.T_Belopp, ts.T_Belopp_Brutto, t.* 
  from (
  SELECT [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar, convert(varchar,count(*)) + ' st. underlag '  betalnings_underlag_Kommentar,KontoOK,min([Registrerat datum]) [Registrerat datum] ,sum(Belopp)/sum(betalning_underlag_belopp) Fördelning,sum(betalning_underlag_belopp) betalning_underlag_belopp,sum(CALC_Belopp_NETTO) CALC_Belopp_NETTO,sum(calc_moms) calc_moms,sum(calc_moms)/SUM(belopp) moms,sum(calc_avdrag) calc_avdrag,sum(calc_avdrag)/SUM(belopp) avdrag,sum(Belopp) Belopp,max(checkable) checkable,min(dödsboejklart) dödsboejklart,max(status) status, COUNT(*) antal_underlag ,min(betalning_Underlag_id) betalning_Underlag_id,0 bg_procent_av_orginal 
  from v_betalning_summering_OBETALD  
  where( datediff(hh,[Registrerat datum] , '2017-09-27 00:01')<0 
  and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  
  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  
  and betalnings_underlag_kommentar like '%180140%'   
  and ( Betalning_typ like 'Repro%') ) 
  group by [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar,KontoOK 
  ) t   
  
  join (
  select [Namn_Personnummer_grupp],sum(isnull(CALC_Belopp_NETTO,0.0)) T_Belopp,sum(isnull(Belopp,0.0)) T_Belopp_Brutto 
  from v_betalning_summering_obetald
  where(   datediff(hh,[Registrerat datum] , '2011-09-27 00:01')<0 
  and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 
  and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  
  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  
  and betalnings_underlag_kommentar like '%180140%'   and ( Betalning_typ like 'Repro%') ) 
  group by  [Namn_Personnummer_grupp]  
  having(sum(CALC_Belopp_NETTO) > 100) 
  )  ts on ts.Namn_Personnummer_grupp =t.[Namn_Personnummer_grupp] 
   order by efternamn,förnamn,[registrerat datum]; 


select * from betalning_underlag where kommentar like '%180140%'


--70,2	78	Bergqvist, Fred (19500409-0170)
--70,2	78	Brusewitz, Charlotte (19460818-0768)    25 sek 41 rader

select ts.T_Belopp, ts.T_Belopp_Brutto, t.* 
from 
(SELECT case when rtrim(mottagare_personnummer)<> '' then rtrim(mottagare_personnummer) else rtrim(mottagare_efternamn)+rtrim(mottagare_förnamn) end [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar, convert(varchar,count(*)) + ' st. underlag '  betalnings_underlag_Kommentar,KontoOK,min([Registrerat datum]) [Registrerat datum] ,sum(Belopp)/sum(betalning_underlag_belopp) Fördelning,sum(betalning_underlag_belopp) betalning_underlag_belopp,sum(CALC_Belopp_NETTO) CALC_Belopp_NETTO,sum(calc_moms) calc_moms,sum(calc_moms)/SUM(belopp) moms,sum(calc_avdrag) calc_avdrag,sum(calc_avdrag)/SUM(belopp) avdrag,sum(Belopp) Belopp,max(checkable) checkable,min(dödsboejklart) dödsboejklart,max(status) status, COUNT(*) antal_underlag ,min(betalning_Underlag_id) betalning_Underlag_id,0 bg_procent_av_orginal 
	from v_betalning_summering_OBETALD  
	where( datediff(hh,[Registrerat datum] , '2018-04-27 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 
	and kontoOK=1 and DödsBoEjKlart=0  
	and STATUS !='BETALD'  
	and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  and betalnings_underlag_kommentar like '%1801%'   and ( Betalning_typ like 'Repro%') ) group by [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar,KontoOK 
	) t   
	join
	 (
	 select case when rtrim(mottagare_personnummer)<> '' then rtrim(mottagare_personnummer) else rtrim(mottagare_efternamn)+rtrim(mottagare_förnamn) end [Namn_Personnummer_grupp],sum(isnull(CALC_Belopp_NETTO,0.0)) T_Belopp,sum(isnull(Belopp,0.0)) T_Belopp_Brutto 
	from v_betalning_summering
	where(   datediff(hh,[Registrerat datum] , '2018-04-27 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 
	and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  
	and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  
	and betalnings_underlag_kommentar like '%1801%'   and ( Betalning_typ like 'Repro%') ) 
	group by  case when rtrim(mottagare_personnummer)<> '' then rtrim(mottagare_personnummer) else rtrim(mottagare_efternamn)+rtrim(mottagare_förnamn) end  having(sum(CALC_Belopp_NETTO) > 0)
	 )  ts on -- case when rtrim(ts.Pnr)<> '' then rtrim(ts.Pnr) else rtrim(ts.Enamn)+rtrim(ts.fnamn) end=
			  --case when rtrim(t.Pnr)<> '' then rtrim(t.Pnr) else rtrim(t.Enamn)+rtrim(t.fnamn) end
	 ts.Namn_Personnummer_grupp =t.[Namn_Personnummer_grupp]  
	 order by efternamn,förnamn,[registrerat datum]; 

	 select u.pnr,u.enamn,u.fnamn,r.Pnr,r.Enamn,r.Fnamn,* from bus.dbo.Upphovsman u join bus.dbo.Rattighetshavare r on
	 case when r.Pnr<> '' then r.Pnr else rtrim(r.Enamn)+rtrim(r.fnamn) end=case when u.pnr<>'' then u.pnr else rtrim(u.enamn)+rtrim(u.fnamn) end
	 
	 where rtrim(r.Pnr)='' and (r.Enamn<>u.enamn or u.fnamn<>r.fnamn)





	 select ts.T_Belopp, ts.T_Belopp_Brutto, t.* 
	 from (
		SELECT case when rtrim(mottagare_personnummer)<> '' then rtrim(mottagare_personnummer) else rtrim(mottagare_efternamn)+rtrim(mottagare_förnamn) end [Namn_Personnummer_grupp],
		mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar, convert(varchar,count(*)) + ' st. underlag '  betalnings_underlag_Kommentar,KontoOK,min([Registrerat datum]) [Registrerat datum] ,sum(Belopp)/sum(betalning_underlag_belopp) Fördelning,sum(betalning_underlag_belopp) betalning_underlag_belopp,sum(CALC_Belopp_NETTO) CALC_Belopp_NETTO,sum(calc_moms) calc_moms,sum(calc_moms)/SUM(belopp) moms,sum(calc_avdrag) calc_avdrag,sum(calc_avdrag)/SUM(belopp) avdrag,sum(Belopp) Belopp,max(checkable) checkable,min(dödsboejklart) dödsboejklart,max(status) status, COUNT(*) antal_underlag ,min(betalning_Underlag_id) betalning_Underlag_id,0 bg_procent_av_orginal 
		from v_betalning_summering_OBETALD  
		where( datediff(hh,[Registrerat datum] , '2018-09-27 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%') ) 
		group by case when rtrim(mottagare_personnummer)<> '' then rtrim(mottagare_personnummer) else rtrim(mottagare_efternamn)+rtrim(mottagare_förnamn) end,
		mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_förnamn,upphovsman_ID,personnummer,efternamn,förnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar,KontoOK 
		) t   
		join 
		(
		select case when rtrim(mottagare_personnummer)<> '' then rtrim(mottagare_personnummer) else rtrim(mottagare_efternamn)+rtrim(mottagare_förnamn) end [Namn_Personnummer_grupp],
		sum(isnull(CALC_Belopp_NETTO,0.0)) T_Belopp,sum(isnull(Belopp,0.0)) T_Belopp_Brutto 
	 from v_betalning_summering_OBETALD  
	 where(   datediff(hh,[Registrerat datum] , '2018-09-27 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%') ) 
	 group by  case when rtrim(mottagare_personnummer)<> '' then rtrim(mottagare_personnummer) else rtrim(mottagare_efternamn)+rtrim(mottagare_förnamn) end  having(sum(CALC_Belopp_NETTO) > 100) 
	 )  ts 
	 on ts.Namn_Personnummer_grupp =t.[Namn_Personnummer_grupp]  order by efternamn,förnamn,[registrerat datum]; 


	 SELECT *, 1 antal_underlag from v_betalning_summering  
	 where( datediff(hh,[Registrerat datum] , '2018-09-27 00:01')<0 and datediff(hh,[Registrerat datum] , '2018-10-11 23:59')>0 
	 and kontoOK=1 and DödsBoEjKlart=0  and STATUS !='BETALD'  
	 and (rtrim(mottagare_typ) like 'U%' or rtrim(mottagare_typ) like 'R%' or rtrim(mottagare_typ) like 'O%')  
	 and Namn_Personnummer_grupp = '19231016-7123'   
	 and betalning_typ = 'FÖLJERÄTT'  
	 and upphovsman_ID = '851')   order by efternamn,förnamn,[registrerat datum]; 



