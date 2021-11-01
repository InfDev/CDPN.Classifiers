CREATE TABLE IF NOT EXISTS "__Std_EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___Std_EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE TABLE "StdAtdCategory" (
        "Id" character varying(1) NOT NULL,
        "Name" character varying(200) NOT NULL,
        CONSTRAINT "PK_StdAtdCategory" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE TABLE "StdAtdLevel" (
        "Id" integer NOT NULL,
        "Name" character varying(200) NOT NULL,
        "InUnitIdStartIndex" integer NOT NULL,
        "InUnitIdStoptIndex" integer NOT NULL,
        CONSTRAINT "PK_StdAtdLevel" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE TABLE "StdCountry" (
        "Id" integer NOT NULL,
        "Alpha2" character(2) NOT NULL,
        "Alpha3" character(3) NOT NULL,
        "Group" integer NOT NULL DEFAULT 0,
        "Name" character varying(100) NOT NULL,
        "CurrencyId" character varying(3) NULL,
        CONSTRAINT "PK_StdCountry" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE TABLE "StdCurrency" (
        "Id" text NOT NULL,
        "NumericCode" integer NOT NULL,
        "MinorUnit" integer NULL,
        "Group" integer NOT NULL DEFAULT 0,
        "Name" character varying(100) NOT NULL,
        CONSTRAINT "PK_StdCurrency" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE TABLE "StdPaperSize" (
        "Id" integer NOT NULL,
        "Format" character varying(8) NOT NULL,
        "Width" integer NOT NULL,
        "Height" integer NOT NULL,
        "Use" character varying(200) NULL,
        CONSTRAINT "PK_StdPaperSize" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE TABLE "StdRegionLevel" (
        "Id" integer NOT NULL,
        "Name" character varying(100) NOT NULL,
        CONSTRAINT "PK_StdRegionLevel" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE TABLE "StdAtdUnit" (
        "Id" character varying(20) NOT NULL,
        "ParentId" character varying(20) NULL,
        "AtdLevelId" integer NOT NULL,
        "AtdCategoryId" character varying(1) NOT NULL,
        "Name" character varying(100) NOT NULL,
        CONSTRAINT "PK_StdAtdUnit" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_StdAtdUnit_StdAtdCategory_AtdCategoryId" FOREIGN KEY ("AtdCategoryId") REFERENCES "StdAtdCategory" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_StdAtdUnit_StdAtdLevel_AtdLevelId" FOREIGN KEY ("AtdLevelId") REFERENCES "StdAtdLevel" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_StdAtdUnit_StdAtdUnit_ParentId" FOREIGN KEY ("ParentId") REFERENCES "StdAtdUnit" ("Id") ON DELETE RESTRICT
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE TABLE "StdRegion" (
        "Id" text NOT NULL,
        "CountryId" integer NOT NULL,
        "RegionLevelId" integer NOT NULL,
        "CountryClassifierId" text NOT NULL,
        "Name" character varying(100) NOT NULL,
        "Center" character varying(50) NOT NULL,
        CONSTRAINT "PK_StdRegion" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_StdRegion_StdRegionLevel_RegionLevelId" FOREIGN KEY ("RegionLevelId") REFERENCES "StdRegionLevel" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE INDEX "IX_StdAtdUnit_AtdCategoryId" ON "StdAtdUnit" ("AtdCategoryId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE INDEX "IX_StdAtdUnit_AtdLevelId" ON "StdAtdUnit" ("AtdLevelId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE INDEX "IX_StdAtdUnit_ParentId" ON "StdAtdUnit" ("ParentId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE UNIQUE INDEX "IX_StdCountry_Alpha2" ON "StdCountry" ("Alpha2");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE UNIQUE INDEX "IX_StdCountry_Alpha3" ON "StdCountry" ("Alpha3");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE UNIQUE INDEX "IX_StdCurrency_NumericCode" ON "StdCurrency" ("NumericCode");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    CREATE INDEX "IX_StdRegion_RegionLevelId" ON "StdRegion" ("RegionLevelId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__Std_EFMigrationsHistory" WHERE "MigrationId" = '20211101170344_InitialCreate') THEN
    INSERT INTO "__Std_EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20211101170344_InitialCreate', '5.0.11');
    END IF;
END $EF$;
COMMIT;

