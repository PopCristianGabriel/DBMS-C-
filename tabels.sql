create table robot(
id int primary key,
name varchar(30)
)

create table tournament(
id int primary key,
name varchar(30)
)

create table participates(
Rid int references robot(id),
Tid int references tournament(id),
primary key (Rid,Tid)
)


create table Logs(
id int identity primary key,
operation varchar(40)
)