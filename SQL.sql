create database AfishaEvent
select * from users;
--10 table--------------------------------------------------
use AfishaEvent

create table Calendar(
	Id int primary key,
	[Date] date unique not null
)

create table Films(
	Id int primary key,
	[Name] varchar(50) unique not null,
	[DescriptionAndActors] varchar(50) not null,
	Photo varbinary(max) not null,
	Genre varchar(50) not null,
	Country varchar(50) not null,
	Duration varchar(30) not null
)

create table Cinemas(
	Id int primary key,
	[Name] varchar(50) unique not null,
	[Adress] varchar(70) not null,
	Photo varbinary(max) not null,
)

create table MoviesInCinemas(
	Id int primary key,
	DateID int references Calendar(Id) on delete cascade not null,
	FilmsId int references Films(Id) on delete cascade not null,
	CinemasId int references Cinemas(id) on delete cascade not null,
	Price int not null,
	[Time] varchar(50) not null,
	[FreeSpaces] int not null,
	[ReservedSpaces] int not null
)

create table Users(
	Id int primary key,
	[E-mail] varchar(100) unique not null,
	[Name] varchar(50) not null,
	[Password] varbinary(150) not null
)

insert into Users(Id,[E-mail],[Name],[Password])
values (1,'Admin','Admin',pwdencrypt('Pa$$word'))

create table Concerts(
	Id int primary key,
	[Name] varchar(50) unique not null,
	[Description] text not null,
	[Time] varchar(50) not null,
	Photo varbinary(max) not null,
	Genre varchar(50) not null
)

create table ConcertHalls(
	Id int primary key,
	[Name] varchar(50) unique not null,
	[Adress] varchar(70) not null,
	Photo varbinary(max) not null
)

create table ConcertsInConcertHalls(
	Id int primary key,
	DateID int references Calendar(Id) on delete cascade not null,
	ConcertsId int references Concerts(Id) on delete cascade not null,
	ConcertsHallsId int references ConcertHalls(id) on delete cascade not null,
	Price int not null,
	[FreeSpaces] int not null,
	[ReservedSpaces] int not null
)

create table BookedMovies(
	Id int primary key,
	UserId int references Users(Id) on delete cascade not null,
	FilmId int references Films(Id) on delete cascade not null,
	DateId int references Calendar(Id) not null
)

create table BookedConcerts(
	Id int primary key,
	UserId int references Users(Id) on delete cascade not null,
	ConcertId int references Concerts(Id) on delete cascade not null,
	DateId int references Calendar(Id) not null
)

--table--------------------------------------------------------------------

--23 function-----------------------------------------------------------------

go
create function CheckIdCICH(@newId int) 
returns int
as
begin
	declare @count int
	set @count = 0
	while @count < 10000
	begin
	set @count = @count + 1
	if(select count(Id) from ConcertsInConcertHalls where Id = @count) = 0
	  break;
	end;
	return @count
end;



go
create function CheckIdMIC(@newId int) 
returns int
as
begin
	declare @count int
	set @count = 0
	while @count < 10000
		begin
		set @count = @count + 1
		if(select count(Id) from MoviesInCinemas where Id = @count) = 0
		  break;
		end;
	return @count
end;
go
create function CheckIdCalendar() 
returns int
as
begin
	declare @count int
	set @count = 0
	while @count < 10000
		begin
		set @count = @count + 1
		if(select count(Id) from Calendar where Id = @count) = 0
		  break;
	end;
	return @count
end;

go
create function CheckIdFilm(@newId int) 
returns int
as
begin
	declare @count int
	set @count = 0
	while @count < 10000
		begin
		set @count = @count + 1
		if(select count(Id) from Films where Id = @count) = 0
		  break;
		end;
	return @count
end;
go
create function CheckIdConcert(@newId int) 
returns int
as
begin
	declare @count int
	set @count = 0
	while @count < 10000
		begin
		set @count = @count + 1
		if(select count(Id) from Concerts where Id = @count) = 0
		  break;
		end;
	return @count
end;

go
create function CheckIdCinema(@newId int) 
returns int
as
begin
	declare @count int
	set @count = 0
	while @count < 10000
		begin
		set @count = @count + 1
		if(select count(Id) from Cinemas where Id = @count) = 0
		  break;
		end;
	return @count
end;
go
create function CheckIdBookedMovies(@newId int) 
returns int
as
begin
	declare @count int
	set @count = 0
	while @count < 10000
		begin
		set @count = @count + 1
		if(select count(Id) from BookedMovies where Id = @count) = 0
		  break;
		end;
	return @count
end;
go
create function CheckIdBookedConcerts(@newId int) 
returns int
as
begin
	declare @count int
	set @count = 0
	while @count < 10000
		begin
		set @count = @count + 1
		if(select count(Id) from BookedConcerts where Id = @count) = 0
		  break;
		end;
	return @count
end;
go
alter function CheckIdConcertHalls(@newId int) 
returns int
as
begin
	declare @count int
	set @count = 0
	while @count < 10000
		begin
		set @count = @count + 1
		if(select count(Id) from ConcertHalls where Id = @count) = 0
		  break;
		end;
	return @count
end;
go
alter function CheckIdUser(@newId int) 
returns int
as
begin
	declare @count int
	set @count = 0
	while @count < 110000
		begin
		set @count = @count + 1
		if(select count(Id) from Users where Id = @count) = 0
		  break;
		end;
	return @count
end;
go
create function SelectIdConcerts(@newConcertName varchar(50)) 
returns int
as
begin
  declare @Id int
   select @Id = Id from Concerts where [Name] = @newConcertName
  return @Id
