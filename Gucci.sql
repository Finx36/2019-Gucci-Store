set ansi_padding on
go
set ansi_nulls on
go
set quoted_identifier on
go

CREATE DATABASE [Gucci4]
GO

use [Gucci4]
go

create table [dbo].[Worker_Position]
(
 [ID_Position] [int] not null identity(1,1),
 [Position] [varchar] (40) not null,
 [Salary] [Int] not null,
 constraint [PK_Graph] primary key clustered
 ([ID_Position] ASC) on [PRIMARY]
)
go
create procedure [dbo].[Worker_Position_insert]
@Position [varchar] (40), @Salary [int]
as
	insert into [dbo].[Worker_Position] ([Position], [Salary])
	values (@Position, @Salary)
go
create procedure [dbo].[Worker_Position_update]
@ID_Position [int], @Position [varchar] (40), @Salary [int]
as
	update [dbo].[Worker_Position] set 
	[Position] = @Position, 
	[Salary] = @Salary
	where [ID_Position] = @ID_Position
go
create procedure [dbo].[Worker_Position_delete]
@ID_Position [int]
as
	delete from [dbo].[Worker_Position] 
	where [ID_Position] = @ID_Position
go
create table [dbo].[Sotrudniki]
(
[ID_Sotrudnik] [int] not null identity(1,1),
[Surname] [varchar] (40) not null,
[Name] [varchar] (40) not null,
[Middle_Name] [varchar] (40) not null,
[Date_Of_Birth] [varchar] (40) not null,
[Passport_Number] [int] not null,
[Passport_Series] [int] not null,
[User_Name] [varchar] (40) not null,
[Password] [varchar] (40) not null,
[Position_ID] [int] not null,
constraint [PK_Sotrudniki] primary key clustered
 ([ID_Sotrudnik] ASC) on [PRIMARY],
 constraint [FK_Sotrudniki_Position] foreign key ([Position_ID])
 references [dbo].[Worker_Position] ([ID_Position])
)
go
create procedure [dbo].[Sotrudniki_insert]
@Surname [varchar] (40), @Name [varchar] (40), @Middle_Name [varchar] (40), @Date_OF_Birth [varchar] (40),
@Passport_Number [int], @Passport_Series [int], @User_Name [varchar] (40), @Password [varchar] (40), @Position_ID [int]
as
	insert into [dbo].[Sotrudniki] ([Surname], [Name], [Middle_Name], [Date_Of_Birth], [Passport_Number], [Passport_Series], [User_Name], [Password], [Position_ID])
	values (@Surname, @Name, @Middle_Name, @Date_OF_Birth, @Passport_Number, @Passport_Series, @User_Name, @Password, @Position_ID)
go
create procedure [dbo].[Sotrudniki_update]
@ID_Sotrudnik [int],@Surname [varchar] (40), @Name [varchar] (40), @Middle_Name [varchar] (40), @Date_OF_Birth [varchar] (40),
@Passport_Number [int], @Passport_Series [int], @User_Name [varchar] (40), @Password [varchar] (40), @Position_ID [int]
as
	update [dbo].[Sotrudniki] set
	[Surname] = @Surname, 
	[Name] = @Name, 
	[Middle_Name] = @Middle_Name, 
	[Date_Of_Birth] = @Date_OF_Birth, 
	[Passport_Number] = @Passport_Number, 
	[Passport_Series] = @Passport_Series, 
	[User_Name] = @User_Name, 
	[Password] = @Password, 
	[Position_ID] = @Position_ID
	where [ID_Sotrudnik] = @ID_Sotrudnik
go
create procedure [dbo].[Sotrudniki_delete]
@ID_Sotrudnik [int]
as
	delete from [dbo].[Sotrudniki]
	where [ID_Sotrudnik] = @ID_Sotrudnik
go
create table [dbo].[Product]
(
 [ID_Product] [int] not null identity(1,1),
 [Product_Name] [varchar] (40) not null,
 [Price] [int] not null,
 [Type_Of_Product] [varchar] (40) not null,
 constraint [PK_Product] primary key clustered
 ([ID_Product] ASC) on [PRIMARY]
)
go
create procedure [dbo].[Product_insert]
@Product_Name [varchar] (40), @Price [int], @Type_Of_Product [varchar] (40)
as
	insert into [dbo].[Product] ([Product_Name], [Price], [Type_Of_Product])
	values (@Product_Name, @Price, @Type_Of_Product)
