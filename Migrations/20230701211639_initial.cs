using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfectAttendanceSolution.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LoacationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ExtraInt1 = table.Column<int>(type: "int", nullable: false),
                    ExtraInt2 = table.Column<int>(type: "int", nullable: false),
                    ExtraFloat1 = table.Column<float>(type: "real", nullable: false),
                    ExtraFloat2 = table.Column<float>(type: "real", nullable: false),
                    ExtraBit1 = table.Column<bool>(type: "bit", nullable: false),
                    ExtraBit2 = table.Column<bool>(type: "bit", nullable: false),
                    ExtraText1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraText2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LoacationID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SegmentID = table.Column<int>(type: "int", nullable: false),
                    EmployeeNo = table.Column<int>(type: "int", nullable: false),
                    DocumentEmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegmentFilter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignationsFilters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeLevelsFilters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeAntiFilter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionFilter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryFilter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationFilter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrientationFilter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderFilter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportMethodFilter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGroupID = table.Column<int>(type: "int", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PreviousPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActiveStatus = table.Column<int>(type: "int", nullable: true),
                    UserStatus = table.Column<int>(type: "int", nullable: true),
                    PasswordCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordExp = table.Column<int>(type: "int", nullable: true),
                    ExtraInt1 = table.Column<int>(type: "int", nullable: true),
                    ExtraInt2 = table.Column<int>(type: "int", nullable: true),
                    ExtraInt3 = table.Column<int>(type: "int", nullable: true),
                    ExtraString1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraString2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraString3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraBool1 = table.Column<bool>(type: "bit", nullable: true),
                    ExtraBool2 = table.Column<bool>(type: "bit", nullable: true),
                    ExtraBool3 = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedMachine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedMachine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