end;
go
create function SelectIdConcertHalls(@newCinemasName varchar(50))  
returns int
as
begin
  declare @Id int
   select @Id = Id from ConcertHalls where [Name] = @newCinemasName
  return @Id
end;
go
create function SelectIdDate(@newDate date) 
returns int
as
begin
	declare @newId int
	select @newId = Id from Calendar where [Date] = @newDate;
	return @newId
end;
go
create function GetFilmId(@newId int) 
returns int
as
begin
	declare @Id int
	select @Id = FilmsId from MoviesInCinemas where Id = @newId
	return @Id
end;
go
create function GetConcertId(@newId int) 
returns int
as
begin
	declare @Id int
	select @Id = ConcertsId from ConcertsInConcertHalls where Id = @newId
	return @Id
end;
go
create function SelectIdMoviesInCinemas(@newCinemasName varchar(50)) 
returns int
as
begin
  declare @Id int
   select @Id = Id from Films where [Name] = @newCinemasName
  return @Id
end;
go
create function SelectIdCinema(@newCinemaName varchar(50))  
returns int
as
begin
	declare @Id int
	select @Id = Id from Cinemas where [Name] = @newCinemaName
	return @Id
end;
go
create function SelectIdFilms(@newFilmsName varchar(50)) 
returns int
as
begin
  declare @Id int
   select @Id = Id from Films where [Name] = @newFilmsName
  return @Id
end;
go
create function SelectIdBookedMovies(@newFilmsName varchar(50)) 
returns int
as
begin
  declare @Id int
   select @Id = Id from BookedMovies where [Name] = @newFilmsName
  return @Id
end;
go
create function SelectIdUsers(@newUserName varchar(50)) 
returns int
as
begin
  declare @Id int
   select @Id = Id from Users where [Name] = @newUserName
  return @Id
end;
go


--function---------------------------------------------------------------

--67 procedure-----------------------------------------------------------


create procedure Auth
@Pass varchar(150),
@Mail varchar(100),
@out int output as
begin
	declare @Userpass varbinary(150)
	select @Userpass = Password from Users where [E-mail] = @Mail
	set @out = pwdcompare(@Pass,@Userpass,0)
end;

go
alter procedure BuyFilms
	@Id int,
	@count int,
	@User nvarchar(50),
	@Date date as
begin
	declare @freeSpace int
	declare @IdUpdate int
	declare @IdUserUpdate int
	declare @IdFilmUpdate int
	declare @IdDateUpdate int
	declare @totalfreeSpace int
	declare @reservedSpaces int
	select @freeSpace = FreeSpaces from MoviesInCinemas where Id = @Id
	select @reservedSpaces = ReservedSpaces from MoviesInCinemas where Id = @Id
	set @totalfreeSpace = @freeSpace - @reservedSpaces
	--if(@count <= @totalfreeSpace)
	begin
		update MoviesInCinemas set ReservedSpaces = ReservedSpaces + @count where Id = @Id
		set @IdUpdate = dbo.CheckIdBookedMovies(@id)
		set @IdFilmUpdate = dbo.GetFilmId(@Id);
		set @IdDateUpdate = dbo.SelectIdDate(@Date)
		set @IdUserUpdate = dbo.SelectIdUsers(@User)
		insert BookedMovies(Id,UserId,FilmId,DateId)
		values (@IdUpdate, @IdUserUpdate, @IdFilmUpdate, @IdDateUpdate)
	end;
end;
go
alter procedure BuyConcerts
	@Id int,
	@count int,
	@User nvarchar(50),
	@Date date as
begin
	declare @freeSpace int
	declare @IdUpdate int
	declare @IdUserUpdate int
	declare @IdConcertUpdate int
	declare @IdDateUpdate int
	declare @totalfreeSpace int
	declare @reservedSpaces int
	select @freeSpace = FreeSpaces from MoviesInCinemas where Id = @Id
	select @reservedSpaces = ReservedSpaces from MoviesInCinemas where Id = @Id
	set @totalfreeSpace = @freeSpace - @reservedSpaces
	--if(@count <= @totalfreeSpace)
	begin
		update ConcertsInConcertHalls set ReservedSpaces = ReservedSpaces + @count where Id = @Id
		set @IdUpdate = dbo.CheckIdBookedConcerts(@id)
		set @IdConcertUpdate = dbo.GetConcertId(@Id)
		set @IdDateUpdate = dbo.SelectIdDate(@Date)
		set @IdUserUpdate = dbo.SelectIdUsers(@User)
		insert BookedConcerts(Id,UserId,ConcertId,DateId)
		values (@IdUpdate, @IdUserUpdate, @IdConcertUpdate, @IdDateUpdate)
	end;
end;
go
create procedure AddMIC
@newId int, 
@newDate date,
@newFilmsName varchar(50),
@newCinemasName varchar(50),
@newPrice int,
@newTime varchar(50),
@newReservedSpaces int,
@newFreeSpaces int as
begin
	if(@newFreeSpaces > @newReservedSpaces)
	begin
		if not exists(select Id from Calendar where [Date] = @newDate) 
			insert into Calendar(Id, [Date]) values (dbo.CheckIdCalendar(), @newDate);
		
	insert into MoviesInCinemas(Id,[DateID],[FilmsId],[CinemasId],[Price],[Time],[FreeSpaces],[ReservedSpaces])
	 values(dbo.CheckIdMIC(@newId), dbo.SelectIdDate(@newDate), dbo.SelectIdFilms(@newFilmsName), dbo.SelectIdCinema(@newCinemasName), @newPrice,@newTime, @newFreeSpaces, @newReservedSpaces)
	end;
