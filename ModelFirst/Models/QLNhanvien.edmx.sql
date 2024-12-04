
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/15/2023 19:01:26
-- Generated from EDMX file: E:\LDUDWeb\ModelFirst\Models\QLNhanvien.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QLNhanvien_ModelFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Nhanvien'
CREATE TABLE [dbo].[Nhanvien] (
    [manhanvien] int IDENTITY(1,1) NOT NULL,
    [tennhanvien] nvarchar(max)  NOT NULL,
    [ngaysinh] datetime  NOT NULL,
    [luong] decimal(18,0)  NOT NULL,
    [hinhanh] nvarchar(max)  NOT NULL,
    [maphong] int  NOT NULL
);
GO

-- Creating table 'Phongban'
CREATE TABLE [dbo].[Phongban] (
    [maphong] int IDENTITY(1,1) NOT NULL,
    [tenphong] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [manhanvien] in table 'Nhanvien'
ALTER TABLE [dbo].[Nhanvien]
ADD CONSTRAINT [PK_Nhanvien]
    PRIMARY KEY CLUSTERED ([manhanvien] ASC);
GO

-- Creating primary key on [maphong] in table 'Phongban'
ALTER TABLE [dbo].[Phongban]
ADD CONSTRAINT [PK_Phongban]
    PRIMARY KEY CLUSTERED ([maphong] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [maphong] in table 'Nhanvien'
ALTER TABLE [dbo].[Nhanvien]
ADD CONSTRAINT [fk_nhanvien_phongban]
    FOREIGN KEY ([maphong])
    REFERENCES [dbo].[Phongban]
        ([maphong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_nhanvien_phongban'
CREATE INDEX [IX_fk_nhanvien_phongban]
ON [dbo].[Nhanvien]
    ([maphong]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------