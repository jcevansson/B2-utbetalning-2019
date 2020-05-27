








ALTER       procedure [dbo].[sp_betalning_transaktion_summera]
@betalning_transaktion_id as int

as
if exists (select id from betalning_transaktion where id=@betalning_transaktion_id and status<>'Closed')
begin
/*konto och adress information*/
select betalning_post_id,bg.betalningsmottagare_id,bg.betalningsmottagare_typ,
bg_belopp_sum=		sum(bg.belopp) ,
bg_netto_sum=		sum(bg.belopp*
				(100.0+isnull(bg.moms,0.0))/100.0*
				(100.0-isnull(bg.avdrag,0.0))/100.0
				)  	,
bg_moms_sum =      	sum(bg.belopp*isnull(bg.moms,0.0)/100.0*
					(100.0-isnull(bg.avdrag,0.0))/100.0
				)  		,
bg_avdrag_sum=		sum(bg.belopp*(isnull(bg.avdrag,0.0))/100.0)
into #sum_BG 
from betalning_godkänd bg 
join betalning_post bp on bp.id=bg.betalning_post_id
WHERE bp.betalning_transaktion_id=@betalning_transaktion_id
group by betalning_post_id,bg.betalningsmottagare_id,bg.betalningsmottagare_typ

select betalning_transaktion_id,betalning_post.id, 
	[clearing_nummer] = isnull(bm.clearingsnr,'')
      ,[konto_nummer] = isnull(bm.kontonr,'')
      ,[bank] = isnull(bm.banknamn,'')
      ,[adressrad1] = isnull(bm.adressrad1,'')
      ,[adressrad2] = isnull(bm.adressrad2,'')
      ,[postnr] =isnull( bm.postnr,'')
      ,[postadress] =isnull( bm.postadress,'')
      ,[brutto]=			isnull(#sum_BG.bg_belopp_sum ,0.0)
      ,[netto]=			round(	isnull(#sum_BG.bg_netto_sum,0.0),0)
      ,Öresavrundning=		round(	isnull(#sum_BG.bg_netto_sum,0.0),0)-isnull(bg_netto_sum,0)
      ,[moms]=				isnull(#sum_BG.bg_moms_sum,0.0)
      ,[avdrag]=		isnull(#sum_BG.bg_avdrag_sum,0.0)
      ,[efternamn]=		ISNULL(bm.mottagare_efternamn,'')
      ,[förnamn]=		ISNULL(bm.mottagare_förnamn,'')
		,[personnummer]=  ISNULL(bm.mottagare_personnummer,'')     
      
into #CHANGE 
from  betalning_post
join  [v_betalningsmottagare_konto_adress] bm  
on  betalning_post.betalningsmottagare_id=bm.mottagare_id 
and  betalning_post.betalningsmottagare_typ like bm.mottagare_typ + '%'
left join #sum_BG  on  #sum_BG.betalning_post_id=betalning_post.id
WHERE betalning_transaktion_id=@betalning_transaktion_id


UPDATE [betalning_post]
   SET
--select *,
	[clearing_nummer] = #CHANGE.[clearing_nummer]
      ,[konto_nummer] = #CHANGE.[konto_nummer]
      ,[bank] = #CHANGE.[bank]
      ,[adressrad1] = #CHANGE.[adressrad1]
      ,[adressrad2] = #CHANGE.[adressrad2]
      ,[postnr] =#CHANGE.[postnr]
      ,[postadress] =#CHANGE.[postadress]
      ,[brutto]=			#CHANGE.[brutto]
      ,[netto]=			#CHANGE.[netto]
      ,Öresavrundning=		#CHANGE.Öresavrundning
      ,[moms]=				#CHANGE.[moms]
      ,[avdrag]=		#CHANGE.[avdrag]
      ,[efternamn]=		#CHANGE.[efternamn]
      ,[förnamn]=		#CHANGE.[förnamn]
      ,[personnummer]=		#CHANGE.[personnummer]
from  betalning_post
join #CHANGE on betalning_post.id=#CHANGE.id 
WHERE #CHANGE.betalning_transaktion_id=@betalning_transaktion_id

drop table #sum_BG
drop table #CHANGE
update betalning_transaktion set status='Assigned' where id=@betalning_transaktion_id
end










