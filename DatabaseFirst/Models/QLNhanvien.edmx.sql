
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/15/2023 13:06:13
-- Generated from EDMX file: E:\LDUDWeb\DatabaseFirst\Models\QLNhanvien.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QLNhanvien_DatabaseFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_nhanvien_phongban]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Nhanvien] DROP CONSTRAINT [fk_nhanvien_phongban];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Nhanvien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nhanvien];
GO
IF OBJECT_ID(N'[dbo].[Phongban]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Phongban];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Nhanvien'
CREATE TABLE [dbo].[Nhanvien] (
    [manhanvien] int  NOT NULL,
    [tennhanvien] nvarchar(30)  NULL,
    [ngaysinh] datetime  NULL,
    [luong] decimal(18,0)  NULL,
    [hinhanh] varchar(max)  NULL,
    [maphong] int  NULL
);
GO

-- Creating table 'Phongban'
CREATE TABLE [dbo].[Phongban] (
    [maphong] int  NOT NULL,
    [tenphong] nvarchar(20)  NULL
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