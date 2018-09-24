USE [master]
GO
/****** Object:  Database [GContaDB]    Script Date: 03/05/2018 22:23:31 ******/
CREATE DATABASE [GContaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GContaDB', FILENAME = N'C:\Users\ivan\GContaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GContaDB_log', FILENAME = N'C:\Users\ivan\GContaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GContaDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GContaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GContaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GContaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GContaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GContaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GContaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [GContaDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GContaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GContaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GContaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GContaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GContaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GContaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GContaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GContaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GContaDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GContaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GContaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GContaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GContaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GContaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GContaDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [GContaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GContaDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GContaDB] SET  MULTI_USER 
GO
ALTER DATABASE [GContaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GContaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GContaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GContaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GContaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GContaDB] SET QUERY_STORE = OFF
GO
USE [GContaDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [GContaDB]
GO
/****** Object:  Table [dbo].[Conta]    Script Date: 03/05/2018 22:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conta](
	[idConta] [int] IDENTITY(1,1) NOT NULL,
	[dataCriacao] [datetime2](7) NOT NULL,
	[flagAtivo] [bit] NOT NULL,
	[idPessoa] [int] NOT NULL,
	[limiteSaqueDiario] [decimal](19, 2) NOT NULL,
	[saldo] [decimal](19, 2) NOT NULL,
	[tipoConta] [int] NOT NULL,
 CONSTRAINT [PK_Conta] PRIMARY KEY CLUSTERED 
(
	[idConta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 03/05/2018 22:23:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoa](
	[idPessoa] [int] IDENTITY(1,1) NOT NULL,
	[cpf] [char](11) NOT NULL,
	[dataNascimento] [datetime2](7) NOT NULL,
	[nome] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
(
	[idPessoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacao]    Script Date: 03/05/2018 22:23:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacao](
	[idTransacao] [int] IDENTITY(1,1) NOT NULL,
	[dataTransacao] [datetime2](7) NOT NULL,
	[idConta] [int] NOT NULL,
	[valor] [decimal](19, 2) NOT NULL,
 CONSTRAINT [PK_Transacao] PRIMARY KEY CLUSTERED 
(
	[idTransacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Conta_idPessoa]    Script Date: 03/05/2018 22:23:32 ******/
CREATE NONCLUSTERED INDEX [IX_Conta_idPessoa] ON [dbo].[Conta]
(
	[idPessoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transacao_idConta]    Script Date: 03/05/2018 22:23:32 ******/
CREATE NONCLUSTERED INDEX [IX_Transacao_idConta] ON [dbo].[Transacao]
(
	[idConta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Conta]  WITH CHECK ADD  CONSTRAINT [FK_Conta_Pessoa_idPessoa] FOREIGN KEY([idPessoa])
REFERENCES [dbo].[Pessoa] ([idPessoa])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Conta] CHECK CONSTRAINT [FK_Conta_Pessoa_idPessoa]
GO
ALTER TABLE [dbo].[Transacao]  WITH CHECK ADD  CONSTRAINT [FK_Transacao_Conta_idConta] FOREIGN KEY([idConta])
REFERENCES [dbo].[Conta] ([idConta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transacao] CHECK CONSTRAINT [FK_Transacao_Conta_idConta]
GO
USE [master]
GO
ALTER DATABASE [GContaDB] SET  READ_WRITE 
GO
