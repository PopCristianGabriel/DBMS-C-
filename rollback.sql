go
create or alter procedure AddRobot(@RobotId int, @RobotName varchar(30))
as
	if exists(select * from robot where id = @RobotId)
		begin
		
		RAISERROR('robot already exists',14,1)
		end
		insert into robot values(@RobotId,@RobotName)
		insert into logs values('inserted to robots')
go

create or alter procedure AddTournament(@TournamentId int, @TournamentName varchar(30))
as
	if exists(select * from tournament where id = @TournamentId)
		begin
		
		RAISERROR('tournament already exists',14,1)
		end
		insert into tournament values(@TournamentId,@TournamentName)
		insert into logs values('inserted to tournament')
go

create or alter procedure AddParticipates(@RobotId int, @TournamentId int)
as
	if not exists(select * from tournament where id = @TournamentId)
		begin
		RAISERROR('invalid tournament id',14,1)
		end

	if not exists(select * from robot where id = @RobotId)
		begin
		
		RAISERROR('invalid robot id',14,1)
		end

		insert into participates values(@RobotId,@TournamentId)
		insert into  dbo.logs values('inserted to participates')
go


create or alter procedure rollBackScenarioWorking
as
begin tran
begin try
	exec AddRobot 1,'robot1'
	
	exec addTournament 1, 'tournament1'
	
	exec AddParticipates 1, 1
	commit tran
end try
begin catch
	
	rollback tran
	return
end catch
go


create or alter procedure rollBackScenarioNotWorking
as
begin tran
begin try
	exec AddRobot 2,'robot2'
	exec addTournament 2, 'tournament2'
	exec AddParticipates 3, 1 --here it crashes
	commit tran
end try
begin catch
	rollback tran
	return
end catch
go

exec rollBackScenarioWorking
select * from participates
select * from logs
select * from tournament

exec rollBackScenarioNotWorking
select * from participates