end;
go
create procedure AddCICH
	@newId int, 
	@newDate date,
	@newConcertsName varchar(50),
	@newConcertHallsName varchar(50),
	@newPrice int,
	@newReservedSpaces int,
	@newFreeSpaces int as
begin
	if(@newFreeSpaces > @newReservedSpaces)
	begin
		if not exists(select Id from Calendar where [Date] = @newDate) 
			insert into Calendar(Id, [Date]) values (dbo.CheckIdCalendar(), @newDate);
		
	insert into ConcertsInConcertHalls(Id,[DateID],[ConcertsId],[ConcertsHallsId],[Price],[FreeSpaces],[ReservedSpaces])
	 values(dbo.CheckIdCICH(@newId), dbo.SelectIdDate(@newDate), dbo.SelectIdConcerts(@newConcertsName), dbo.SelectIdConcertHalls(@newConcertHallsName), @newPrice, @newFreeSpaces, @newReservedSpaces)
	end;
  end;
go
create procedure ChangeMIC  
	@Id int, 
	@newDate date,
	@newFilmsName varchar(50),
	@newCinemasName varchar(50),
	@newPrice int,
	@newTime varchar(50),
	@newFreeSpaces int,
	@newReservedSpaces int as
	begin
		update MoviesInCinemas
		set [DateID] = dbo.SelectIdDate(@newDate),
		FilmsId = dbo.SelectIdFilms(@newFilmsName),
		CinemasId = dbo.SelectIdCinema(@newCinemasName),
		Price = @newPrice,
		[Time] = @newTime,
		FreeSpaces = @newFreeSpaces,
		ReservedSpaces = @newReservedSpaces
		where [Id] = @Id
end;
go
create procedure ChangeCICH
	@Id int, 
	@newDate date,
	@newConcertsName varchar(50),
	@newConcertHallsName varchar(50),
	@newPrice int,
	@newFreeSpaces int,
	@newReservedSpaces int as
	begin
		update ConcertsInConcertHalls
		set [DateID] = dbo.SelectIdDate(@newDate),
		[ConcertsId] = dbo.SelectIdConcerts(@newConcertsName),
		ConcertsHallsId = dbo.SelectIdConcertHalls(@newConcertHallsName),
		[Price] = @newPrice,
		[FreeSpaces] = @newFreeSpaces,
		[ReservedSpaces] = @newReservedSpaces
		where [Id] = @Id
	end;
go
CREATE PROCEDURE GetConcertHallsByConcertId
@ConcertId int, 
@currentDate date AS
BEGIN
    select t3.Name, t3.Adress, t3.Photo, t1.Price, t1.ReservedSpaces, t1.FreeSpaces , t1.Id from ConcertsInConcertHalls as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join ConcertHalls as t3 on (t1.ConcertsHallsId = t3.Id) 
	inner join Concerts as t4 on (t1.ConcertsId = t4.Id)
	where(t2.Date = @currentDate and t4.Id = @ConcertId)
END;
go
create PROCEDURE GetCinemasByFilmId
@FilmId int, 
@currentDate date AS
BEGIN
    select t3.Name, t3.Adress, t3.Photo, t1.Price, t1.Time, t1.ReservedSpaces, t1.FreeSpaces , t1.Id from MoviesInCinemas as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join Cinemas as t3 on (t1.CinemasId = t3.Id) 
	inner join Films as t4 on (t1.FilmsId = t4.Id)
	where(t2.Date = @currentDate and t4.Id = @FilmId)
END;

exec GetCinemasByFilmId @FilmId = 2, @currentDate = '2020-09-01';
go
create PROCEDURE GetConcertsByConcertHallsId 
@ConcertHallsId int, 
@currentDate date AS
BEGIN
    select t3.[Name], t3.Genre, t3.[Time], t3.Photo, t1.Price, t1.ReservedSpaces, t1.FreeSpaces , t1.Id from ConcertsInConcertHalls as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join Concerts as t3 on (t1.ConcertsId = t3.Id) 
	inner join ConcertHalls	 as t4 on (t1.ConcertsHallsId = t4.Id)
	where(t2.[Date] = @currentDate and t4.Id = @ConcertHallsId)
END;
go

alter PROCEDURE GetFilmsByCinemaId 
@CinemaId int, 
@currentDate date AS
BEGIN
    select t3.Name, t4.Genre, t3.Photo, t1.Price, t1.ReservedSpaces, t1.FreeSpaces, t1.Id, t4.Name from MoviesInCinemas as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join Cinemas as t3 on (t1.CinemasId = t3.Id) 
	inner join Films as t4 on (t1.FilmsId = t4.Id)
	where(t2.Date = @currentDate and t3.Id = @CinemaId)
END;

----------------------------------------------------------------------------------------
drop procedure GetCinemasByFilmsId;
go
create PROCEDURE GetCinemasByFilmsId 
@FilmsId int, 
@currentDate date AS
BEGIN
    select t3.Name, t4.Genre, t3.Photo, t1.Price, t1.ReservedSpaces, t1.FreeSpaces, t1.Id, t4.Name from MoviesInCinemas as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join Cinemas as t3 on (t1.CinemasId = t3.Id) 
	inner join Films as t4 on (t1.FilmsId = t4.Id)
	where(t2.Date = @currentDate and t3.Id = @FilmsId)
END;

exec GetCinemasByFilmsId @FilmsId = 6, @currentDate = '2020-12-03';
go
CREATE PROCEDURE SelectAllConcertHallsByDate
@currentDate date AS
BEGIN
    select distinct t3.Name, t3.Adress, t3.Photo, t3.Id from ConcertsInConcertHalls as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join ConcertHalls as t3 on (t1.ConcertsHallsId = t3.Id) 
	where(t2.Date = @currentDate)
