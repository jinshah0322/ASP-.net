create database QandA

use QandA

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);

select * from Users
update Users set Role='Admin' where UserID=2

delete from Users where UserID=5
drop table Users

INSERT INTO Users (Username, Password, Email, Role)
VALUES ('teacher1', 'Teacher@123', 'teacher1@example.com', 'Teacher'),
       ('teacher2', 'Teacher@456', 'teacher2@example.com', 'Teacher'),
	   ('student1', 'Student@123', 'student1@example.com', 'Student'),
       ('student2', 'Student@456', 'student2@example.com', 'Student'),
       ('admin', 'Admin1@123', 'admin@example.com', 'Admin');



CREATE TABLE QuestionPapers (
	QuestionPaperID INT PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(100) NOT NULL,
	Description NVARCHAR(MAX),
	CreationDate DATE NOT NULL DEFAULT GETDATE(),
	Status NVARCHAR(50) default 'Draft' ,
	CreatorID INT, -- Foreign key referencing Users table
	CONSTRAINT FK_QuestionPaper_Creator FOREIGN KEY (CreatorID) REFERENCES Users(UserID)
);

delete from QuestionPapers
select * from QuestionPapers

UPDATE QuestionPapers
SET CreatorID = 1
WHERE QuestionPaperID=1;

ALTER TABLE QuestionPapers
DROP COLUMN Status;

ALTER TABLE QuestionPapers
DROP COLUMN CreationDate;

ALTER TABLE QuestionPapers
ADD Status NVARCHAR(50) DEFAULT 'Pending' ;

delete from QuestionPapers where QuestionPaperID=6;

drop table QuestionPapers



INSERT INTO QuestionPapers (Title, Description, Status, CreatorID)
VALUES 
    ('Mathematics Quiz', 'A quiz covering various topics in mathematics.', 'Approved', 6),
    ('Science Exam', 'An exam on scientific concepts including physics, chemistry, and biology.', 'Pending', 6),
    ('History Test', 'A test on historical events and figures from around the world.', 'Pending', 6),
    ('English Literature Quiz', 'A quiz on famous works of literature and literary devices.', 'Pending', 6),
    ('Geography Assessment', 'An assessment covering geographical features, maps, and regions.', 'Approved', 6);

select * from QuestionPapers


CREATE TABLE Questions (
    QuestionID INT PRIMARY KEY IDENTITY(1,1),
    QuestionPaperID INT,
    QuestionText NVARCHAR(MAX) NOT NULL,
    OptionA NVARCHAR(MAX),
    OptionB NVARCHAR(MAX),
    OptionC NVARCHAR(MAX),
    OptionD NVARCHAR(MAX),
    CorrectAnswer NVARCHAR(MAX) NOT NULL,
    CONSTRAINT FK_Question_QuestionPaper FOREIGN KEY (QuestionPaperID) REFERENCES QuestionPapers(QuestionPaperID)
);

drop table Questions

delete from Questions ;

select * from Questions

UPDATE Questions
SET QuestionPaperID = 1
WHERE QuestionID = 1;


CREATE TABLE Submission (
    SubmissionID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT, -- Foreign key referencing Users table
    QuestionPaperID INT, -- Foreign key referencing QuestionPaper table
    QuestionID INT, -- Foreign key referencing Questions table
    TickedAnswer NVARCHAR(100), -- Assuming the ticked answer can be a string
    SubmissionDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Submission_User FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT FK_Submission_QuestionPaper FOREIGN KEY (QuestionPaperID) REFERENCES QuestionPapers(QuestionPaperID),
    CONSTRAINT FK_Submission_Question FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID)
);

ALTER TABLE Submission
ADD isCorrect BIT;

delete from Submission where QuestionPaperID=6

select * from Submission

delete from Submission

delete from Use

SELECT *
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';