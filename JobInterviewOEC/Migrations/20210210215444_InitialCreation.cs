using Microsoft.EntityFrameworkCore.Migrations;

namespace JobInterviewOEC.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtlasData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterIdDealerNo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    GrpNameDealerName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    DealerNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BillToPartly = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LineMake = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    ShipToParty = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    LocationId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AddrPriId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AddrLineOne = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddrLineTwo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtlasData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtlasData");
        }
    }
}