END;
go
CREATE PROCEDURE SelectAllCinemasByDate 
@currentDate date AS
BEGIN
    select distinct t3.Name, t3.Adress, t3.Photo, t3.Id from MoviesInCinemas as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join Cinemas as t3 on (t1.CinemasId = t3.Id) 
	where(t2.Date = @currentDate)
END;
go
create PROCEDURE SelectAllFilmsByDate
@currentDate date
as
BEGIN
	select * from films order by name;
END;
go
alter PROCEDURE SelectAllConcertsByDate
@currentDate date
as
BEGIN
	select [name], [Description], [time], Photo, Genre, id from Concerts order by name;
END;
go
create procedure AddUser
@newId int,
@newMail varchar(100),
@newName varchar(50),
@newPassword varchar(150)
as
begin
	 insert into Users(Id, [E-mail], [Name], [Password]) 
	 values (dbo.CheckIdUser(@newId), @newMail, @newName, pwdencrypt(@newPassword));
end;
go
create procedure ChangeUser
@Id int,
@newMail varchar(100),
@newName varchar(50),
@newPassword varchar(150)
as
begin
	update Users
	set [E-mail] = @newMail,
	[Name] = @newName,
	[Password] = pwdencrypt(@newPassword)
	where [Id] = @Id
end;
go
alter procedure AddCinema 
@newId int,
@newName varchar(50),
@newAddress varchar(70),
@newPhoto varbinary(MAX)
as
begin
	 insert into Cinemas(Id, [Name], Adress, Photo)
	 values (dbo.CheckIdCinema(@newId), @newName, @newAddress, @newPhoto);
end;
go
create procedure AddFilm 
@newId int,
@newName varchar(50),
@newDescriptionAndActors varchar(50),
@newPhoto varbinary(MAX),
@newGenre varchar(50),
@newCountry varchar(50),
@newDuration varchar(30)
as
begin
	 insert into Films(Id, [Name], DescriptionAndActors, Photo, Genre, Country, Duration) 
	 values (dbo.CheckIdFilm(@newId), @newName, @newDescriptionAndActors, @newPhoto, @newGenre, @newCountry, @newDuration);
end;
go
create procedure AddConcerts
@newId int,
@newName varchar(50),
@newDescription varchar(50),
@newPhoto varbinary(MAX),
@newGenre varchar(50),
@newTime varchar(50)
as
begin
	 insert into Concerts(Id, [Name], [Description], Photo, Genre, [Time]) values (dbo.CheckIdConcert(@newId), @newName, @newDescription, @newPhoto, @newGenre, @newTime);
end;
go
create procedure ChangeFilm
	@Id int, 
	@newName varchar(50),
	@newDescriptionAndActors varchar(50),
	@newPhoto varbinary(MAX),
	@newGenre varchar(50),
	@newCountry varchar(50),
	@newDuration varchar(30) as
	begin
	update Films
	set 
	[Name] = @newName,
	DescriptionAndActors = @newDescriptionAndActors,
	Photo = @newPhoto,
	Genre = @newGenre,
	Country = @newCountry,
	Duration = @newDuration
	where [Id] = @Id
end;


go
create procedure ChangeConcerts 
	@Id int, 
	@newName varchar(50),
	@newDescription varchar(50),
	@newPhoto varbinary(MAX),
	@newGenre varchar(50),
	@newTime varchar(50) as
	begin
		update Concerts set 
		[Name] = @newName,
		[Description] = @newDescription,
		Photo = @newPhoto,
		Genre = @newGenre,
		[Time] = @newTime
		where [Id] = @Id
	end;
go
create procedure ChangeCinema 
	@Id int, 
	@newName varchar(50),
	@newAddress varchar(50),
	@newPhoto varbinary(MAX)
	as
	begin
	update Cinemas
	set 
	[Name] = @newName,
	Adress = @newAddress,
	Photo = @newPhoto
	where [Id] = @Id
end;

go
create procedure ChangeConcertHalls 
	@Id int, 
	@newName varchar(50),
	@newAddress varchar(50),
	@newPhoto varbinary(MAX)
	as
	begin
	update ConcertHalls
	set 
	[Name] = @newName,
	Adress = @newAddress,
	Photo = @newPhoto
	where [Id] = @Id
end;
go
create procedure DeleteCalendarById 
@deleteId  int as
begin
	 delete from Calendar where Id = @deleteId;
end
go
create procedure DeleteMICById 
@deleteId  int as
begin
	 delete from MoviesInCinemas where Id = @deleteId;
end
go
create procedure DeleteFilmsById 
@deleteId  int as
begin
     --SET NOCOUNT ON 
	 delete from Films where Id = @deleteId;
end
go
create procedure DeleteCinemasById 
@deleteId  int as
begin
	 delete from Cinemas where Id = @deleteId;
end
go
create procedure DeleteConcertsById 
@deleteId  int as
begin
	 delete from Concerts where Id = @deleteId;
end
go
create procedure DeleteConcertHallsById 
@deleteId  int as
begin
	 delete from ConcertHalls where Id = @deleteId;
end
go
create procedure DeleteCICHById 
@deleteId  int as
begin
	 delete from ConcertsInConcertHalls where Id = @deleteId;
end
go

create procedure DeleteBMById 
@deleteId  int as
begin
	 delete from BookedMovies where Id = @deleteId;
end
go
create procedure DeleteBCById 
@deleteId  int as
begin
	 delete from BookedConcerts where Id = @deleteId;
