IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[clientes]') AND type in (N'U'))
    CREATE TABLE [dbo].[clientes](
    id INT IDENTITY(1,1) PRIMARY KEY,
    nome CHAR(70) NOT NULL,
    email CHAR(30) NOT NULL,
    fone VARCHAR(14) NOT NULL,
    endereco VARCHAR(200) NOT NULL
)
GO