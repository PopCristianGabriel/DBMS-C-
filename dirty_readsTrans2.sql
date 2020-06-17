

--here is an example of a dirty read
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
begin tran

select * from Customer
waitfor delay '00:00:10'
select * from Customer
commit tran


--sol: set iso level to read commited

SET TRANSACTION ISOLATION LEVEL READ COMMITTED
begin tran
select * from Customer
waitfor delay '00:00:10'
select * from Customer
commit tran


--The dirty read occurs because the second transaction is able to read from the database before the first transactions ends. By setting
-- the isolation level to read commited the second transaction waits for the first one to complete.