end
go
create procedure DeleteUserById 
@deleteId  int as
begin
	 delete from Users where Id = @deleteId;
end
go
INSERT INTO dbo.Films(Id, [Name], DescriptionAndActors,  Genre, Country, Duration, Photo)
SELECT 1, 'Name1', 'DescriptionAndActors1', 'newGenre1', 'newCountry1', 'newDuration1', Photo 
FROM OPENROWSET(BULK N'D:\image\MyImage.png', SINGLE_BLOB) AS ImageSource(Photo);

INSERT INTO dbo.Films(Id, [Name], DescriptionAndActors,  Genre, Country, Duration, Photo)
SELECT 2, 'Name2', 'DescriptionAndActors2', 'newGenre2', 'newCountry2', 'newDuration2', Photo 
FROM OPENROWSET(BULK N'D:\image\vinni.png', SINGLE_BLOB) AS ImageSource(Photo);

INSERT INTO dbo.Films(Id, [Name], DescriptionAndActors,  Genre, Country, Duration, Photo)
SELECT 3, 'Name3', 'DescriptionAndActors3', 'newGenre3', 'newCountry3', 'newDuration3', Photo 
FROM OPENROWSET(BULK N'D:\image\b.png', SINGLE_BLOB) AS ImageSource(Photo);

INSERT INTO dbo.Cinemas(Id, [Name], Adress,  Photo)
SELECT 1, 'CinemasName1', 'CinemasAdress1', Photo 
FROM OPENROWSET(BULK N'D:\image\oktober.jpg', SINGLE_BLOB) AS ImageSource(Photo);

INSERT INTO dbo.Cinemas(Id, [Name], Adress,  Photo)
SELECT 4, 'CinemasName4', 'CinemasAdress4', Photo 
FROM OPENROWSET(BULK N'D:\image\oktober.jpg', SINGLE_BLOB) AS ImageSource(Photo);

INSERT INTO dbo.Cinemas(Id, [Name], Adress,  Photo)
SELECT 3, 'CinemasName3', 'CinemasAdress3', Photo 
FROM OPENROWSET(BULK N'D:\image\oktober.jpg', SINGLE_BLOB) AS ImageSource(Photo);

INSERT INTO dbo.Cinemas(Id, [Name], Adress,  Photo)
SELECT 4, 'Name4', 'Adress4', Photo 
FROM OPENROWSET(BULK N'D:\image\oktober.jpg', SINGLE_BLOB) AS ImageSource(Photo);

INSERT INTO dbo.ConcertHalls(Id, [Name], Adress,  Photo)
SELECT 1, 'ConcertHallsName1', 'ConcertHallsAdress1', Photo 
FROM OPENROWSET(BULK N'D:\image\arena.jpg', SINGLE_BLOB) AS ImageSource(Photo);

INSERT INTO dbo.ConcertHalls(Id, [Name], Adress,  Photo)
SELECT 2, 'ConcertHallsName2', 'ConcertHallsAdress2', Photo 
FROM OPENROWSET(BULK N'D:\image\arena.jpg', SINGLE_BLOB) AS ImageSource(Photo);

INSERT INTO dbo.Concerts(Id, [Name], [Description], [Time], Genre, Photo)
SELECT 1, 'ConcertName1', 'Description1', 'Time1', 'Genre1', Photo 
FROM OPENROWSET(BULK N'D:\image\skriptonit.jpg', SINGLE_BLOB) AS ImageSource(Photo);

INSERT INTO dbo.Concerts(Id, [Name], [Description], [Time], Genre, Photo)
SELECT 2, 'ConcertName2', 'Description2', 'Time2', 'Genre2', Photo 
FROM OPENROWSET(BULK N'D:\image\palina.jpg', SINGLE_BLOB) AS ImageSource(Photo);

go
alter procedure AddConcertHalls
@newId int,
@newName varchar(50),
@newAddress varchar(70),
@newPhoto varbinary(MAX)
as
begin
	 insert into ConcertHalls(Id, [Name], Adress, Photo) values (dbo.CheckIdConcertHalls(@newId), @newName, @newAddress, @newPhoto);
end;
go
create procedure AddDate
@newId int,
@newDate date
as
begin
	 insert into Calendar(Id, [Date]) values (dbo.CheckIdCalendar(), @newDate);
end;
go


CREATE PROCEDURE AddBM 
@newId int,
@newUserMail varchar(50),
@newFilmsName varchar(50),
@newDate date
AS
BEGIN
	insert into BookedMovies(Id,UserId,FilmId,DateId)
	values(dbo.CheckIdBookedMovies(@newId), dbo.SelectIdUsers(@newUserMail), dbo.SelectIdFilms(@newFilmsName), dbo.SelectIdDate(@newDate))
END;
go

create PROCEDURE SelectAllCinemas
AS
BEGIN
    select * from Cinemas;
END;
go
create PROCEDURE SelectAllConcerts
AS
BEGIN
    select * from Concerts;
END;
go
create PROCEDURE SelectAllMIC
AS
BEGIN
    select distinct t1.Id, t2.Date, t4.Name, t3.Name, t1.Price, t1.Time, t1.FreeSpaces, t1.ReservedSpaces 
	from MoviesInCinemas as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join Cinemas as t3 on (t1.CinemasId = t3.Id) 
	inner join Films as t4 on (t1.FilmsId = t4.Id)
END;

