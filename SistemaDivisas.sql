USE [master]
GO
/****** Object:  Database [bancomunicadosDB]    Script Date: 9/6/2022 03:50:58 ******/
CREATE DATABASE [bancomunicadosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bancomunicadosDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\bancomunicadosDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bancomunicadosDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\bancomunicadosDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [bancomunicadosDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bancomunicadosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bancomunicadosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bancomunicadosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bancomunicadosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bancomunicadosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bancomunicadosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bancomunicadosDB] SET  MULTI_USER 
GO
ALTER DATABASE [bancomunicadosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bancomunicadosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bancomunicadosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bancomunicadosDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bancomunicadosDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bancomunicadosDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [bancomunicadosDB] SET QUERY_STORE = OFF
GO
USE [bancomunicadosDB]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [nvarchar](50) NULL,
	[contrasenia] [nvarchar](50) NULL,
	[nombre] [nvarchar](50) NULL,
	[apellido] [nvarchar](50) NULL,
	[DNI] [int] NULL,
	[direccion] [nvarchar](50) NULL,
	[ciudad] [nvarchar](50) NULL,
	[provincia] [nvarchar](50) NULL,
	[pais] [nvarchar](50) NULL,
	[telefono] [int] NULL,
	[login] [bit] NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuentaCripto]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentaCripto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clienteId] [int] NOT NULL,
	[UUID] [nvarchar](50) NULL,
	[saldo] [float] NULL,
 CONSTRAINT [PK_cuentaCripto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuentaDolar]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentaDolar](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clienteId] [int] NOT NULL,
	[CBU] [bigint] NULL,
	[aliasCBU] [nvarchar](50) NULL,
	[numeroCuenta] [int] NULL,
	[saldo] [float] NULL,
 CONSTRAINT [PK_cuentaDolar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuentaPeso]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentaPeso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clienteId] [int] NULL,
	[CBU] [bigint] NULL,
	[aliasCBU] [nvarchar](50) NULL,
	[numeroCuenta] [int] NULL,
	[saldo] [float] NULL,
 CONSTRAINT [PK_cuentaPeso] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[registroMovimiento]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[registroMovimiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numeroCuenta] [nvarchar](50) NULL,
	[fecha] [datetime] NULL,
	[movimiento] [nvarchar](max) NULL,
 CONSTRAINT [PK_registroMovimiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([id], [usuario], [contrasenia], [nombre], [apellido], [DNI], [direccion], [ciudad], [provincia], [pais], [telefono], [login]) VALUES (1, N'CFulanito', N'123456', N'Cosme', N'Fulanito', 32154656, N'tututut 684', N'Ciudad Evita', N'Buenos Aires', N'Argentina', 3485675, 1)
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[cuentaCripto] ON 

INSERT [dbo].[cuentaCripto] ([id], [clienteId], [UUID], [saldo]) VALUES (1, 1, N'B233A5D8.6674.0DC5.E149.5845593489E8', 0.00013911583333333334)
SET IDENTITY_INSERT [dbo].[cuentaCripto] OFF
GO
SET IDENTITY_INSERT [dbo].[cuentaDolar] ON 

INSERT [dbo].[cuentaDolar] ([id], [clienteId], [CBU], [aliasCBU], [numeroCuenta], [saldo]) VALUES (3, 1, 8681209029654, N'pipo.soft.cuervo.1986', 86825, 500)
SET IDENTITY_INSERT [dbo].[cuentaDolar] OFF
GO
SET IDENTITY_INSERT [dbo].[cuentaPeso] ON 

INSERT [dbo].[cuentaPeso] ([id], [clienteId], [CBU], [aliasCBU], [numeroCuenta], [saldo]) VALUES (1, 1, 5769232901968, N'pipo.soft.cuervo.1986', 12345, 500)
INSERT [dbo].[cuentaPeso] ([id], [clienteId], [CBU], [aliasCBU], [numeroCuenta], [saldo]) VALUES (2, 1, 2094857629684, N'lol.dfg.233.fgbv', 56421, 0)
INSERT [dbo].[cuentaPeso] ([id], [clienteId], [CBU], [aliasCBU], [numeroCuenta], [saldo]) VALUES (3, 1, 6818312900403, N'pipo.soft.cuervo.1986', 39063, 0)
SET IDENTITY_INSERT [dbo].[cuentaPeso] OFF
GO
SET IDENTITY_INSERT [dbo].[registroMovimiento] ON 

INSERT [dbo].[registroMovimiento] ([id], [numeroCuenta], [fecha], [movimiento]) VALUES (1, N'12345', CAST(N'2022-06-08T15:36:12.587' AS DateTime), N'Se ha depositado AR$800 a la cuenta en pesos 12345')
INSERT [dbo].[registroMovimiento] ([id], [numeroCuenta], [fecha], [movimiento]) VALUES (2, N'12345', CAST(N'2022-06-08T17:09:55.137' AS DateTime), N'La cuenta en pesos 12345 realizo un envio de AR$500 a la cuenta en Bitcoins B233A5D8.6674.0DC5.E149.5845593489E8')
INSERT [dbo].[registroMovimiento] ([id], [numeroCuenta], [fecha], [movimiento]) VALUES (3, N'B233A5D8.6674.0DC5.E149.5845593489E8', CAST(N'2022-06-08T17:10:38.890' AS DateTime), N'La cuenta en Bitcoins B233A5D8.6674.0DC5.E149.5845593489E8 ha recibido BTC 0,00013911583333333334 de la cuenta en pesos 12345')
INSERT [dbo].[registroMovimiento] ([id], [numeroCuenta], [fecha], [movimiento]) VALUES (4, N'86825', CAST(N'2022-06-08T17:42:21.683' AS DateTime), N'Se ha depositado US$500 a la cuenta en dolares 86825')
SET IDENTITY_INSERT [dbo].[registroMovimiento] OFF
GO
ALTER TABLE [dbo].[cuentaCripto]  WITH CHECK ADD  CONSTRAINT [FK_cuentaCripto_cuentaCripto] FOREIGN KEY([clienteId])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[cuentaCripto] CHECK CONSTRAINT [FK_cuentaCripto_cuentaCripto]
GO
ALTER TABLE [dbo].[cuentaDolar]  WITH CHECK ADD  CONSTRAINT [FK_cuentaDolar_cliente] FOREIGN KEY([clienteId])
REFERENCES [dbo].[cliente] ([id])
GO
ALTER TABLE [dbo].[cuentaDolar] CHECK CONSTRAINT [FK_cuentaDolar_cliente]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCliente]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarCliente]
	@id int,
	@usuario NVARCHAR(50),
	@contrasenia NVARCHAR(50),
	@nombre NVARCHAR(50),
	@apellido NVARCHAR(50),
	@DNI int,
	@direccion NVARCHAR(50),
	@ciudad NVARCHAR(50),
	@provincia NVARCHAR(50),
	@pais NVARCHAR(50),
	@telefono int
