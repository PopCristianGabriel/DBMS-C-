--this is an example of phantom read ,we will se the robot 7 

SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
BEGIN TRAN
SELECT * FROM robot
WAITFOR DELAY '00:00:04'
SELECT * FROM robot
COMMIT TRAN


--solution :set iso level to serializable,  we will not se the robot7

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRAN
SELECT * FROM robot
WAITFOR DELAY '00:00:04'
SELECT * FROM robot
COMMIT TRAN