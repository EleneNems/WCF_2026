USE LibraryManagementDB;
GO

IF OBJECT_ID('Loans', 'U') IS NOT NULL DROP TABLE Loans;
IF OBJECT_ID('Readers', 'U') IS NOT NULL DROP TABLE Readers;
IF OBJECT_ID('Books', 'U') IS NOT NULL DROP TABLE Books;
IF OBJECT_ID('Authors', 'U') IS NOT NULL DROP TABLE Authors;
IF OBJECT_ID('Categories', 'U') IS NOT NULL DROP TABLE Categories;
GO

CREATE TABLE Authors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(150) NOT NULL UNIQUE
);
GO

CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,

    Title NVARCHAR(200) NOT NULL,
    ISBN NVARCHAR(50) NOT NULL UNIQUE,
    PublishYear INT NOT NULL,

    CategoryId INT NOT NULL,
    AuthorId INT NOT NULL,

    TotalQuantity INT NOT NULL,
    AvailableQuantity INT NOT NULL,

    CONSTRAINT FK_Books_Categories
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id),

    CONSTRAINT FK_Books_Authors
        FOREIGN KEY (AuthorId) REFERENCES Authors(Id),

    CONSTRAINT CK_Books_TotalQuantity
        CHECK (TotalQuantity >= 1),

    CONSTRAINT CK_Books_AvailableQuantity
        CHECK (AvailableQuantity >= 0 AND AvailableQuantity <= TotalQuantity)
);
GO

CREATE TABLE Readers (
    Id INT IDENTITY(1,1) PRIMARY KEY,

    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    PersonalNumber NVARCHAR(20) NOT NULL UNIQUE,
    Phone NVARCHAR(30) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    RegistrationDate DATETIME2 NOT NULL DEFAULT GETDATE(),

    -- 1 = Active, 2 = Blocked, 3 = Cancelled
    Status INT NOT NULL DEFAULT 1,

    CONSTRAINT CK_Readers_Status CHECK (Status IN (1,2,3))
);
GO

CREATE TABLE Loans (
    Id INT IDENTITY(1,1) PRIMARY KEY,

    ReaderId INT NOT NULL,
    BookId INT NOT NULL,

    LoanDate DATETIME2 NOT NULL,
    DueDate DATETIME2 NOT NULL,
    ReturnDate DATETIME2 NULL,

    -- 1 = Good, 2 = Damaged, 3 = Lost
    ReturnCondition INT NULL,

    IsReturned BIT NOT NULL DEFAULT 0,
    FineAmount DECIMAL(18,2) NOT NULL DEFAULT 0,

    CONSTRAINT FK_Loans_Readers
        FOREIGN KEY (ReaderId) REFERENCES Readers(Id),

    CONSTRAINT FK_Loans_Books
        FOREIGN KEY (BookId) REFERENCES Books(Id),

    CONSTRAINT CK_Loans_ReturnCondition
        CHECK (ReturnCondition IS NULL OR ReturnCondition IN (1,2,3))
);
GO

INSERT INTO Authors (FullName)
VALUES
(N'J.K. Rowling'),
(N'J.R.R. Tolkien'),
(N'Robert C. Martin'),
(N'Abraham Silberschatz'),
(N'Thomas H. Cormen'),
(N'George Orwell'),
(N'Harper Lee'),
(N'F. Scott Fitzgerald');
GO

INSERT INTO Categories (Name)
VALUES
(N'Fantasy'),
(N'Programming'),
(N'Database'),
(N'Computer Science'),
(N'Dystopian'),
(N'Classic');
GO

INSERT INTO Books
(
    Title,
    ISBN,
    PublishYear,
    CategoryId,
    AuthorId,
    TotalQuantity,
    AvailableQuantity
)
VALUES
(N'Harry Potter and the Philosopher''s Stone', N'9780747532699', 1997, 1, 1, 5, 5),
(N'The Hobbit', N'9780261102217', 1937, 1, 2, 4, 4),
(N'Clean Code', N'9780132350884', 2008, 2, 3, 3, 3),
(N'Database System Concepts', N'9780073523323', 2010, 3, 4, 2, 2),
(N'Introduction to Algorithms', N'9780262033848', 2009, 4, 5, 2, 2),
(N'1984', N'9780451524935', 1949, 5, 6, 6, 6),
(N'To Kill a Mockingbird', N'9780061120084', 1960, 6, 7, 4, 4),
(N'The Great Gatsby', N'9780743273565', 1925, 6, 8, 3, 3);
GO

INSERT INTO Readers
(
    FirstName,
    LastName,
    PersonalNumber,
    Phone,
    Email,
    RegistrationDate,
    Status
)
VALUES
(N'Nino', N'Beridze', N'01001001001', N'555111222', N'nino@gmail.com', GETDATE(), 1),
(N'Giorgi', N'Kapanadze', N'01001001002', N'555222333', N'giorgi@gmail.com', GETDATE(), 1),
(N'Mariam', N'Gelashvili', N'01001001003', N'555333444', N'mariam@gmail.com', GETDATE(), 1),
(N'Davit', N'Nozadze', N'01001001004', N'555444555', N'davit@gmail.com', GETDATE(), 2),
(N'Ana', N'Lomidze', N'01001001005', N'555555666', N'ana@gmail.com', GETDATE(), 3);
GO

INSERT INTO Loans
(
    ReaderId,
    BookId,
    LoanDate,
    DueDate,
    ReturnDate,
    ReturnCondition,
    IsReturned,
    FineAmount
)
VALUES
(1, 1, DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, 9, GETDATE()), NULL, NULL, 0, 0),
(2, 3, DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, -6, GETDATE()), NULL, NULL, 0, 6),
(3, 6, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, 4, GETDATE()), GETDATE(), 1, 1, 0),
(1, 2, DATEADD(DAY, -18, GETDATE()), DATEADD(DAY, -4, GETDATE()), GETDATE(), 2, 1, 4),
(2, 7, DATEADD(DAY, -25, GETDATE()), DATEADD(DAY, -11, GETDATE()), GETDATE(), 3, 1, 11);
GO
UPDATE Books
SET AvailableQuantity = AvailableQuantity - 1
WHERE Id IN (1, 3);

UPDATE Books
SET
    TotalQuantity = TotalQuantity - 1,
    AvailableQuantity = AvailableQuantity - 1
WHERE Id = 7;
GO
SELECT * FROM Authors;
SELECT * FROM Categories;
SELECT * FROM Books;
SELECT * FROM Readers;
SELECT * FROM Loans;
GO