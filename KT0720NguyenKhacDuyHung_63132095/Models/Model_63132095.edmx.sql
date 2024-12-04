
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/19/2023 12:27:59
-- Generated from EDMX file: E:\LDUDWeb\KT0720NguyenKhacDuyHung_63132095\Models\Model_63132095.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KT0720_63132095];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_lop_sinhvien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SINHVIEN] DROP CONSTRAINT [fk_lop_sinhvien];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[LOP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LOP];
GO
IF OBJECT_ID(N'[dbo].[SINHVIEN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SINHVIEN];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LOP'
CREATE TABLE [dbo].[LOP] (
    [Malop] varchar(20)  NOT NULL,
    [Tenlop] nvarchar(30)  NULL
);
GO

-- Creating table 'SINHVIEN'
CREATE TABLE [dbo].[SINHVIEN] (
    [MaSV] varchar(20)  NOT NULL,
    [HoSV] nvarchar(20)  NULL,
    [TenSV] nvarchar(20)  NULL,
    [Ngsinh] datetime  NULL,
    [Gioitinh] bit  NULL,
    [AnhSV] varchar(max)  NULL,
    [Dchi] nvarchar(50)  NULL,
    [Malop] varchar(20)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Malop] in table 'LOP'
ALTER TABLE [dbo].[LOP]
ADD CONSTRAINT [PK_LOP]
    PRIMARY KEY CLUSTERED ([Malop] ASC);
GO

-- Creating primary key on [MaSV] in table 'SINHVIEN'
ALTER TABLE [dbo].[SINHVIEN]
ADD CONSTRAINT [PK_SINHVIEN]
    PRIMARY KEY CLUSTERED ([MaSV] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Malop] in table 'SINHVIEN'
ALTER TABLE [dbo].[SINHVIEN]
ADD CONSTRAINT [fk_lop_sinhvien]
    FOREIGN KEY ([Malop])
    REFERENCES [dbo].[LOP]
        ([Malop])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_lop_sinhvien'
CREATE INDEX [IX_fk_lop_sinhvien]
ON [dbo].[SINHVIEN]
    ([Malop]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------