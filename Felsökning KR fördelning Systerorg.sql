use B2
select * from betalning_transaktion bt 


where datediff(dd,bt.transaktion_dag,getdate())=0
select * from betalning_underlag bu
join betalning_godkänd bg on bu.id=bg.betalning_underlag_id
join betalning_post bp on bg.betalning_post_ID=bp.id 
where bp.betalning_transaktion_id=906 and bu.betalning_typ like 'KR%' 

select * from b2.dbo.v_betalningsmottagare bm where bm.mottagare_typ='S' and bm.mottagare_id=9

select TOP 1 * FROM BUS.DBO.AVDRAG A JOIN BUS.DBO.SYSTERORGANISATION S ON S.AVDRAG_NR=A.NR WHERE S.NR=9




