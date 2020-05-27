drop table #t
SELECT * 
from v_betalning_summering WHERE upphovsman_id<2000--WHERESATS; 

select * from
v_betalning_summering t
join (select [Namn_Personnummer_grupp],sum(t2.CALC_Belopp_NETTO) T_Belopp ,sum(t2.Belopp) T_Belopp_Brutto  
		from v_betalning_summering t2 
	 where   t2.Upphovsman_id>2000
	 group by [Namn_Personnummer_grupp] having sum(t2.Belopp)>100 ) s on s.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] 
where t.Upphovsman_id>2000
 
order by efternamn,förnamn,[registrerat datum];




--WHERESATS; 


select *,(select sum(t2.CALC_Belopp_NETTO) from v_betalning_summering t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] ) T_Belopp,
(select sum(t2.Belopp) from v_betalning_summering t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp]  ) T_Belopp_Brutto,
* --into #resultat2
 from 
v_betalning_summering t WHERE upphovsman_id<2000--WHERESATS;
and (select sum(t2.Belopp) from v_betalning_summering t2 where t2.[Namn_Personnummer_grupp]=t.[Namn_Personnummer_grupp] )>0 --Get_Filter_TotalSumma() 
order by efternamn,förnamn,[registrerat datum];
