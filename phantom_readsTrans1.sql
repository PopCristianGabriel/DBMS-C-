begin tran
waitfor delay '00:00:04'
insert into robot values(7,'robot7')
commit tran
