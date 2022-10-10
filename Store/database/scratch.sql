-- select distinct category from store
-- select count(*) from store where category = 'sawitzki' 
select count(*) as count, category from store group by category 