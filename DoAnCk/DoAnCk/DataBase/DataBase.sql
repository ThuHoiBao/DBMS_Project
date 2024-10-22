CREATE DATABASE EnglishCourse_DataBase;
GO

USE EnglishCourse_DataBase;
GO

CREATE TABLE Owner (
    id INT IDENTITY(1,1) CONSTRAINT PK_Owner PRIMARY KEY,
    userName VARCHAR(50) NOT NULL,
    passWork VARCHAR(255) NOT NULL,
    type VARCHAR(20) NOT NULL,
    fullName VARCHAR(100) NOT NULL,
    email VARCHAR(200) NOT NULL UNIQUE
);

CREATE TABLE Teacher (
    id INT IDENTITY(1,1) CONSTRAINT PK_Teacher PRIMARY KEY,  
    idOwner INT NOT NULL,  
    userName VARCHAR(50) NOT NULL UNIQUE,  
    password VARCHAR(255) NOT NULL,  
    email VARCHAR(200) NOT NULL UNIQUE,  
    fullName VARCHAR(100) NOT NULL,
    certificate VARCHAR(255) NOT NULL, 
    experience INT NOT NULL, 
    avatar VARCHAR(255) NOT NULL, 
    type VARCHAR(50) NOT NULL,  
    CONSTRAINT FK_Teacher_Owner FOREIGN KEY (idOwner) REFERENCES Owner(id),
    CONSTRAINT CK_Experience CHECK (experience >= 0)
);
CREATE TABLE Course ( 
    id NVARCHAR(10) CONSTRAINT PK_Course PRIMARY KEY, 
    name NVARCHAR(50) NOT NULL, 
    description NVARCHAR(500), 
	timeLession NVARCHAR(50) NOT NULL, 
	price INT NOT NULL,
    totalLession INT NOT NULL, 
    totalStudent INT NOT NULL,
    idTeacher INT NOT NULL,
    CONSTRAINT FK_Course_Teacher FOREIGN KEY (idTeacher) REFERENCES Teacher(id),
    CONSTRAINT CK_TotalLession CHECK (totalLession >= 0), 
CONSTRAINT CK_TotalStudent CHECK (totalStudent >= 0),
CONSTRAINT CK_Price CHECK (price >= 0)
);
CREATE TABLE Student (
    id INT IDENTITY(1,1) CONSTRAINT PK_Student PRIMARY KEY,  
    userName VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,  
    fullName VARCHAR(100) NOT NULL,
    email VARCHAR(200) NOT NULL UNIQUE,
    phoneNumber VARCHAR(10) NULL,  
    dateOfBirth DATE NOT NULL,  
    target VARCHAR(255) NOT NULL, 
    address VARCHAR(255) NOT NULL, 
    avatar IMAGE NOT NULL, 
    type VARCHAR(50) NOT NULL, 
    CONSTRAINT CK_PhoneNumber_Length CHECK (LEN(phoneNumber) = 10)
);
CREATE TABLE Document (
    id INT IDENTITY(1,1) CONSTRAINT PK_Document PRIMARY KEY,
    idCourse NVARCHAR(10) NOT NULL,
    name NVARCHAR(100) NOT NULL,
    Date DATE,
    content NVARCHAR(MAX),  
    CONSTRAINT FK_Document_Course FOREIGN KEY (idCourse) REFERENCES Course(id)
);
CREATE TABLE Register (
    id INT IDENTITY(1,1) CONSTRAINT PK_RegisterCourse PRIMARY KEY,
    status VARCHAR(100) NOT NULL,
    date DATE,
    idStudent INT NOT NULL,
    idCourse NVARCHAR(10) NOT NULL,
    CONSTRAINT FK_RegisterCourse_Student FOREIGN KEY (idStudent) REFERENCES Student(id),
    CONSTRAINT FK_RegisterCourse_Course FOREIGN KEY (idCourse) REFERENCES Course(id)
);