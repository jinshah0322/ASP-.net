use EmployeeDB;

CREATE TABLE Employee1 (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Gender NVARCHAR(6) CHECK (Gender IN ('Male', 'Female')),
    State NVARCHAR(50),
    City NVARCHAR(50),
    Email NVARCHAR(100),
    DOB DATE,
    PhoneNumber NVARCHAR(20),
    InterestedTechnology NVARCHAR(100),
	PreviousPost NVARCHAR(100)
);

select * from Employee1

delete from Employee1 where EmployeeID=-1;

drop table Employee1
