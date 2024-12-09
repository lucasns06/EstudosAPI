IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_TAREFAS] (
    [Id] int NOT NULL IDENTITY,
    [Data] datetime2 NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    [Prioridade] int NOT NULL,
    [Completo] bit NOT NULL,
    CONSTRAINT [PK_TB_TAREFAS] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241108151157_InitialCreate', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Completo', N'Data', N'Nome', N'Prioridade') AND [object_id] = OBJECT_ID(N'[TB_TAREFAS]'))
    SET IDENTITY_INSERT [TB_TAREFAS] ON;
INSERT INTO [TB_TAREFAS] ([Id], [Completo], [Data], [Nome], [Prioridade])
VALUES (1, CAST(0 AS bit), '2024-11-15T00:00:00.0000000', N'Estudar Matemática', 2),
(2, CAST(0 AS bit), '2024-11-16T00:00:00.0000000', N'Revisar Física', 1),
(3, CAST(0 AS bit), '2024-11-17T00:00:00.0000000', N'Ler sobre Química', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Completo', N'Data', N'Nome', N'Prioridade') AND [object_id] = OBJECT_ID(N'[TB_TAREFAS]'))
    SET IDENTITY_INSERT [TB_TAREFAS] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241108151911_TarefasExemplo', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[TB_TAREFAS].[Data]', N'DataTermino', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241110002413_dataTermino', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_TAREFAS]') AND [c].[name] = N'DataTermino');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TB_TAREFAS] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [TB_TAREFAS] ALTER COLUMN [DataTermino] nvarchar(max) NOT NULL;
GO

UPDATE [TB_TAREFAS] SET [DataTermino] = N'05/10'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_TAREFAS] SET [DataTermino] = N'11/10'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_TAREFAS] SET [DataTermino] = N'28/11'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241110003200_stringDataTermino', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_CATEGORIAS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_CATEGORIAS] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_CATEGORIAS]'))
    SET IDENTITY_INSERT [TB_CATEGORIAS] ON;
INSERT INTO [TB_CATEGORIAS] ([Id], [Nome])
VALUES (1, N'Matematica');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_CATEGORIAS]'))
    SET IDENTITY_INSERT [TB_CATEGORIAS] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241110005903_categoriasExemplo', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TB_TAREFAS] ADD [CategoriaId] int NOT NULL DEFAULT 0;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_CATEGORIAS]'))
    SET IDENTITY_INSERT [TB_CATEGORIAS] ON;
INSERT INTO [TB_CATEGORIAS] ([Id], [Nome])
VALUES (2, N'Fisica');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_CATEGORIAS]'))
    SET IDENTITY_INSERT [TB_CATEGORIAS] OFF;
GO

UPDATE [TB_TAREFAS] SET [CategoriaId] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_TAREFAS] SET [CategoriaId] = 2
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_TAREFAS] SET [CategoriaId] = 1, [Nome] = N'Regra de três'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_TB_TAREFAS_CategoriaId] ON [TB_TAREFAS] ([CategoriaId]);
GO

ALTER TABLE [TB_TAREFAS] ADD CONSTRAINT [FK_TB_TAREFAS_TB_CATEGORIAS_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [TB_CATEGORIAS] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241111005952_categoriaRelacaoTarefa', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TB_CATEGORIAS] ADD [UsuarioId] int NULL;
GO

CREATE TABLE [TB_USUARIOS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [DataAcesso] datetime2 NULL,
    [Perfil] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Id])
);
GO

UPDATE [TB_CATEGORIAS] SET [UsuarioId] = NULL
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_CATEGORIAS] SET [UsuarioId] = NULL
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'Nome', N'PasswordHash', N'PasswordSalt', N'Perfil') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Id], [DataAcesso], [Email], [Foto], [Latitude], [Longitude], [Nome], [PasswordHash], [PasswordSalt], [Perfil])
VALUES (1, NULL, N'seuEmail@gmail.com', NULL, -23.520024100000001E0, -46.596497999999997E0, N'UsuarioAdmin', 0x1D626E977503ACF1CCAF73D354F294689D7438D21355C2291EF321EAE41CB08F30D9A795B4EE0C0BE198E1A900BC1FDC920777695B56F503E3C72956DF95A6EC, 0x50186758699A2FDFB286B96819FC918A46645D4E557E56F012241A41BDED689BE841C50C387EAA6C87E22C26B75F89049ED0B2EF426C460D5E9CDAB4B5C4D41EAD3B7F3212C15311940C4D1D7017AB44150298D7BE0FC9F0236C9CA08D1D5539B3E004568743DB3F19E2752AC5877BB0E78E73F7A042A3FCE5574E6D4C3B3D23, N'Admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'Nome', N'PasswordHash', N'PasswordSalt', N'Perfil') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;
GO

CREATE INDEX [IX_TB_CATEGORIAS_UsuarioId] ON [TB_CATEGORIAS] ([UsuarioId]);
GO

ALTER TABLE [TB_CATEGORIAS] ADD CONSTRAINT [FK_TB_CATEGORIAS_TB_USUARIOS_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIOS] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241114005708_Usuario', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[TB_USUARIOS].[Nome]', N'Username', N'COLUMN';
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TB_USUARIOS]') AND [c].[name] = N'Perfil');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [TB_USUARIOS] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [TB_USUARIOS] ADD DEFAULT N'Jogador' FOR [Perfil];
GO

UPDATE [TB_USUARIOS] SET [PasswordHash] = 0xE5DD73DC0FC03142044110BAFCCD2C90199EB08D1F8CBEB17541BC5F4E0D0A7BB18D5CB85692DEE501D6191BCD5EC359E68BB553FE0CF940DEA8739CBF41B86C, [PasswordSalt] = 0xE953D2C2089D34821C673CE4B273B8BEFE126BFD7435E572B4001CDA7AA01FB68992B06452D256667C0F665777A4149E96D0A55DFDFABBD1B7863F899117626EDBAE1495EAABBC841ACF5D6FACE9944F62D43F5A6FA3A8A1CC10440353E878DAB38380631F7F5A2AE8EA5FE07D2BCD530487E4A267961EE051A80AD07CB51C06
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241209005328_MigracaoUsuarioChange', N'8.0.10');
GO

COMMIT;
GO

