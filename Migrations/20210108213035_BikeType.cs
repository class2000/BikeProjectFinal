using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeProjectFinal.Migrations
{
    public partial class BikeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderID",
                table: "Bike",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BikeType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeID = table.Column<int>(nullable: false),
                    TypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BikeType_Bike_BikeID",
                        column: x => x.BikeID,
                        principalTable: "Bike",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BikeType_Type_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Type",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bike_ProviderID",
                table: "Bike",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_BikeType_BikeID",
                table: "BikeType",
                column: "BikeID");

            migrationBuilder.CreateIndex(
                name: "IX_BikeType_TypeID",
                table: "BikeType",
                column: "TypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bike_Provider_ProviderID",
                table: "Bike",
                column: "ProviderID",
                principalTable: "Provider",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bike_Provider_ProviderID",
                table: "Bike");

            migrationBuilder.DropTable(
                name: "BikeType");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Bike_ProviderID",
                table: "Bike");

            migrationBuilder.DropColumn(
                name: "ProviderID",
                table: "Bike");
        }
    }
}
