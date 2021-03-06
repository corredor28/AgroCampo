
CREATE DATABASE [agrocampo]
GO

use agrocampo
go

CREATE TABLE [dbo].[persona](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[documento] [nvarchar](50) NOT NULL,
	[nombre] [nvarchar](100) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER DATABASE [agrocampo] SET  READ_WRITE 
GO
