IF OBJECT_ID(N'[__Std_EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__Std_EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___Std_EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE TABLE [StdAtdCategory] (
        [Id] nvarchar(1) NOT NULL,
        [Name] nvarchar(200) NOT NULL,
        CONSTRAINT [PK_StdAtdCategory] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE TABLE [StdAtdLevel] (
        [Id] int NOT NULL,
        [Name] nvarchar(200) NOT NULL,
        [InUnitIdStartIndex] int NOT NULL,
        [InUnitIdStoptIndex] int NOT NULL,
        CONSTRAINT [PK_StdAtdLevel] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE TABLE [StdCountry] (
        [Id] int NOT NULL,
        [Alpha2] nchar(2) NOT NULL,
        [Alpha3] nchar(3) NOT NULL,
        [Group] int NOT NULL DEFAULT 0,
        [Name] nvarchar(100) NOT NULL,
        [CurrencyId] nvarchar(3) NULL,
        CONSTRAINT [PK_StdCountry] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE TABLE [StdCurrency] (
        [Id] nvarchar(450) NOT NULL,
        [NumericCode] int NOT NULL,
        [MinorUnit] int NULL,
        [Group] int NOT NULL DEFAULT 0,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_StdCurrency] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE TABLE [StdPaperSize] (
        [Id] int NOT NULL,
        [Format] nvarchar(8) NOT NULL,
        [Width] int NOT NULL,
        [Height] int NOT NULL,
        [Use] nvarchar(200) NULL,
        CONSTRAINT [PK_StdPaperSize] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE TABLE [StdRegionLevel] (
        [Id] int NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_StdRegionLevel] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE TABLE [StdAtdUnit] (
        [Id] nvarchar(20) NOT NULL,
        [ParentId] nvarchar(20) NULL,
        [AtdLevelId] int NOT NULL,
        [AtdCategoryId] nvarchar(1) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_StdAtdUnit] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_StdAtdUnit_StdAtdCategory_AtdCategoryId] FOREIGN KEY ([AtdCategoryId]) REFERENCES [StdAtdCategory] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_StdAtdUnit_StdAtdLevel_AtdLevelId] FOREIGN KEY ([AtdLevelId]) REFERENCES [StdAtdLevel] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_StdAtdUnit_StdAtdUnit_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [StdAtdUnit] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE TABLE [StdRegion] (
        [Id] nvarchar(450) NOT NULL,
        [CountryId] int NOT NULL,
        [RegionLevelId] int NOT NULL,
        [CountryClassifierId] nvarchar(max) NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [Center] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_StdRegion] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_StdRegion_StdRegionLevel_RegionLevelId] FOREIGN KEY ([RegionLevelId]) REFERENCES [StdRegionLevel] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE INDEX [IX_StdAtdUnit_AtdCategoryId] ON [StdAtdUnit] ([AtdCategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE INDEX [IX_StdAtdUnit_AtdLevelId] ON [StdAtdUnit] ([AtdLevelId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE INDEX [IX_StdAtdUnit_ParentId] ON [StdAtdUnit] ([ParentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_StdCountry_Alpha2] ON [StdCountry] ([Alpha2]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_StdCountry_Alpha3] ON [StdCountry] ([Alpha3]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX [IX_StdCurrency_NumericCode] ON [StdCurrency] ([NumericCode]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    CREATE INDEX [IX_StdRegion_RegionLevelId] ON [StdRegion] ([RegionLevelId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__Std_EFMigrationsHistory] WHERE [MigrationId] = N'20211101170255_InitialCreate')
BEGIN
    INSERT INTO [__Std_EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211101170255_InitialCreate', N'5.0.11');
END;
GO

COMMIT;
GO