AS
BEGIN
	UPDATE cliente SET usuario = @usuario, contrasenia = @contrasenia, nombre = @nombre, apellido = @apellido, DNI = @DNI, direccion = @direccion, ciudad = @ciudad, provincia = @provincia, pais = @pais, telefono = @telefono WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[BorrarCliente]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarCliente]
	@id int
AS
BEGIN
	DELETE cliente WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[BorrarCuentaCripto]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarCuentaCripto]
	@id int
AS
BEGIN
	DELETE cuentaCripto WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[BorrarCuentaDolar]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarCuentaDolar]
	@id int
AS
BEGIN
	DELETE cuentaDolar WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[BorrarCuentaPeso]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarCuentaPeso]
	@id int
AS
BEGIN
	DELETE cuentaPeso WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[CambiarEstadoLogin]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CambiarEstadoLogin]
	@id int,
	@login bit
AS
BEGIN
	UPDATE cliente SET login = @login WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[CambiarSaldoCripto]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CambiarSaldoCripto]
	@Id int,
	@saldo float
AS
BEGIN
	UPDATE cuentaCripto SET saldo = @saldo WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[CambiarSaldoDolar]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CambiarSaldoDolar]
	@Id int,
	@saldo float
AS
BEGIN
	UPDATE cuentaDolar SET saldo = @saldo WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[CambiarSaldoPeso]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CambiarSaldoPeso]
	@Id int,
	@saldo float
AS
BEGIN
	UPDATE cuentaPeso SET saldo = @saldo WHERE id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[CrearCuentaCripto]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearCuentaCripto]
	@clienteId int,
	@UUID NVARCHAR(50),
	@saldo float
