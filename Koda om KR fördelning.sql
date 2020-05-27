use B2
drop table #betalning_post_id
select bg.id bg_ID,bg.avdrag bg_avdrag,bp.avdrag bp_avdrag,bp.netto bp_netto,bp.id bp_ID, bp.betalning_transaktion_id tr_id
,(select TOP 1 avdragrepro FROM BUS.DBO.AVDRAG A JOIN BUS.DBO.SYSTERORGANISATION S ON S.AVDRAG_NR=A.NR WHERE S.NR=bg.betalningsmottagare_id) SYSTERAVDRAG
into #betalning_post_id 
from betalning_underlag bu
join betalning_godkänd bg on bu.id=bg.betalning_underlag_id
join betalning_post bp on bg.betalning_post_id=bp.id
where bu.betalning_typ like 'KR%' and bg.betalningsmottagare_typ='S'
 and bg.avdrag<>(select TOP 1 avdragrepro FROM BUS.DBO.AVDRAG A JOIN BUS.DBO.SYSTERORGANISATION S ON S.AVDRAG_NR=A.NR WHERE S.NR=bg.betalningsmottagare_id)
and bg.avdrag=0
select * from #betalning_post_id
-- Hitta alla godkända KR% rader uppdatera AVDRAGPROCENT
--Uppdatera alla BP avdrag kalkyl brutto*momsberäkningen
--summera alla traansaktioner 
-- Uppdatera busas historik

select * into betalning_godkänd_bu20170125 from betalning_godkänd 
update bg set avdrag=bt.systeravdrag
--select *
from betalning_godkänd bg join #betalning_post_id bt on bg.id=bt.bg_ID

select * into betalning_post_bu20170125 from betalning_post


update bp set netto=bg_netto_sum,avdrag=bgs.bg_avdrag_sum,Öresavrundning=bgs.Öresavrundning
--select bp.brutto,bp.netto,bp.avdrag,bp.moms,bp.Öresavrundning,bgs.* 
from betalning_post bp 
join
(select bg.betalning_post_id,  	 
bg_belopp_sum=		sum(bg.belopp) ,
bg_netto_sum=		round(sum(bg.belopp*(100.0+isnull(bg.moms,0.0))/100.0*(100.0-isnull(bg.avdrag,0.0))/100.0) ,0) 	,
bg_moms_sum =      	sum(bg.belopp*isnull(bg.moms,0.0)/100.0*(100.0-isnull(bg.avdrag,0.0))/100.0	)  		,
bg_avdrag_sum=		sum(bg.belopp*(isnull(bg.avdrag,0.0))/100.0),
Öresavrundning=round(	sum(bg.belopp*(100.0+isnull(bg.moms,0.0))/100.0*(100.0-isnull(bg.avdrag,0.0))/100.0),0)-sum(bg.belopp*(100.0+isnull(bg.moms,0.0))/100.0*(100.0-isnull(bg.avdrag,0.0))/100.0) 
from betalning_godkänd bg group by bg.betalning_post_id) bgs on bgs.betalning_post_id=bp.id
where bp.id in (select bp_ID from #betalning_post_id)


select * from #betalning_post_id bp
join betalning_godkänd_synk_busas bgsb on bgsb.betalning_godkänd=bp.bg_id
join bus.dbo.utbetalnigshistorik uh on bgsb.busas_id=uh.busas_id


