CREATE TABLE IF NOT EXISTS "__Std_EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___Std_EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "StdAtdCategory" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_StdAtdCategory" PRIMARY KEY,
    "Name" TEXT NOT NULL
);

CREATE TABLE "StdAtdLevel" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_StdAtdLevel" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "InUnitIdStartIndex" INTEGER NOT NULL,
    "InUnitIdStoptIndex" INTEGER NOT NULL
);

CREATE TABLE "StdCountry" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_StdCountry" PRIMARY KEY,
    "Alpha3" TEXT NOT NULL,
    "NumericCode" INTEGER NOT NULL,
    "Group" INTEGER NOT NULL DEFAULT 0,
    "Name" TEXT NOT NULL,
    "CurrencyId" TEXT NULL
);

CREATE TABLE "StdCurrency" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_StdCurrency" PRIMARY KEY,
    "NumericCode" INTEGER NOT NULL,
    "MinorUnit" INTEGER NULL,
    "Group" INTEGER NOT NULL DEFAULT 0,
    "Name" TEXT NOT NULL
);

CREATE TABLE "StdPaperSize" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_StdPaperSize" PRIMARY KEY,
    "Format" TEXT NOT NULL,
    "Width" INTEGER NOT NULL,
    "Height" INTEGER NOT NULL,
    "Use" TEXT NULL
);

CREATE TABLE "StdRegionLevel" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_StdRegionLevel" PRIMARY KEY,
    "Name" TEXT NOT NULL
);

CREATE TABLE "StdAtdUnit" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_StdAtdUnit" PRIMARY KEY,
    "ParentId" TEXT NULL,
    "AtdLevelId" INTEGER NOT NULL,
    "AtdCategoryId" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    CONSTRAINT "FK_StdAtdUnit_StdAtdCategory_AtdCategoryId" FOREIGN KEY ("AtdCategoryId") REFERENCES "StdAtdCategory" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_StdAtdUnit_StdAtdLevel_AtdLevelId" FOREIGN KEY ("AtdLevelId") REFERENCES "StdAtdLevel" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_StdAtdUnit_StdAtdUnit_ParentId" FOREIGN KEY ("ParentId") REFERENCES "StdAtdUnit" ("Id")
);

CREATE TABLE "StdRegion" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_StdRegion" PRIMARY KEY,
    "CountryId" INTEGER NOT NULL,
    "RegionLevelId" INTEGER NOT NULL,
    "CountryClassifierId" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    "Center" TEXT NOT NULL,
    CONSTRAINT "FK_StdRegion_StdRegionLevel_RegionLevelId" FOREIGN KEY ("RegionLevelId") REFERENCES "StdRegionLevel" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_StdAtdUnit_AtdCategoryId" ON "StdAtdUnit" ("AtdCategoryId");

CREATE INDEX "IX_StdAtdUnit_AtdLevelId" ON "StdAtdUnit" ("AtdLevelId");

CREATE INDEX "IX_StdAtdUnit_ParentId" ON "StdAtdUnit" ("ParentId");

CREATE UNIQUE INDEX "IX_StdCountry_Alpha3" ON "StdCountry" ("Alpha3");

CREATE UNIQUE INDEX "IX_StdCountry_NumericCode" ON "StdCountry" ("NumericCode");

CREATE UNIQUE INDEX "IX_StdCurrency_NumericCode" ON "StdCurrency" ("NumericCode");

CREATE INDEX "IX_StdRegion_RegionLevelId" ON "StdRegion" ("RegionLevelId");

INSERT INTO "__Std_EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20211102191129_InitialCreate', '6.0.0-rc.2.21480.5');

COMMIT;

