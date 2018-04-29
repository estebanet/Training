
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/29/2018 00:57:49
-- Generated from EDMX file: C:\Users\estebangaro\Documents\GitHub\Training\TaskParallelLibrary-Training\Leccion4_Utilizando Bloqueos_WcfSample\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [demoBD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

--IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
--    DROP TABLE [dbo].[Usuarios];
--GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuarios'
--CREATE TABLE [dbo].[Usuarios] (
--    [Id] int IDENTITY(1,1) NOT NULL,
--    [Nombre] nvarchar(max)  NOT NULL,
--    [UltimaSesion] datetime  NOT NULL
--);
GO

-- Creating table 'Sesions'
CREATE TABLE [dbo].[Sesions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [IsActive] bit  NOT NULL,
    [UsuarioId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Usuarios'
--ALTER TABLE [dbo].[Usuarios]
--ADD CONSTRAINT [PK_Usuarios]
--    PRIMARY KEY CLUSTERED ([Id] ASC);
--GO

-- Creating primary key on [Id] in table 'Sesions'
ALTER TABLE [dbo].[Sesions]
ADD CONSTRAINT [PK_Sesions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsuarioId] in table 'Sesions'
ALTER TABLE [dbo].[Sesions]
ADD CONSTRAINT [FK_UsuarioSesion]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioSesion'
CREATE INDEX [IX_FK_UsuarioSesion]
ON [dbo].[Sesions]
    ([UsuarioId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------