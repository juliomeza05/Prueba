USE [Factura]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 08/05/2020 13:19:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Valor] [numeric](18, 2) NULL,
	[Nombre] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([Codigo], [Valor], [Nombre]) VALUES (11, CAST(9.50 AS Numeric(18, 2)), N'Antibiotico para el COVID-19')
INSERT [dbo].[Productos] ([Codigo], [Valor], [Nombre]) VALUES (17, CAST(2700.00 AS Numeric(18, 2)), N'Cola y pola ')
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_Productos_Actualizar]    Script Date: 08/05/2020 13:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Julio Alfonso Meza Iglesias
-- Create date: 06/05/2020
-- Description:	Realiza el update del producto
-- =============================================
CREATE PROCEDURE [dbo].[sp_Productos_Actualizar]
  @pCodigo int,
  @pValor numeric(18,2),
  @pNombre nvarchar(250)

AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE Productos SET Valor  =  @pValor,
	                     Nombre =  @pNombre
	WHERE                Codigo =  @pCodigo
	 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Productos_Eliminar]    Script Date: 08/05/2020 13:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Julio Alfonso Meza Iglesias
-- Create date: 06/05/2020
-- Description:	Elimina el producto con el codigo asociado
-- =============================================
CREATE PROCEDURE [dbo].[sp_Productos_Eliminar]
  @pCodigo int 

AS
BEGIN
	
	SET NOCOUNT ON;

	DELETE FROM Productos WHERE Codigo = @pCodigo
		
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Productos_Insertar]    Script Date: 08/05/2020 13:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Julio Alfonso Meza Iglesias
-- Create date: 06/05/2020
-- Description:	Realiza el insert del producto
-- =============================================
CREATE PROCEDURE [dbo].[sp_Productos_Insertar]
  @pValor numeric(18,2),
  @pNombre nvarchar(250)

AS
BEGIN
	
	SET NOCOUNT ON;

	INSERT INTO Productos (Valor,Nombre) VALUES (@pValor,@pNombre)
		
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Productos_Obtener]    Script Date: 08/05/2020 13:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Julio Alfonso Meza Iglesias
-- Create date: 06/05/2020
-- Description:	Realiza el select del producto
-- =============================================
CREATE PROCEDURE [dbo].[sp_Productos_Obtener]
  @pCodigo int = null
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT Codigo,
	       Valor,
		   Nombre
	FROM Productos
	WHERE Codigo = IIF(@pCodigo is null or @pCodigo ='' ,Codigo, @pCodigo)
		
END
GO