go
create PROCEDURE SelectAllCICH
AS
BEGIN
    select distinct t1.Id, t2.Date, t4.Name, t3.Name, t1.Price, t1.FreeSpaces, t1.ReservedSpaces 
	from ConcertsInConcertHalls as t1 
	inner join Calendar as t2 on (t1.DateID = t2.Id)
	inner join ConcertHalls as t3 on (t1.ConcertsHallsId = t3.Id) 
	inner join Concerts as t4 on (t1.ConcertsId = t4.Id)
END;

go
create PROCEDURE SelectAllBM
AS
BEGIN
    select distinct t1.Id, t4.[E-mail], t3.Name, t2.Date
	from BookedMovies as t1 
	inner join Calendar as t2 on (t1.DateId = t2.Id)
	inner join Films as t3 on (t1.FilmId = t3.Id) 
	inner join Users as t4 on (t1.UserId = t4.Id)
END;
go
create PROCEDURE SelectAllBC
AS
BEGIN
    select distinct t1.Id, t4.[E-mail], t3.Name, t2.Date
	from BookedConcerts as t1 
	inner join Calendar as t2 on (t1.DateId = t2.Id)
	inner join Concerts as t3 on (t1.ConcertId = t3.Id) 
	inner join Users as t4 on (t1.UserId = t4.Id)
END;
go
create PROCEDURE SelectAllDates
AS
BEGIN
    select * from Calendar;
END;
go
create PROCEDURE SelectAllFilms
AS
BEGIN
    select * from Films;
END;
go
create PROCEDURE SelectAllConcertHalls
AS
BEGIN
    select * from ConcertHalls;
END;
go
CREATE PROCEDURE SelectAllUsers 
AS
BEGIN
    select * from Users;
END;

exec SelectAllUsers;

go

CREATE PROCEDURE AddBC 
@newId int,
@newUserMail varchar(50),
@newConcertsName varchar(50),
@newDate date
AS
BEGIN
	insert into BookedConcerts(Id,UserId,ConcertId,DateId)
	values(dbo.CheckIdBookedConcerts(@newId), dbo.SelectIdUsers(@newUserMail), dbo.SelectIdConcerts(@newConcertsName), dbo.SelectIdDate(@newDate))
END;

go
CREATE PROCEDURE SearchFilms 
@searchString varchar(50)
AS
BEGIN
	select * from Films where [Name] = @searchString
END;

SearchCinemas
go
CREATE PROCEDURE SearchCinemas 
@searchString varchar(50)
AS
BEGIN
	select * from Cinemas where [Name] = @searchString
END;

go
CREATE PROCEDURE SearchConcerts 
@searchString varchar(50)
AS
BEGIN
	select * from Concerts where [Name] = @searchString
END;
go
CREATE PROCEDURE SearchConcertHalls 
@searchString varchar(50)
AS
BEGIN
	select * from ConcertHalls where [Name] = @searchString
END;

drop procedure ChangeBK
go
create procedure ChangeBM
	@Id int, 
	@newDate date,
	@newFilmsName varchar(50),
	@newUserMail varchar(50) as
	begin
		update BookedMovies
		set DateId = dbo.SelectIdDate(@newDate),
		FilmId = dbo.SelectIdFilms(@newFilmsName),
		UserId = dbo.SelectIdUsers(@newUserMail)
		where [Id] = @Id
	end;
go
create procedure ChangeBC
	@Id int, 
	@newDate date,
	@newConcertsName varchar(50),
	@newUserMail varchar(50) as
	begin
		update BookedConcerts
		set DateId = dbo.SelectIdDate(@newDate),
		ConcertId = dbo.SelectIdConcerts(@newConcertsName),
		UserId = dbo.SelectIdUsers(@newUserMail)
		where [Id] = @Id
	end;
go
insert into Users(Id,[E-mail],[Name],[Password])
values (2,'Alex','Alex',pwdencrypt('Alex'))


--procedur--------------------------------------------------------------------------

--export----------------------------------------------------------------------------
exec master.dbo.sp_configure 'show advanced options', 1;
RECONFIGURE;
exec master.dbo.sp_configure 'xp_cmdshell', 1;
RECONFIGURE;
------------------
go
create function ExportToXMLFIlms(@path nvarchar(500))
returns int as 
begin
	declare @path2 nvarchar(50) = 'D:\films.xml';
	declare @sql nvarchar(500) = 'BCP "SELECT * FROM AfishaEvent.dbo.Films FOR XML PATH(''Film''), ROOT(''Films'')" QUERYOUT "D:\Films.xml" -r -t -T -w -S .\SQLEXPRESS';	
		EXEC xp_cmdshell @sql;
	return 1;
end;

create function ExportToXMLTable(@path nvarchar(500), @tableName nvarchar(100))
returns int as 
begin
	declare @fullTableName nvarchar(100) = 'AfishaEvent.dbo.' + @tableName;
	declare @sql nvarchar(500) = 'BCP "SELECT * FROM  '+@fullTableName+' FOR XML PATH(''Order''), ROOT(''Root'')" QUERYOUT '+@path+' -r -t -T -w -S .\SQLEXPRESS';	
		EXEC xp_cmdshell @sql;
	return 1;
end;

select dbo.ExportToXMLTable('D:\XMLAfishaEvent\Film.xml', 'Calendar');

go
create procedure ExportToXML
	@path nvarchar(500)
