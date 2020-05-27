CREATE procedure sp_betalning_transaktion_godk�nd_add
@betalning_underlag_id as int,
@betalningsmottagare_id as int,
@betalningmottagare_typ as char(10),
@f�rdelning_av_orginalsumma as float,
@betalning_transaktion_id as int,
@f�rdelat_belopp as money,
@avdrag as float,
@moms as float

as
declare @status as nchar(10)
set @status=isnull((select status from betalning_transaktion where id =@betalning_transaktion_id),'')
if @status='New' OR @status='Assigned'
Begin

declare @ID as int 

--Fr�n f�rdelning 
insert into betalning_godk�nd (betalning_underlag_id, betalningsmottagare_id, betalningsmottagare_typ, f�rdelning,
      belopp, avdrag, moms, anv�ndare, skapad)
    values (@betalning_underlag_id, @betalningsmottagare_id, @betalningmottagare_typ, @f�rdelning_av_orginalsumma, 
      @f�rdelat_belopp, @avdrag, @moms, system_user, getdate())
select @id = @@identity

exec sp_betalning_transaktion_add @ID ,@betalning_transaktion_id 

end

