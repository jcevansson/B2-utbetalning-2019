select f.FakturaNr,f.kund_meddelande,f.FakturaDatum,f.Betaldatum,fr.Betald,fr.kreditnr,fr.preskiberad,fr.DDS_ersattning,fr.FakturaRad,fr.Utrop,fr.Titel,bu.belopp,bg.betalningsmottagare_typ,bg.fördelning from bus.dbo.faktura f
join bus.dbo.dds_verk fr on f.nr=fr.Faktura_Nr
join betalning_synk_busas bsb on fr.busas_id=bsb.busas_id and bsb.busas_typ='FÖLJERÄTT'
join betalning_underlag bu on bsb.betalning_underlag=bu.id
join betalning_godkänd bg on bu.id=bg.betalning_underlag_id
join betalning_post bp on bg.betalning_post_id=bp.id
where fr.kredit=1 and fr.preskiberad is null




select f.FakturaNr,f.kund_meddelande,f.FakturaDatum,f.Betaldatum,fr.Betald,fr.kreditnr,fr.Belopp Repro_belopp,fr.FakturaRad,fr.Titel,bu.belopp,bg.betalningsmottagare_typ,bg.fördelning from bus.dbo.faktura f
join bus.dbo.ReproduktionAvVerk fr on f.nr=fr.Faktura_Nr
join betalning_synk_busas bsb on fr.busas_id=bsb.busas_id and bsb.busas_typ='REPRO'
join betalning_underlag bu on bsb.betalning_underlag=bu.id
join betalning_godkänd bg on bu.id=bg.betalning_underlag_id
join betalning_post bp on bg.betalning_post_id=bp.id
where fr.kredit=1




select *   from bus.dbo.dds_verk fr
join betalning_synk_busas bsb on fr.busas_id=bsb.busas_id and bsb.busas_typ='FÖLJERÄTT'
join betalning_underlag bu on bsb.betalning_underlag=bu.id
left join betalning_godkänd bg on bu.id=bg.betalning_underlag_id
where fr.kredit=1 and fr.preskiberad is null and bg.id is null

select * from bus.dbo.ReproduktionAvVerk fr
join betalning_synk_busas bsb on fr.busas_id=bsb.busas_id and bsb.busas_typ='REPRO'
join betalning_underlag bu on bsb.betalning_underlag=bu.id
left join betalning_godkänd bg on bu.id=bg.betalning_underlag_id
where fr.kredit=1  and bg.id is null


select bsb.betalning_underlag into #T from bus.dbo.dds_verk fr
join betalning_synk_busas bsb on fr.busas_id=bsb.busas_id and bsb.busas_typ='FÖLJERÄTT'
join betalning_underlag bu on bsb.betalning_underlag=bu.id
left join betalning_godkänd bg on bu.id=bg.betalning_underlag_id
where fr.kredit=1 and fr.preskiberad is null and bg.id is null

insert #T (betalning_underlag)
select bsb.betalning_underlag from bus.dbo.ReproduktionAvVerk fr
join betalning_synk_busas bsb on fr.busas_id=bsb.busas_id and bsb.busas_typ='REPRO'
join betalning_underlag bu on bsb.betalning_underlag=bu.id
left join betalning_godkänd bg on bu.id=bg.betalning_underlag_id
where fr.kredit=1  and bg.id is null

delete betalning_synk_busas	where betalning_underlag	in (select betalning_underlag from #T)

delete betalning_underlag	where ID					in (select betalning_underlag from #T)


drop table #T


sp_synk_reproduktion