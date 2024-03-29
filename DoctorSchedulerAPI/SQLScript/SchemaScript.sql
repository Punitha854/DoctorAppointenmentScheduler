USE [master]
GO
/****** Object:  Database [MedicalManagement]    Script Date: 27/09/2019 17:34:22 ******/
CREATE DATABASE [MedicalManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MedicalManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MedicalManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MedicalManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MedicalManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MedicalManagement] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MedicalManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MedicalManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MedicalManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MedicalManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MedicalManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MedicalManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [MedicalManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MedicalManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MedicalManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MedicalManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MedicalManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MedicalManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MedicalManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MedicalManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MedicalManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MedicalManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MedicalManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MedicalManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MedicalManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MedicalManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MedicalManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MedicalManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MedicalManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MedicalManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MedicalManagement] SET  MULTI_USER 
GO
ALTER DATABASE [MedicalManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MedicalManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MedicalManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MedicalManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MedicalManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MedicalManagement] SET QUERY_STORE = OFF
GO
USE [MedicalManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/09/2019 17:34:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 27/09/2019 17:34:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DoctorId] [bigint] NOT NULL,
	[PatientId] [bigint] NOT NULL,
	[AppFrom] [datetime2](7) NOT NULL,
	[AppTo] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Diseases]    Script Date: 27/09/2019 17:34:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diseases](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Diseases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 27/09/2019 17:34:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Degree] [nvarchar](max) NULL,
	[Specialization] [nvarchar](max) NULL,
	[Qualification] [nvarchar](max) NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 27/09/2019 17:34:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[DiseaseId] [bigint] NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointment_DoctorId]    Script Date: 27/09/2019 17:34:22 ******/
CREATE NONCLUSTERED INDEX [IX_Appointment_DoctorId] ON [dbo].[Appointment]
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointment_PatientId]    Script Date: 27/09/2019 17:34:22 ******/
CREATE NONCLUSTERED INDEX [IX_Appointment_PatientId] ON [dbo].[Appointment]
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Patients_DiseaseId]    Script Date: 27/09/2019 17:34:22 ******/
CREATE NONCLUSTERED INDEX [IX_Patients_DiseaseId] ON [dbo].[Patients]
(
	[DiseaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Doctors_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Doctors_DoctorId]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Patients_PatientId]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Diseases_DiseaseId] FOREIGN KEY([DiseaseId])
REFERENCES [dbo].[Diseases] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Diseases_DiseaseId]
GO
USE [master]
GO
ALTER DATABASE [MedicalManagement] SET  READ_WRITE 
GO
