using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDPN.Classifiers.Infrastructure.MySql.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StdAtdCategory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdAtdCategory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StdAtdLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InUnitIdStartIndex = table.Column<int>(type: "int", nullable: false),
                    InUnitIdEndIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdAtdLevel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StdCountry",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Alpha3 = table.Column<string>(type: "char(3)", fixedLength: true, maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumericCode = table.Column<int>(type: "int", nullable: false),
                    Group = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrencyId = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdCountry", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StdCurrency",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumericCode = table.Column<int>(type: "int", nullable: false),
                    MinorUnit = table.Column<int>(type: "int", nullable: true),
                    Group = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdCurrency", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StdPaperSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Format = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Use = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdPaperSize", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StdRegionLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdRegionLevel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StdAtdUnit",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentId = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AtdLevelId = table.Column<int>(type: "int", nullable: false),
                    AtdCategoryId = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdAtdUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StdAtdUnit_StdAtdCategory_AtdCategoryId",
                        column: x => x.AtdCategoryId,
                        principalTable: "StdAtdCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StdAtdUnit_StdAtdLevel_AtdLevelId",
                        column: x => x.AtdLevelId,
                        principalTable: "StdAtdLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StdAtdUnit_StdAtdUnit_ParentId",
                        column: x => x.ParentId,
                        principalTable: "StdAtdUnit",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StdRegion",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    RegionLevelId = table.Column<int>(type: "int", nullable: false),
                    CountryClassifierId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Center = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StdRegion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StdRegion_StdRegionLevel_RegionLevelId",
                        column: x => x.RegionLevelId,
                        principalTable: "StdRegionLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StdAtdUnit_AtdCategoryId",
                table: "StdAtdUnit",
                column: "AtdCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StdAtdUnit_AtdLevelId",
                table: "StdAtdUnit",
                column: "AtdLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StdAtdUnit_ParentId",
                table: "StdAtdUnit",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StdCountry_Alpha3",
                table: "StdCountry",
                column: "Alpha3",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StdCountry_NumericCode",
                table: "StdCountry",
                column: "NumericCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StdCurrency_NumericCode",
                table: "StdCurrency",
                column: "NumericCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StdRegion_RegionLevelId",
                table: "StdRegion",
                column: "RegionLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StdAtdUnit");

            migrationBuilder.DropTable(
                name: "StdCountry");

            migrationBuilder.DropTable(
                name: "StdCurrency");

            migrationBuilder.DropTable(
                name: "StdPaperSize");

            migrationBuilder.DropTable(
                name: "StdRegion");

            migrationBuilder.DropTable(
                name: "StdAtdCategory");

            migrationBuilder.DropTable(
                name: "StdAtdLevel");

            migrationBuilder.DropTable(
                name: "StdRegionLevel");
        }
    }
}
