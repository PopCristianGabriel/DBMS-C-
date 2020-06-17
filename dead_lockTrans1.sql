select * from robot
select * from tournament

begin tran
update robot set name = 'deadlock' where id = 1
waitfor delay '00:00:05'
update tournament set name = 'deadlock' where id = 1
commit tran