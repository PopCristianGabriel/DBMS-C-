select * from robot
select * from tournament

--this will cause a deadlock since both transactions are waiting for one another
begin tran
update robot set name = 'deadlock' where id = 1
waitfor delay '00:00:05'
update tournament set name = 'deadlock' where id = 1
commit tran


--solution : set deadlock priorty to this transaction
SET DEADLOCK_PRIORITY HIGH
begin tran
update robot set name = 'deadlock' where id = 1
waitfor delay '00:00:05'
update tournament set name = 'deadlock' where id = 1
commit tran
