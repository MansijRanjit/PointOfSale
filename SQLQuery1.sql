select * from vwTopSelling

select top 1 pdesc,sum(qty) as tsum from vwTopSelling where status='Sold' group by pdesc order by tsum desc
select top 1 sum(qty) as tsum from vwTopSelling where status='Sold' group by pdesc order by tsum desc
select top 1 pdesc  from vwTopSelling where status='Sold' group by pdesc

SELECT  pcode, pdesc,sdate,qty, status FROM vwTopSelling  where status LIKE 'Sold' and sdate like '_____10___' order by sdate desc

select top 1 pdesc,sum(qty) as tsum from vwTopSelling where status='Sold' group by pdesc order by tsum desc

SELECT Top 1 pdesc, sum(qty)as SQty FROM vwTopSelling  where status LIKE 'Sold' and sdate like '_____10___'group by pdesc order by SQty desc

use posmd