

--we will have 2 results in the 2 selects
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRAN
SELECT * FROM tournament
WAITFOR DELAY '00:00:10'
SELECT * FROM tournament
COMMIT TRAN

--soluton: set iso level to repeatable read. We will have the same result in both querries
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRAN
SELECT * FROM tournament
WAITFOR DELAY '00:00:10'
SELECT * FROM tournament
COMMIT TRAN


