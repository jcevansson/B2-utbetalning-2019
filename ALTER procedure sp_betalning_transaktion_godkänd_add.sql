CREATE procedure sp_betalning_transaktion_godkänd_add
@betalning_underlag_id as int,
@betalningsmottagare_id as int,
@betalningmottagare_typ as char(10),
@fördelning_av_orginalsumma as float,
@betalning_transaktion_id as int,
@fördelat_belopp as money,
@avdrag as float,
@moms as float

as
declare @status as nchar(10)
set @status=isnull((select status from betalning_transaktion where id =@betalning_transaktion_id),'')
if @status='New' OR @status='Assigned'
Begin

declare @ID as int 

--Från fördelning 
insert into betalning_godkänd (betalning_underlag_id, betalningsmottagare_id, betalningsmottagare_typ, fördelning,
      belopp, avdrag, moms, användare, skapad)
    values (@betalning_underlag_id, @betalningsmottagare_id, @betalningmottagare_typ, @fördelning_av_orginalsumma, 
      @fördelat_belopp, @avdrag, @moms, system_user, getdate())
select @id = @@identity

exec sp_betalning_transaktion_add @ID ,@betalning_transaktion_id 

end

