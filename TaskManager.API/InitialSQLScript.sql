-- Table creation script for TodoTask
CREATE TABLE TodoTask
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    CreatedDate DATETIME NOT NULL,
    DueDate DATETIME NOT NULL
);
