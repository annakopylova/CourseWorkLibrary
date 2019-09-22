
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/14/2019 02:42:25
-- Generated from EDMX file: D:\Конструирование ПО\Lib\DAL\LibraryDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Library];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StudentLibraryCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet_Student] DROP CONSTRAINT [FK_StudentLibraryCard];
GO
IF OBJECT_ID(N'[dbo].[FK_LibraryCardBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookSet] DROP CONSTRAINT [FK_LibraryCardBook];
GO
IF OBJECT_ID(N'[dbo].[FK_Student_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet_Student] DROP CONSTRAINT [FK_Student_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Employee_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet_Employee] DROP CONSTRAINT [FK_Employee_inherits_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[BookSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookSet];
GO
IF OBJECT_ID(N'[dbo].[LibraryCardSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LibraryCardSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet_Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet_Student];
GO
IF OBJECT_ID(N'[dbo].[UserSet_Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet_Employee];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [FIO] nvarchar(max)  NOT NULL,
    [Admin] bit  NOT NULL
);
GO

-- Creating table 'BookSet'
CREATE TABLE [dbo].[BookSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [PublicationDate] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [LibraryCard_Id] int  NULL
);
GO

-- Creating table 'LibraryCardSet'
CREATE TABLE [dbo].[LibraryCardSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateIssue] datetime  NOT NULL
);
GO

-- Creating table 'UserSet_Student'
CREATE TABLE [dbo].[UserSet_Student] (
    [Group] nvarchar(max)  NOT NULL,
    [Course] int  NOT NULL,
    [Faculty] nvarchar(max)  NOT NULL,
    [RegistrationPacket] int  NOT NULL,
    [Id] int  NOT NULL,
    [LibraryCard_Id] int  NOT NULL
);
GO

-- Creating table 'UserSet_Employee'
CREATE TABLE [dbo].[UserSet_Employee] (
    [BadgeNumber] nvarchar(max)  NOT NULL,
    [Post] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BookSet'
ALTER TABLE [dbo].[BookSet]
ADD CONSTRAINT [PK_BookSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LibraryCardSet'
ALTER TABLE [dbo].[LibraryCardSet]
ADD CONSTRAINT [PK_LibraryCardSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet_Student'
ALTER TABLE [dbo].[UserSet_Student]
ADD CONSTRAINT [PK_UserSet_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet_Employee'
ALTER TABLE [dbo].[UserSet_Employee]
ADD CONSTRAINT [PK_UserSet_Employee]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [LibraryCard_Id] in table 'UserSet_Student'
ALTER TABLE [dbo].[UserSet_Student]
ADD CONSTRAINT [FK_StudentLibraryCard]
    FOREIGN KEY ([LibraryCard_Id])
    REFERENCES [dbo].[LibraryCardSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentLibraryCard'
CREATE INDEX [IX_FK_StudentLibraryCard]
ON [dbo].[UserSet_Student]
    ([LibraryCard_Id]);
GO

-- Creating foreign key on [LibraryCard_Id] in table 'BookSet'
ALTER TABLE [dbo].[BookSet]
ADD CONSTRAINT [FK_LibraryCardBook]
    FOREIGN KEY ([LibraryCard_Id])
    REFERENCES [dbo].[LibraryCardSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LibraryCardBook'
CREATE INDEX [IX_FK_LibraryCardBook]
ON [dbo].[BookSet]
    ([LibraryCard_Id]);
GO

-- Creating foreign key on [Id] in table 'UserSet_Student'
ALTER TABLE [dbo].[UserSet_Student]
ADD CONSTRAINT [FK_Student_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'UserSet_Employee'
ALTER TABLE [dbo].[UserSet_Employee]
ADD CONSTRAINT [FK_Employee_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------