AS
BEGIN
	INSERT INTO cuentaCripto (clienteId, UUID, saldo) VALUES (@clienteId, @UUID, @saldo)
END
GO
/****** Object:  StoredProcedure [dbo].[CrearCuentaDolar]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearCuentaDolar]
	@clienteId int,
	@CBU bigint,
	@aliasCBU NVARCHAR(50),
	@numeroCuenta int,
	@saldo float
AS
BEGIN
	INSERT INTO cuentaDolar (clienteId, CBU, aliasCBU, numeroCuenta, saldo) VALUES (@clienteId, @CBU, @aliasCBU, @numeroCuenta, @saldo)
END
GO
/****** Object:  StoredProcedure [dbo].[CrearCuentaPeso]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearCuentaPeso]
	@clienteId int,
	@CBU bigint,
	@aliasCBU NVARCHAR(50),
	@numeroCuenta int,
	@saldo float
AS
BEGIN
	INSERT INTO cuentaPeso (clienteId, CBU, aliasCBU, numeroCuenta, saldo) VALUES (@clienteId, @CBU, @aliasCBU, @numeroCuenta, @saldo)
END
GO
/****** Object:  StoredProcedure [dbo].[CrearRegistroMovimiento]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearRegistroMovimiento]
	@numeroCuenta NVARCHAR(50),
	@fecha datetime,
	@registro NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO registroMovimiento (numeroCuenta, fecha, movimiento) VALUES (@numeroCuenta, @fecha, @registro)
END
GO
/****** Object:  StoredProcedure [dbo].[ListarCuentasCripto]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarCuentasCripto]
	@id int
AS
BEGIN
	SELECT * FROM cuentaCripto WHERE clienteId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ListarCuentasDolar]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarCuentasDolar]
	@id int
AS
BEGIN
	SELECT * FROM cuentaDolar WHERE clienteId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ListarCuentasPeso]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarCuentasPeso]
	@id int
AS
BEGIN
	SELECT * FROM cuentaPeso WHERE clienteId = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ListarRegistros]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarRegistros]
	@numeroCuenta NVARCHAR(50)
AS
BEGIN
	SELECT * FROM registroMovimiento WHERE numeroCuenta = @numeroCuenta
END
GO
/****** Object:  StoredProcedure [dbo].[LoginCliente]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoginCliente]
	@usuario NVARCHAR(50),
	@contrasenia NVARCHAR(50)
AS
BEGIN
	SELECT * FROM cliente WHERE usuario = @usuario AND contrasenia = @contrasenia
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCliente]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarCliente]
	@usuario NVARCHAR(50),
	@contrasenia NVARCHAR(50),
	@nombre NVARCHAR(50),
	@apellido NVARCHAR(50),
	@DNI int,
	@direccion NVARCHAR(50),
	@ciudad NVARCHAR(50),
	@provincia NVARCHAR(50),
	@pais NVARCHAR(50),
	@telefono int,
	@login bit
AS
BEGIN
	INSERT INTO cliente (usuario, contrasenia, nombre, apellido, DNI, direccion, ciudad, provincia, pais, telefono, login) VALUES (@usuario, @contrasenia, @nombre, @apellido, @DNI, @direccion, @ciudad, @provincia, @pais, @telefono, @login)
END
GO
/****** Object:  StoredProcedure [dbo].[TraerCliente]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerCliente]
	@id int
AS
BEGIN
	SELECT * FROM cliente WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[TraerCuentaCripto]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerCuentaCripto]
	@UUID NVARCHAR(50)
AS
BEGIN
	SELECT * FROM cuentaCripto WHERE UUID = @UUID
END
GO
/****** Object:  StoredProcedure [dbo].[TraerCuentaDolar]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerCuentaDolar]
	@CBU bigint
AS
BEGIN
	SELECT * FROM cuentaDolar WHERE CBU = @CBU
END
GO
/****** Object:  StoredProcedure [dbo].[TraerCuentaPeso]    Script Date: 9/6/2022 03:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TraerCuentaPeso]
	@CBU bigint
AS
BEGIN
	SELECT * FROM cuentaPeso WHERE CBU = @CBU
END
GO
USE [master]
GO
ALTER DATABASE [bancomunicadosDB] SET  READ_WRITE 
GO
