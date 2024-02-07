USE EmployeeDB;

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName NVARCHAR(50) NOT NULL,
    DepartmentHead VARCHAR(50) NOT NULL,
    Budget DECIMAL(15, 2),
    CreationDate DATE,
    IsActive BIT default 1,
);

INSERT INTO Departments (DepartmentName, DepartmentHead, Budget, CreationDate)
VALUES 
('Marketing', 'John Doe', 50000.00, '2023-01-15'),
('Human Resources', 'Jane Smith', 60000.00, '2023-02-28'),
('Finance', 'Mike Johnson', 75000.00, '2023-03-10'),
('IT', 'Emily Brown', 80000.00, '2023-04-22'),
('Operations', 'David Wilson', 70000.00, '2023-05-05');

select * from Departments

delete from Departments 
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE,
    Gender NVARCHAR(10) CHECK (Gender IN ('Male', 'Female')), 
    Salary DECIMAL(10, 2),
    JoiningDate DATETIME,
    DepartmentID INT,
	InterestedTechnologies NVARCHAR(MAX),
	State NVARCHAR(10),
	City NVARCHAR(10),
    CONSTRAINT FK_Department_Employee FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

select * from Employees
select -1 as EmployeeID, '--select--' as name union all select EmployeeID,CONCAT(FirstName,' ',LastName) as name from Employees

CREATE TABLE Salaries (
    SalaryID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT,
    Amount DECIMAL(10, 2) NOT NULL,
    SalaryType VARCHAR(20),
	Bonus DECIMAL(10, 2),
	FinalSalary DECIMAL(10, 2),
    CONSTRAINT FK_Employee_Salaries FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY IDENTITY(1,1),
    ProjectName NVARCHAR(50) NOT NULL,
    ProjectManager VARCHAR(50),
    StartDate DATE,
    EndDate DATE,
    Budget DECIMAL(15, 2),
    IsActive BIT
);

select * from Projects

CREATE TABLE EmployeeProject (
	EPID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT,
    ProjectID INT,
    AssignmentDate DATETIME,
    HoursWorked INT,
    Status NVARCHAR(50),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID),
);

drop table EmployeeProject

CREATE TABLE State (
    StateID INT PRIMARY KEY IDENTITY(1,1),
    StateName VARCHAR(255) NOT NULL
);


INSERT INTO State (StateName) VALUES
('Andhra Pradesh'),
('Arunachal Pradesh'),
('Assam'),
('Bihar'),
('Chhattisgarh'),
('Goa'),
('Gujarat'),
('Haryana'),
('Himachal Pradesh'),
('Jharkhand'),
('Karnataka'),
('Kerala'),
('Madhya Pradesh'),
('Maharashtra'),
('Manipur'),
('Meghalaya'),
('Mizoram'),
('Nagaland'),
('Odisha'),
('Punjab'),
('Rajasthan'),
('Sikkim'),
('Tamil Nadu'),
('Telangana'),
('Tripura'),
('Uttar Pradesh'),
('Uttarakhand'),
('West Bengal');

CREATE TABLE City (
    CityID INT PRIMARY KEY IDENTITY(1,1),
    StateID INT FOREIGN KEY REFERENCES State(StateID),
    CityName VARCHAR(255) NOT NULL
);

