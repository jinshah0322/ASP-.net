create database QandA

use QandA

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Role NVARCHAR(50) NOT NULL
);

select * from Users
delete from Users where UserID=4

INSERT INTO Users (Username, Password, Email, Role)
VALUES ('teacher1', 'Teacher@123', 'teacher1@example.com', 'Teacher'),
       ('teacher2', 'Teacher@456', 'teacher2@example.com', 'Teacher'),
	   ('student1', 'Student@123', 'student1@example.com', 'Student'),
       ('student2', 'student456', 'student2@example.com', 'Student'),
       ('admin', 'admin123', 'admin@example.com', 'Admin');



CREATE TABLE QuestionPapers (
	QuestionPaperID INT PRIMARY KEY IDENTITY(1,1),
	Title NVARCHAR(100) NOT NULL,
	Description NVARCHAR(MAX),
	CreationDate DATETIME NOT NULL DEFAULT GETDATE(),
	Status NVARCHAR(50) NOT NULL ,
	CreatorID INT, -- Foreign key referencing Users table
	CONSTRAINT FK_QuestionPaper_Creator FOREIGN KEY (CreatorID) REFERENCES Users(UserID)
);

select * from QuestionPapers

ALTER TABLE QuestionPapers
DROP COLUMN Status;

ALTER TABLE QuestionPapers
ADD Status NVARCHAR(50) DEFAULT 'Pending' ;

delete from QuestionPapers


INSERT INTO QuestionPapers (Title, Description, Status, CreatorID)
VALUES 
    ('Mathematics Quiz', 'A quiz covering various topics in mathematics.', 'Approved', 6),
    ('Science Exam', 'An exam on scientific concepts including physics, chemistry, and biology.', 'Pending', 6),
    ('History Test', 'A test on historical events and figures from around the world.', 'Pending', 6),
    ('English Literature Quiz', 'A quiz on famous works of literature and literary devices.', 'Pending', 6),
    ('Geography Assessment', 'An assessment covering geographical features, maps, and regions.', 'Approved', 6);


CREATE TABLE Questions (
    QuestionID INT PRIMARY KEY IDENTITY(1,1),
    QuestionPaperID INT,
    QuestionText NVARCHAR(MAX) NOT NULL,
    OptionA NVARCHAR(MAX),
    OptionB NVARCHAR(MAX),
    OptionC NVARCHAR(MAX),
    OptionD NVARCHAR(MAX),
    CorrectAnswer NVARCHAR(1) NOT NULL,
    CONSTRAINT FK_Question_QuestionPaper FOREIGN KEY (QuestionPaperID) REFERENCES QuestionPapers(QuestionPaperID)
);

select * from Questions


--CREATE TABLE Submission (
--    SubmissionID INT PRIMARY KEY IDENTITY(1,1),
--    UserID INT, -- Foreign key referencing Users table
--    QuestionPaperID INT, -- Foreign key referencing QuestionPaper table
--    SubmissionDate DATETIME NOT NULL DEFAULT GETDATE(),
--    CONSTRAINT FK_Submission_User FOREIGN KEY (UserID) REFERENCES Users(UserID),
--    CONSTRAINT FK_Submission_QuestionPaper FOREIGN KEY (QuestionPaperID) REFERENCES QuestionPaper(QuestionPaperID)
--);