as
begin
  declare @films int
  declare @cinemas int
  declare @moviesInCinemas int
  declare @concerts int
  declare @concertHalls int
  declare @concertInConcertHall int
  declare @bookedMovies int
  declare @bookedConcerts int
  declare @users int
  declare @calendar int

  set @films = dbo.ExportToXMLTable(@path + 'Film.xml', 'Films');
  set @cinemas = dbo.ExportToXMLTable(@path + 'Cinemas.xml', 'Cinemas');
  set @moviesInCinemas = dbo.ExportToXMLTable(@path + 'MoviesInCinemas.xml', 'MoviesInCinemas');
  set @concerts = dbo.ExportToXMLTable(@path + 'Concerts.xml', 'Concerts');
  set @concertHalls = dbo.ExportToXMLTable(@path + 'ConcertHalls.xml', 'ConcertHalls');
  set @concertInConcertHall = dbo.ExportToXMLTable(@path + 'ConcertsInConcertHalls.xml', 'ConcertsInConcertHalls');
  set @bookedMovies = dbo.ExportToXMLTable(@path + 'BookedMovies.xml', 'BookedMovies');
  set @bookedConcerts = dbo.ExportToXMLTable(@path + 'BookedConcerts.xml', 'BookedConcerts');
  set @users = dbo.ExportToXMLTable(@path + 'Users.xml', 'Users');
  set @calendar = dbo.ExportToXMLTable(@path + 'Calendar.xml', 'Calendar');
end;

exec dbo.ExportToXML 'D:\XMLAfishaEvent\';

--import----------------------------------------------------------------------------

create procedure ImportFromXmlFilms
@path nvarchar(500) as
begin
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)='SELECT CAST(x AS XML) FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
	
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into [Films]([Id],Name,DescriptionAndActors,Photo,Genre, Country, Duration)
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Name[1]', 'varchar(50)') AS [Name],
		P.value('DescriptionAndActors[1]', 'varchar(50)') AS DescriptionAndActors,
		P.value('Photo[1]', 'varbinary(max)') AS Photo,
		P.value('Genre[1]', 'varchar(50)') AS Genre,
		P.value('Country[1]', 'varchar(50)') AS Country,
		P.value('Duration[1]', 'varchar(30)') AS Duration
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go

create procedure ImportFromXmlCinemas
@path nvarchar(500) as
begin
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)='SELECT  CAST(x AS XML) FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into [Cinemas]([Id],[Name],[Adress],[Photo])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Name[1]', 'varchar(50)') AS [Name],
		P.value('Adress[1]', 'varchar(70)') AS [Adress],
		P.value('Photo[1]', 'varbinary(max)') AS Photo
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go

alter procedure ImportFromXmlMIC
@path nvarchar(500) as
begin
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)='SELECT CAST(x AS XML) FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into MoviesInCinemas([Id],DateID,FilmsId,CinemasId,Price,[Time],[FreeSpaces],[ReservedSpaces])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('DateID[1]', 'int') AS DateID,
		P.value('FilmsId[1]', 'int') AS FilmsId,
		P.value('CinemasId[1]', 'int') AS CinemasId,
		P.value('Price[1]', 'int') AS Price,
		P.value('Time[1]', 'varchar(50)') AS [Time],
		P.value('FreeSpaces[1]', 'int') AS [FreeSpaces],
		P.value('ReservedSpaces[1]', 'int') AS [ReservedSpaces]
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;

go

create procedure ImportFromXmlConcerts
@path nvarchar(500) as
begin
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)='SELECT CAST(x AS XML) FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 

	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into Concerts([Id],[Name],[Description],[Time],Photo,Genre)
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Name[1]', 'varchar(50)') AS [Name],
		P.value('Description[1]', 'varchar(70)') AS [Description],
		P.value('Time[1]', 'varchar(50)') AS [Time],
		P.value('Photo[1]', 'varbinary(max)') AS Photo,
		P.value('Genre[1]', 'varchar(50)') AS Genre	
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;

create procedure ImportFromXmlConcertHalls
@path nvarchar(500) as
begin
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)='SELECT CAST(x AS XML) FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into ConcertHalls([Id],[Name],[Adress],[Photo])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Name[1]', 'varchar(50)') AS [Name],
		P.value('Adress[1]', 'varchar(70)') AS [Adress],
		P.value('Photo[1]', 'varbinary(max)') AS Photo	
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go


create procedure ImportFromXmlCICH
@path nvarchar(500) as
begin
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)='SELECT CAST(x AS XML) FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into ConcertsInConcertHalls([Id],DateID,ConcertsId,ConcertsHallsId,Price,[FreeSpaces],[ReservedSpaces])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('DateID[1]', 'int') AS DateID,
		P.value('ConcertsId[1]', 'int') AS ConcertsId,
		P.value('ConcertsHallsId[1]', 'int') AS ConcertsHallsId,
		P.value('Price[1]', 'int') AS Price,
		P.value('FreeSpaces[1]', 'int') AS [FreeSpaces],
		P.value('ReservedSpaces[1]', 'int') AS [ReservedSpaces]
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go

create procedure ImportFromXmlBM
@path nvarchar(500) as
begin
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)='SELECT CAST(x AS XML) FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into BookedMovies([Id],UserId,FilmId,DateId)
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('UserId[1]', 'int') AS UserId,
		P.value('FilmId[1]', 'int') AS FilmId,
		P.value('DateId[1]', 'int') AS DateId	
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;


create procedure ImportFromXmlBC
@path nvarchar(500) as
begin
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)='SELECT CAST(x AS XML) FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
 
	INSERT INTO @results EXEC (@sql) 

	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into BookedConcerts([Id],UserId,ConcertId,DateId)
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('UserId[1]', 'int') AS UserId,
		P.value('ConcertId[1]', 'int') AS ConcertId,
		P.value('DateId[1]', 'int') AS DateId	
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;
go



