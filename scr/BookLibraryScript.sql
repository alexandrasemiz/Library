USE [master]
GO
/****** Object:  Database [BookLibrary]    Script Date: 07/17/2015 10:04:18 ******/
CREATE DATABASE [BookLibrary] ON  PRIMARY 
( NAME = N'BookLibrary', FILENAME = N'D:\MSSQL DataBases\BookLibrary.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookLibrary_log', FILENAME = N'D:\MSSQL DataBases\BookLibrary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookLibrary] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookLibrary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookLibrary] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BookLibrary] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BookLibrary] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BookLibrary] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BookLibrary] SET ARITHABORT OFF
GO
ALTER DATABASE [BookLibrary] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [BookLibrary] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BookLibrary] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BookLibrary] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BookLibrary] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BookLibrary] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BookLibrary] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BookLibrary] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BookLibrary] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BookLibrary] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BookLibrary] SET  DISABLE_BROKER
GO
ALTER DATABASE [BookLibrary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BookLibrary] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BookLibrary] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BookLibrary] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BookLibrary] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BookLibrary] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BookLibrary] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BookLibrary] SET  READ_WRITE
GO
ALTER DATABASE [BookLibrary] SET RECOVERY SIMPLE
GO
ALTER DATABASE [BookLibrary] SET  MULTI_USER
GO
ALTER DATABASE [BookLibrary] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BookLibrary] SET DB_CHAINING OFF
GO
USE [BookLibrary]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 07/17/2015 10:04:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[Id_book] [int] NOT NULL,
	[Avtor] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
