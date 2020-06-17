begin tran
update Customer set customerName='dirty' where CustomerId = 3
waitfor delay '00:00:05'

rollback tran