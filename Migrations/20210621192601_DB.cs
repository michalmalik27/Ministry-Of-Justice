using Microsoft.EntityFrameworkCore.Migrations;

namespace MinistryOfJustice.Migrations
{
    public partial class DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssociationTypes",
                columns: table => new
                {
                    AssociationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssociationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationTypes", x => x.AssociationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyTypes",
                columns: table => new
                {
                    CurrencyTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyTypes", x => x.CurrencyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Associations",
                columns: table => new
                {
                    AssociationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AssociationTypeId = table.Column<int>(type: "int", nullable: false),
                    DonationAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonationPurpose = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DonationTerms = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CurrencyTypeId = table.Column<int>(type: "int", nullable: false),
                    ConversionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associations", x => x.AssociationId);
                    table.ForeignKey(
                        name: "FK_Associations_AssociationTypes_AssociationTypeId",
                        column: x => x.AssociationTypeId,
                        principalTable: "AssociationTypes",
                        principalColumn: "AssociationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Associations_CurrencyTypes_CurrencyTypeId",
                        column: x => x.CurrencyTypeId,
                        principalTable: "CurrencyTypes",
                        principalColumn: "CurrencyTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AssociationTypes",
                columns: new[] { "AssociationTypeId", "AssociationTypeName" },
                values: new object[,]
                {
                    { 1, "סוג 1" },
                    { 2, "סוג 2" },
                    { 3, "סוג 3" }
                });

            migrationBuilder.InsertData(
                table: "CurrencyTypes",
                columns: new[] { "CurrencyTypeId", "CurrencyTypeName" },
                values: new object[,]
                {
                    { 1, "סוג 1" },
                    { 2, "סוג 2" },
                    { 3, "סוג 3" }
                });

            migrationBuilder.InsertData(
                table: "Associations",
                columns: new[] { "AssociationId", "AssociationTypeId", "ConversionRate", "CreatedByUserId", "CurrencyTypeId", "DonationAmount", "DonationPurpose", "DonationTerms", "Name" },
                values: new object[] { 1, 1, 1.1m, 1, 1, 9000m, "מטרה 1", "חוקים", "עמותה 1" });

            migrationBuilder.InsertData(
                table: "Associations",
                columns: new[] { "AssociationId", "AssociationTypeId", "ConversionRate", "CreatedByUserId", "CurrencyTypeId", "DonationAmount", "DonationPurpose", "DonationTerms", "Name" },
                values: new object[] { 2, 2, 4.5m, 2, 2, 8000m, "מטרה 2", "חוקים", "עמותה 2" });

            migrationBuilder.CreateIndex(
                name: "IX_Associations_AssociationTypeId",
                table: "Associations",
                column: "AssociationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_CurrencyTypeId",
                table: "Associations",
                column: "CurrencyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Associations");

            migrationBuilder.DropTable(
                name: "AssociationTypes");

            migrationBuilder.DropTable(
                name: "CurrencyTypes");
        }
    }
}
