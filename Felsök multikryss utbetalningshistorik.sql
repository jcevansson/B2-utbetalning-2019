select top 10 * 
 FROM   "BUS"."dbo"."v_rap_redov_repro" "v_rap_bet_historik"  
 
 where Fnamn='lars'and Enamn='agger'
 and Utbetaltdatum>'2017-01-01'

 select * FROM   "BUS"."dbo"."v_rap_redov_repro" "v_rap_bet_historik"  
 where F�rdelning=0 and utbetaltdatum


 select top 100 * from v_betalning_summering_betald where [Registrerat datum]>'2018-05-01'
 select top 100  * from BUS.dbo.utbetalnigshistorik uh where RetNr=0 and uh.F�rdelning=0 and uh.Utbetaltdatum>'2018-01-01'
 select * from v_upphovsman where enamn='agger' and Fnamn='Lars' --UID=25
 select * from betalning_underlag bu
 join betalning_godk�nd bg on bu.id=bg.betalning_underlag_id
 join betalning_post bp on bg.betalning_post_id=bp.id
 where bu.upphovsman_id=25

 
 select * from betalning_underlag bu
 join betalning_godk�nd bg on bu.id=bg.betalning_underlag_id
 join betalning_post bp on bg.betalning_post_id=bp.id
 where bp.skapad>'2018-06-14'
select * from 
update bus.dbo.utbetalnigshistorik set f�rdelning=100 where busas_id in (
	
 select uh.busas_id from betalning_underlag bu
 join betalning_godk�nd bg on bu.id=bg.betalning_underlag_id
 join betalning_post bp on bg.betalning_post_id=bp.id
 join betalning_godk�nd_synk_busas bgsb on bg.id=bgsb.betalning_godk�nd
 join bus.dbo.utbetalnigshistorik uh on bgsb.busas_id=uh.busas_id
 where bp.skapad>'2018-06-14'

 )


 select * from v_betalning_summering where upphovsman_id=25
 if OBJECT_ID('tempdb..#t') is not null drop table  #t;
        SELECT [Namn_Personnummer_grupp],mottagare_id,mottagare_typ,mottagare_personnummer,mottagare_efternamn,mottagare_f�rnamn,upphovsman_ID,personnummer,efternamn,f�rnamn,betalning_typ,konto_typ_kortnamn,Adress_Kommentar,Konto_Kommentar, betalnings_underlag_Kommentar,KontoOK,[Registrerat datum] , F�rdelning,betalning_underlag_belopp, CALC_Belopp_NETTO,calc_moms, moms, calc_avdrag, avdrag, Belopp,checkable checkable,d�dsboejklart,status status,1 antal_underlag ,betalning_Underlag_id betalning_Underlag_id, bg_procent_av_orginal 
        into #t from v_betalning_summering_obetald 
        where mottagare_id=25 and mottagare_typ='U'
select * from #t
create INDEX x_Namn_Personnummer_grupp on #t (Namn_Personnummer_grupp);  create INDEX x_Upphovsman on #t (Upphovsman_ID); create INDEX x_MottagarTyp on #t ( mottagare_id,mottagare_typ);create INDEX x_BetalningTyp on #t (betalning_typ	);


========== Build: 1 succeeded or up-to-date, 0 failed, 0 skipped ==========

select * from betalning_godk�nd bg where bg.skapad>'2018-06-13'