INSERT INTO City (StateID, CityName) VALUES
-- Andhra Pradesh
(1, 'Hyderabad'), (1, 'Visakhapatnam'), (1, 'Vijayawada'), (1, 'Guntur'), (1, 'Nellore'),
-- Arunachal Pradesh
(2, 'Itanagar'), (2, 'Naharlagun'), (2, 'Pasighat'), (2, 'Namsai'), (2, 'Bomdila'),
-- Assam
(3, 'Guwahati'), (3, 'Silchar'), (3, 'Dibrugarh'), (3, 'Jorhat'), (3, 'Tezpur'),
-- Bihar
(4, 'Patna'), (4, 'Gaya'), (4, 'Bhagalpur'), (4, 'Muzaffarpur'), (4, 'Darbhanga'),
-- Chhattisgarh
(5, 'Raipur'), (5, 'Bhilai'), (5, 'Durg'), (5, 'Bilaspur'), (5, 'Korba'),
-- Goa
(6, 'Panaji'), (6, 'Vasco da Gama'), (6, 'Mapusa'), (6, 'Margao'), (6, 'Ponda'),
-- Gujarat
(7, 'Ahmedabad'), (7, 'Surat'), (7, 'Vadodara'), (7, 'Rajkot'), (7, 'Bhavnagar'),
-- Haryana
(8, 'Faridabad'), (8, 'Gurgaon'), (8, 'Panipat'), (8, 'Ambala'), (8, 'Hisar'),
-- Himachal Pradesh
(9, 'Shimla'), (9, 'Solan'), (9, 'Dharamshala'), (9, 'Kullu'), (9, 'Mandi'),
-- Jharkhand
(10, 'Ranchi'), (10, 'Jamshedpur'), (10, 'Dhanbad'), (10, 'Bokaro Steel City'), (10, 'Hazaribagh'),
-- Karnataka
(11, 'Bangalore'), (11, 'Mysore'), (11, 'Hubli'), (11, 'Mangalore'), (11, 'Belgaum'),
-- Kerala
(12, 'Thiruvananthapuram'), (12, 'Kochi'), (12, 'Kozhikode'), (12, 'Thrissur'), (12, 'Alappuzha'),
-- Madhya Pradesh
(13, 'Bhopal'), (13, 'Indore'), (13, 'Jabalpur'), (13, 'Gwalior'), (13, 'Ujjain'),
-- Maharashtra
(14, 'Mumbai'), (14, 'Pune'), (14, 'Nagpur'), (14, 'Nashik'), (14, 'Aurangabad'),
-- Manipur
(15, 'Imphal'), (15, 'Thoubal'), (15, 'Churachandpur'), (15, 'Bishnupur'), (15, 'Kakching'),
-- Meghalaya
(16, 'Shillong'), (16, 'Tura'), (16, 'Nongstoin'), (16, 'Jowai'), (16, 'Williamnagar'),
-- Mizoram
(17, 'Aizawl'), (17, 'Lunglei'), (17, 'Champhai'), (17, 'Saiha'), (17, 'Kolasib'),
-- Nagaland
(18, 'Kohima'), (18, 'Dimapur'), (18, 'Mokokchung'), (18, 'Tuensang'), (18, 'Wokha'),
-- Odisha
(19, 'Bhubaneswar'), (19, 'Cuttack'), (19, 'Rourkela'), (19, 'Berhampur'), (19, 'Sambalpur'),
-- Punjab
(20, 'Ludhiana'), (20, 'Amritsar'), (20, 'Jalandhar'), (20, 'Patiala'), (20, 'Bathinda'),
-- Rajasthan
(21, 'Jaipur'), (21, 'Jodhpur'), (21, 'Udaipur'), (21, 'Kota'), (21, 'Bikaner'),
-- Sikkim
(22, 'Gangtok'), (22, 'Namchi'), (22, 'Mangan'), (22, 'Rangpo'), (22, 'Soreng'),
-- Tamil Nadu
(23, 'Chennai'), (23, 'Coimbatore'), (23, 'Madurai'), (23, 'Tiruchirappalli'), (23, 'Salem'),
-- Telangana
(24, 'Hyderabad'), (24, 'Warangal'), (24, 'Nizamabad'), (24, 'Karimnagar'), (24, 'Khammam'),
-- Tripura
(25, 'Agartala'), (25, 'Dharmanagar'), (25, 'Udaipur'), (25, 'Ambassa'), (25, 'Kailashahar'),
-- Uttar Pradesh
(26, 'Lucknow'), (26, 'Kanpur'), (26, 'Agra'), (26, 'Varanasi'), (26, 'Allahabad'),
-- Uttarakhand
(27, 'Dehradun'), (27, 'Haridwar'), (27, 'Rishikesh'), (27, 'Haldwani'), (27, 'Kashipur'),
-- West Bengal
(28, 'Kolkata'), (28, 'Howrah'), (28, 'Durgapur'), (28, 'Asansol'), (28, 'Siliguri');