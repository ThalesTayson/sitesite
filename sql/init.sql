IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
    BEGIN
        CREATE TABLE [dbo].[Cliente](
            id INT IDENTITY(1,1) PRIMARY KEY,
            nome CHAR(70) NOT NULL,
            email CHAR(30) NOT NULL,
            fone VARCHAR(14) NOT NULL,
            endereco VARCHAR(200) NOT NULL,
            create_at DATETIME NOT NULL DEFAULT (SYSDATETIME()),
        )
    END;