go
create procedure [dbo].[Product_update]
@ID_Product [int], @Product_Name [varchar] (40), @Price [int], @Type_Of_Product [varchar] (40)
as
	update [dbo].[Product] set
	[Product_Name] = @Product_Name,
	[Price] = @Price, 
	[Type_Of_Product] = @Type_Of_Product
	where [ID_Product] = @ID_Product
go
create procedure [dbo].[Product_delete]
@ID_Product [int], @Product_Name [varchar] (40), @Price [int], @Type_Of_Product [varchar] (40)
as
	delete from [dbo].[Product] 	
	where [ID_Product] = @ID_Product
go
create table [dbo].[Sales_Results]
(
[ID_Result] [int] not null identity(1,1),
[Product_Revenue] [Int] not null,
[Count_Sold] [Int] not null,
[Consumption_Of_Product] [Int] not null,
[Product_ID] [Int] not null,
constraint [PK_Worker_Position] primary key clustered
 ([ID_Result] ASC) on [PRIMARY],
 constraint [FK_Results_Product] foreign key ([Product_ID])
 references [dbo].[Product] ([ID_Product])
)
go
create procedure [dbo].[Sales_Results_insert]
@Product_Revenue [Int], @Count_Sold [Int], @Consumption_Of_Product [Int], @Product_ID [Int]
as
	insert into [dbo].Sales_Results ([Product_Revenue], [Count_Sold], [Consumption_Of_Product], [Product_ID])
	values (@Product_Revenue, @Count_Sold, @Consumption_Of_Product, @Product_ID)
go
go
create procedure [dbo].[Sales_Results_update]
@ID_Result [int], @Product_Revenue [Int], @Count_Sold [Int], @Consumption_Of_Product [Int], @Product_ID [Int]
as
	update [dbo].Sales_Results set
	[Product_Revenue] = @Product_Revenue, 
	[Count_Sold] = @Count_Sold, 
	[Consumption_Of_Product] = @Consumption_Of_Product, 
	[Product_ID] = @Product_ID
	where [ID_Result] = @ID_Result
go
create procedure [dbo].[Sales_Results_delete]
@ID_Result [int]
as
	delete from [dbo].Sales_Results 
	where [ID_Result] = @ID_Result
go
create table [dbo].[Projects]
(
[ID_Project] [int] not null identity(1,1),
[Name_Of_Project] [varchar] (40) not null,
[Cost] [int] not null,
[Duration] [varchar] (40) not null,
[Sotrudnik_ID] [int] not null,
[Result_ID] [int] not null,
constraint [PK_Projects] primary key clustered
 ([ID_Project] ASC) on [PRIMARY],
 constraint [FK_Projects_Sotrudniki] foreign key ([Sotrudnik_ID])
 references [dbo].[Sotrudniki] ([ID_Sotrudnik]),
 constraint [FK_Worker_Information_Position] foreign key ([Result_ID])
 references [dbo].[Sales_Results] ([ID_Result])
)
go
create procedure [dbo].[Projects_insert]
@Name_Of_Project [varchar] (40), @Cost [int], @Duration [varchar] (40), @Sotrudnik_ID [int], @Result_ID [int]
as
	insert into [dbo].[Projects] ([Name_Of_Project], [Cost], [Duration], [Sotrudnik_ID], [Result_ID])
	values (@Name_Of_Project, @Cost, @Duration, @Sotrudnik_ID, @Result_ID)
go
create procedure [dbo].[Projects_update]
@ID_Project [int], @Name_Of_Project [varchar] (40), @Cost [int], @Duration [varchar] (40), @Sotrudnik_ID [int], @Result_ID [int]
as
	update [dbo].[Projects] set 
	[Name_Of_Project] = @Name_Of_Project, 
	[Cost] = @Cost, 
	[Duration] = @Duration, 
	[Sotrudnik_ID] = @Sotrudnik_ID, 
	[Result_ID] = @Result_ID
	where [ID_Project] = @ID_Project
go
create procedure [dbo].[Projects_delete]
@ID_Project [int]
as
	delete from [dbo].[Projects] 
	where [ID_Project] = @ID_Project
go