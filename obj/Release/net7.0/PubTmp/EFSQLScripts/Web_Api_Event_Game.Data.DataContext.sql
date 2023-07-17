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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425153437_InitialCreate')
BEGIN
    CREATE TABLE [Clients] (
        [ClientId] int NOT NULL IDENTITY,
        [ClientName] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Clients] PRIMARY KEY ([ClientId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425153437_InitialCreate')
BEGIN
    CREATE TABLE [Games] (
        [GameId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Games] PRIMARY KEY ([GameId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425153437_InitialCreate')
BEGIN
    CREATE TABLE [Events] (
        [EventId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [StartDate] datetime2 NOT NULL,
        [EndDate] datetime2 NOT NULL,
        [ClientId] int NOT NULL,
        CONSTRAINT [PK_Events] PRIMARY KEY ([EventId]),
        CONSTRAINT [FK_Events_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([ClientId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425153437_InitialCreate')
BEGIN
    CREATE TABLE [Coupons] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Code] nvarchar(max) NOT NULL,
        [GameId] int NOT NULL,
        CONSTRAINT [PK_Coupons] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Coupons_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([GameId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425153437_InitialCreate')
BEGIN
    CREATE TABLE [EventGames] (
        [EventId] int NOT NULL,
        [GameId] int NOT NULL,
        CONSTRAINT [PK_EventGames] PRIMARY KEY ([EventId], [GameId]),
        CONSTRAINT [FK_EventGames_Events_EventId] FOREIGN KEY ([EventId]) REFERENCES [Events] ([EventId]) ON DELETE CASCADE,
        CONSTRAINT [FK_EventGames_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([GameId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_Coupons_GameId] ON [Coupons] ([GameId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_EventGames_GameId] ON [EventGames] ([GameId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425153437_InitialCreate')
BEGIN
    CREATE INDEX [IX_Events_ClientId] ON [Events] ([ClientId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230425153437_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230425153437_InitialCreate', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230426070711_AddNewEventGameRelationship')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230426070711_AddNewEventGameRelationship', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230426114140_AddEventGameRelationship')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230426114140_AddEventGameRelationship', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230426152011_NewFixGameVoucherEvent')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230426152011_NewFixGameVoucherEvent', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230426235637_FixTest')
BEGIN
    ALTER TABLE [Coupons] DROP CONSTRAINT [FK_Coupons_Games_GameId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230426235637_FixTest')
BEGIN
    ALTER TABLE [Events] DROP CONSTRAINT [FK_Events_Clients_ClientId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230426235637_FixTest')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Events]') AND [c].[name] = N'ClientId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Events] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Events] ALTER COLUMN [ClientId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230426235637_FixTest')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Coupons]') AND [c].[name] = N'GameId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Coupons] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Coupons] ALTER COLUMN [GameId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230426235637_FixTest')
BEGIN
    ALTER TABLE [Coupons] ADD CONSTRAINT [FK_Coupons_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([GameId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230426235637_FixTest')
BEGIN
    ALTER TABLE [Events] ADD CONSTRAINT [FK_Events_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([ClientId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230426235637_FixTest')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230426235637_FixTest', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427001015_FixNewObject')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230427001015_FixNewObject', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427102800_FixFinal')
BEGIN
    ALTER TABLE [Coupons] DROP CONSTRAINT [FK_Coupons_Games_GameId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427102800_FixFinal')
BEGIN
    ALTER TABLE [EventGames] DROP CONSTRAINT [FK_EventGames_Events_EventId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427102800_FixFinal')
BEGIN
    ALTER TABLE [EventGames] DROP CONSTRAINT [FK_EventGames_Games_GameId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427102800_FixFinal')
BEGIN
    ALTER TABLE [Events] DROP CONSTRAINT [FK_Events_Clients_ClientId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427102800_FixFinal')
BEGIN
    ALTER TABLE [Coupons] ADD CONSTRAINT [FK_Coupons_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([GameId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427102800_FixFinal')
BEGIN
    ALTER TABLE [EventGames] ADD CONSTRAINT [FK_EventGames_Events_EventId] FOREIGN KEY ([EventId]) REFERENCES [Events] ([EventId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427102800_FixFinal')
BEGIN
    ALTER TABLE [EventGames] ADD CONSTRAINT [FK_EventGames_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([GameId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427102800_FixFinal')
BEGIN
    ALTER TABLE [Events] ADD CONSTRAINT [FK_Events_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([ClientId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230427102800_FixFinal')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230427102800_FixFinal', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504130815_FixVoucher')
BEGIN
    ALTER TABLE [Coupons] ADD [Discount] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504130815_FixVoucher')
BEGIN
    ALTER TABLE [Coupons] ADD [UserId] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230504130815_FixVoucher')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230504130815_FixVoucher', N'7.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230511101519_FixFixVoucher')
BEGIN
    ALTER TABLE [Coupons] ADD [EventId] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230511101519_FixFixVoucher')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230511101519_FixFixVoucher', N'7.0.5');
END;
GO

COMMIT;
GO

