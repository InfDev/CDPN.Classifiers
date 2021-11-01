CREATE TABLE IF NOT EXISTS `__Std_EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___Std_EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET utf8mb4;

START TRANSACTION;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE TABLE `StdAtdCategory` (
        `Id` varchar(1) CHARACTER SET utf8mb4 NOT NULL,
        `Name` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_StdAtdCategory` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE TABLE `StdAtdLevel` (
        `Id` int NOT NULL,
        `Name` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
        `InUnitIdStartIndex` int NOT NULL,
        `InUnitIdStoptIndex` int NOT NULL,
        CONSTRAINT `PK_StdAtdLevel` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE TABLE `StdCountry` (
        `Id` int NOT NULL,
        `Alpha2` char(2) CHARACTER SET utf8mb4 NOT NULL,
        `Alpha3` char(3) CHARACTER SET utf8mb4 NOT NULL,
        `Group` int NOT NULL DEFAULT 0,
        `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `CurrencyId` varchar(3) CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_StdCountry` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE TABLE `StdCurrency` (
        `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `NumericCode` int NOT NULL,
        `MinorUnit` int NULL,
        `Group` int NOT NULL DEFAULT 0,
        `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_StdCurrency` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE TABLE `StdPaperSize` (
        `Id` int NOT NULL,
        `Format` varchar(8) CHARACTER SET utf8mb4 NOT NULL,
        `Width` int NOT NULL,
        `Height` int NOT NULL,
        `Use` varchar(200) CHARACTER SET utf8mb4 NULL,
        CONSTRAINT `PK_StdPaperSize` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE TABLE `StdRegionLevel` (
        `Id` int NOT NULL,
        `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_StdRegionLevel` PRIMARY KEY (`Id`)
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE TABLE `StdAtdUnit` (
        `Id` varchar(20) CHARACTER SET utf8mb4 NOT NULL,
        `ParentId` varchar(20) CHARACTER SET utf8mb4 NULL,
        `AtdLevelId` int NOT NULL,
        `AtdCategoryId` varchar(1) CHARACTER SET utf8mb4 NOT NULL,
        `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_StdAtdUnit` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_StdAtdUnit_StdAtdCategory_AtdCategoryId` FOREIGN KEY (`AtdCategoryId`) REFERENCES `StdAtdCategory` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_StdAtdUnit_StdAtdLevel_AtdLevelId` FOREIGN KEY (`AtdLevelId`) REFERENCES `StdAtdLevel` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_StdAtdUnit_StdAtdUnit_ParentId` FOREIGN KEY (`ParentId`) REFERENCES `StdAtdUnit` (`Id`) ON DELETE RESTRICT
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE TABLE `StdRegion` (
        `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `CountryId` int NOT NULL,
        `RegionLevelId` int NOT NULL,
        `CountryClassifierId` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `Center` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_StdRegion` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_StdRegion_StdRegionLevel_RegionLevelId` FOREIGN KEY (`RegionLevelId`) REFERENCES `StdRegionLevel` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE INDEX `IX_StdAtdUnit_AtdCategoryId` ON `StdAtdUnit` (`AtdCategoryId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE INDEX `IX_StdAtdUnit_AtdLevelId` ON `StdAtdUnit` (`AtdLevelId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE INDEX `IX_StdAtdUnit_ParentId` ON `StdAtdUnit` (`ParentId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_StdCountry_Alpha2` ON `StdCountry` (`Alpha2`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_StdCountry_Alpha3` ON `StdCountry` (`Alpha3`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_StdCurrency_NumericCode` ON `StdCurrency` (`NumericCode`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    CREATE INDEX `IX_StdRegion_RegionLevelId` ON `StdRegion` (`RegionLevelId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;


DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__Std_EFMigrationsHistory` WHERE `MigrationId` = '20211101170330_InitialCreate') THEN

    INSERT INTO `__Std_EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20211101170330_InitialCreate', '5.0.11');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

