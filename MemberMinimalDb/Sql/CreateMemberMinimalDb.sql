USE [master]
GO

/****** Object:  Database [MemberMinimalDb]    Script Date: 2022-10-30 17:23:00 ******/
CREATE DATABASE [MemberMinimalDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MemberMinimalDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\MemberMinimalDb_Primary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MemberMinimalDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\MemberMinimalDb_Primary.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MemberMinimalDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MemberMinimalDb] SET ANSI_NULL_DEFAULT ON 
GO

ALTER DATABASE [MemberMinimalDb] SET ANSI_NULLS ON 
GO

ALTER DATABASE [MemberMinimalDb] SET ANSI_PADDING ON 
GO

ALTER DATABASE [MemberMinimalDb] SET ANSI_WARNINGS ON 
GO

ALTER DATABASE [MemberMinimalDb] SET ARITHABORT ON 
GO

ALTER DATABASE [MemberMinimalDb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MemberMinimalDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET CURSOR_DEFAULT  LOCAL 
GO

ALTER DATABASE [MemberMinimalDb] SET CONCAT_NULL_YIELDS_NULL ON 
GO

ALTER DATABASE [MemberMinimalDb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET QUOTED_IDENTIFIER ON 
GO

ALTER DATABASE [MemberMinimalDb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MemberMinimalDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MemberMinimalDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET RECOVERY FULL 
GO

ALTER DATABASE [MemberMinimalDb] SET  MULTI_USER 
GO

ALTER DATABASE [MemberMinimalDb] SET PAGE_VERIFY NONE  
GO

ALTER DATABASE [MemberMinimalDb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MemberMinimalDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MemberMinimalDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [MemberMinimalDb] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MemberMinimalDb] SET QUERY_STORE = OFF
GO

USE [MemberMinimalDb]
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE [MemberMinimalDb] SET  READ_WRITE 
GO