create procedure ImportFromXmlCalendar
@path nvarchar(500) as
begin
	SET XACT_ABORT ON  
	BEGIN TRAN
	declare @results table (x xml)			
	declare @sql nvarchar(300)='SELECT CAST(x AS XML) FROM OPENROWSET(BULK '''+@path+''', SINGLE_BLOB) AS T(x)'; 
	INSERT INTO @results EXEC (@sql) 
	declare @xml XML = (SELECT  TOP 1 x from  @results);
	insert into Calendar([Id],[Date])
		SELECT 
		P.value('Id[1]', 'int') AS Id,
		P.value('Date[1]', 'date') AS [Date]
		FROM @xml.nodes('Root/Order') AS T3(P) 
	COMMIT;
end;

exec dbo.ImportFromXmlCalendar 'D:\Calendar.xml';



create procedure ImportFromXML
as
begin
  exec dbo.ImportFromXmlFilms 'D:\XMLAfishaEventImport\Film.xml'
  exec dbo.ImportFromXmlCinemas 'D:XMLAfishaEventImport\Cinemas.xml'
  exec dbo.ImportFromXmlCalendar 'D:\XMLAfishaEventImport\Calendar.xml'
  exec dbo.ImportFromXmlMIC 'D:\XMLAfishaEventImport\MoviesInCinemas.xml'
  exec dbo.ImportFromXmlConcerts 'D:\XMLAfishaEventImport\Concerts.xml'
  exec dbo.ImportFromXmlConcertHalls 'D:\XMLAfishaEventImport\ConcertHalls.xml'
  exec dbo.ImportFromXmlCICH 'D:\XMLAfishaEventImport\ConcertsInConcertHalls.xml'
  exec dbo.ImportFromXmlBM 'D:\XMLAfishaEventImport\BookedMovies.xml'
  exec dbo.ImportFromXmlBC 'D:\XMLAfishaEventImport\BookedConcerts.xml'
end;

exec dbo.ImportFromXML;


go 

DECLARE @counter int;  
SET @counter = 100;  
WHILE @counter < 200
BEGIN
	INSERT INTO MoviesInCinemas (id, DateID, FilmsId, CinemasId, Price, Time, FreeSpaces, ReservedSpaces)
    VALUES
           (@counter,
		    ABS(CHECKSUM(NewId())) % 7 + 1,
			ABS(CHECKSUM(NewId())) % 7 + 1,
			ABS(CHECKSUM(NewId())) % 12 + 1,
			ABS(CHECKSUM(NewId())) % 5 + 5,
			ABS(CHECKSUM(NewId())) % 12 + 8,
			ABS(CHECKSUM(NewId())) % 50 + 50,
			ABS(CHECKSUM(NewId())) % 50) ;
			set @counter = @counter + 1   
END;

select * from MoviesInCinemas;

DECLARE @counter int;  
SET @counter = 51;  
WHILE @counter <= 150
BEGIN
	INSERT INTO ConcertsInConcertHalls (id, DateID, ConcertsId, ConcertsHallsId, Price, FreeSpaces, ReservedSpaces)
    VALUES
           (@counter,
		    ABS(CHECKSUM(NewId())) % 7 + 1,
			ABS(CHECKSUM(NewId())) % 9 + 1,
			ABS(CHECKSUM(NewId())) % 6 + 1,
			ABS(CHECKSUM(NewId())) % 50 + 8,
			ABS(CHECKSUM(NewId())) % 200 + 100,
			ABS(CHECKSUM(NewId())) % 88) ;
			set @counter = @counter + 1   
END;

select * from ConcertsInConcertHalls;

select * from ConcertsInConcertHalls where DateID = 3 and ConcertsHallsId = 2;


DECLARE @counter SMALLINT;  
SET @counter = 1;  
WHILE @counter < 5  
   BEGIN  
      SELECT RAND() Random_Number  
      SET @counter = @counter + 1  
   END;  
GO  

select ABS(CHECKSUM(NewId())) % 2 + 1;

select * from films where Name = 'Довод';
select * from MoviesInCinemas;


set statistics io on;
set statistics time on;



DECLARE @counter int;  
DECLARE @password_user varchar(255);
DECLARE @username varchar(255);
SET @counter = 3;  
WHILE @counter <= 100000
BEGIN
	set @password_user = CONVERT(varchar(255), NEWID()); 
	set @username = SUBSTRING(CONVERT(varchar(255), NEWID()), 0, 4);
	insert into Users(Id,[E-mail],[Name],[Password])
		values (
			@counter,
			CONVERT(varchar(255), NEWID()),
			@username,
			pwdencrypt(@password_user)
		)
		set @counter = @counter + 1   
END;

select * from Users where Name = '09D';
select * from Users where id = 45263;


drop index IX_Users_Name on Users;

create index IX_Users_Name on Users (Name);

select * from Users where Id = '100001';

delete from Users where Id > 3;
go

CREATE TRIGGER BookedMovies_after_insert
ON BookedMovies
AFTER INSERT
AS
IF  EXISTS (SELECT id FROM MoviesInCinemas where FreeSpaces < ReservedSpaces)
begin
	update MoviesInCinemas set ReservedSpaces = FreeSpaces where Id = (SELECT id FROM MoviesInCinemas where FreeSpaces < ReservedSpaces)
end;

go

CREATE TRIGGER BookedConcerts_after_insert
ON BookedConcerts
AFTER INSERT
AS
IF  EXISTS (SELECT id FROM ConcertsInConcertHalls where FreeSpaces < ReservedSpaces)
begin
	update ConcertsInConcertHalls set ReservedSpaces = FreeSpaces where Id = (SELECT id FROM ConcertsInConcertHalls where FreeSpaces < ReservedSpaces)
end;


