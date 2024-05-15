CREATE DATABASE SurpriseCalendarDB;
GO

USE SurpriseCalendarDB;
GO

CREATE TABLE SurpriseCalendar (
    Id INT PRIMARY KEY IDENTITY,
    UserId INT,
    [Row] INT NOT NULL,
    [Column] INT NOT NULL,
    IsOpen BIT NOT NULL DEFAULT 0,
    PrizeAmount INT
);
