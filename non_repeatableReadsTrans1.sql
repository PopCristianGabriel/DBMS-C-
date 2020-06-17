BEGIN TRAN
WAITFOR DELAY '00:00:04'
UPDATE tournament SET name='dawd' WHERE id=2
COMMIT TRAN



select * from tournament