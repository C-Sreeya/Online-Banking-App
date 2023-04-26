create database OnlineBankingSystemDb
use OnlineBankingSystemDb;


------ Customers Table ----------
create table Customers( Customer_ID int primary key,
						Customer_Name varchar(15),
						Customer_Address varchar(30),
						Customer_Ph_No varchar(10),
						Customer_Age int,
						DOB datetime);


insert into Customers values
(5,'Varsha','TS','9515487051',20,'10-24-2003');
(4,'Siri','AP','9515487051',18,'10-24-2003');
(1,'Deepak','Ranchi','6876656576',22,'12-08-2000'),
(2,'Yadav','Airoli','7776656576',23,'08-03-2002'),
(3,'Shreya','Patna','9876656576',20,'12-30-2002');




----- Account Type Table----------------
create table AccountType (  Account_Type_id int primary key,
							Acct_Type varchar(15),
							Min_Balance float,
							Interest int,Transaction_limit int);

insert into AccountType values
(1,'Saving',10000,5,100000),
(2,'Current',1000,3,50000);

----Account table -----------------
create table Accounts(  Account_no varchar(15) primary key,
						Customer_ID int not null foreign key references Customers(Customer_ID),
						IFSC varchar(20) not null,
						Account_Type_id int foreign key references AccountType(Account_Type_id),
						Balance int,
						Branch varchar(20),
						UserType varchar(10));

insert into Accounts values
('969846875432',5,'HDFC',1,10000,'hyd','Customer');
('969846357656',4,'Canara',2,5000,'AP','Admin');
('463846383476',1,'HDFC',1,5678,'Mumbai','Admin'),
('163846309476',2,'HDFC',2,99922,'Patna','Customer'),
('969846383476',3,'KVB',2,1234,'Delhi','Admin');
insert into Accounts values
('677846383476',3,'KVB',1,500,'Delhi','Admin');


select * from Accounts



-- Transaction table -------

create table Transactions ( Transaction_id int primary key identity(100,1),
							Customer_id int not null foreign key references Customers(Customer_ID),
							Account_no varchar(15) not null foreign key references Accounts(Account_no),
							Receiver_AccountNo varchar(15),
							Amount int, 
							DebitOrCredit char,
							Date_of_Transaction datetime, 
							Transaction_Status varchar(10), 
							check (DebitOrCredit='+' or DebitOrCredit='-'),
							);
--drop table Transactions;

alter table transactions alter column Amount 

alter table Transactions add ReceiverUserName varchar(20);

insert into Transactions
values (1,'463846383476','969846383476',5678,'+','06-23-2033','Success'),
(2,'969846383476','463846383476',5678,'-','06-13-2023','Success')

update Transactions set Customer_id=3 where Transaction_id=101

select * from Transactions;

truncate table Transactions

--- Loan Table -----
create table Loans(Loan_Id int primary key identity(222,1),
Customer_ID int not null foreign key references Customers(Customer_ID),
Account_no varchar(15) not null foreign key references Accounts(Account_no),
Amount int,
Loan_Date date,
DurationInMonths int,
Loan_Status varchar(15),
Approval_Status varchar(15));




insert into Loans values
(111,1,'463846383476',20000,'06/06/2023',15,'Active','Applied'),
(113,2,'163846309476',60000,'12/11/2021',36,'Completed','Approved');



select * from Customers;
select * from AccountType;
select * from Accounts;
select * from Transactions;
select * from Loans;

drop table Customers;
drop table AccountType;
drop table Accounts;
drop table Transactions;
drop table Loans;

create table UserCredentials(UserName varchar(20) primary key not null,
Password varchar(20) not null,
CustomerId int,
MobileNo varchar(11),
CreatedDate datetime not null,
ModifiedDate datetime,
UserRole varchar(15));

insert into UserCredentials values('Shreya','Shre',1,'645345','Admin')

select * from UserCredentials

truncate table UserCredentials











