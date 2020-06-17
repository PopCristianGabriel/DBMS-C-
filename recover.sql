go
create or alter procedure AddRobotRecover(@RobotId int, @RobotName varchar(30))
as
begin tran
begin try
	
		insert into robot values(@RobotId,@RobotName)
		insert into logs values('inserted to robots')
		commit tran
end try
begin catch
	print 'rolled back robot'
	rollback tran
end catch

go

create or alter procedure AddTournamentRecover(@TournamentId int, @TournamentName varchar(30))
as
begin tran
begin try
	
		
		insert into tournament values(@TournamentId,@TournamentName)
		insert into logs values('inserted to tournament')
		commit tran
end try
begin catch
	print 'rolled back torunament' 
	rollback tran
end catch
go

create or alter procedure AddParticipates(@RobotId int, @TournamentId int)
as
	begin tran
	begin try
	

		insert into participates values(@RobotId,@TournamentId)
		insert into  dbo.logs values('inserted to participates')
		commit tran
	end try
	begin catch
		print 'rolled back participates'
		rollback tran
		
	end catch
go


create or alter procedure RecoverWorkingScenario 
as
exec AddRobot 1,'robot1'
	
	exec addTournament 1, 'tournament1'
	
	exec AddParticipates 1, 1
go

create or alter procedure RecoverNotWorkingScenario 
as
exec AddRobot 2,'robot2'
	
	exec addTournament 2, 'tournament2'
	
	exec AddParticipates 3, 1
go


delete from participates where Rid > 0
delete from tournament where id > 0
delete from robot where id > 0

exec RecoverWorkingScenario

select * from robot
select * from tournament
select * from participates

exec RecoverNotWorkingScenario

select * from robot
select * from tournament
select * from participates